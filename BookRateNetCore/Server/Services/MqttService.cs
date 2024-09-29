using MQTTnet.Client;
using MQTTnet;
using static BookRateNetCore.Client.Pages.MqttReceive;
using System.Text;
using BookRateNetCore.Shared;
using Microsoft.AspNetCore.SignalR;
using BookRateNetCore.Server.Hubs;

namespace BookRateNetCore.Server.Services
{

    public class ObiektMQTT
    {
        public string topic { get; set; }
        public string payload { get; set; }
        public string idToken { get; set; }
    }

    public class MqttService
    {
        private readonly IMqttClient _mqttClient;
        private readonly IHubContext<MqttHub> _hubContext;


        public MqttService(IHubContext<MqttHub> hubContext)
        {
            _hubContext = hubContext;
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            Console.WriteLine("MqttService created");
        }


        public async Task ConnectAsync()
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("broker.hivemq.com")
                .Build();

            await _mqttClient.ConnectAsync(options);
            Console.WriteLine("connected to broker.hivemq.com");
        }

        public async Task SubscribeAsync(string topic)
        {
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());

            _mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Console.WriteLine($"Received: {payload} on topic {e.ApplicationMessage.Topic}");
                return Task.CompletedTask;
            };
        }

        public async Task PublishAsync(string topic, string message)
        {
            var mqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(message)
                .Build();

            await _mqttClient.PublishAsync(mqttMessage);
        }


        public async Task Publish_Application_Message(MqttMessageDto message)
        {

            string topic = message.Topic;
            string payload = message.Payload;
            string idToken = "HJK-678J-YYL";
            /*
             * This sample pushes a simple application message including a topic and a payload.
             *
             * Always use builders where they exist. Builders (in this project) are designed to be
             * backward compatible. Creating an _MqttApplicationMessage_ via its constructor is also
             * supported but the class might change often in future releases where the builder does not
             * or at least provides backward compatibility where possible.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("broker.hivemq.com")
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                string payloadWithTokenId = payload + "\n" + "TokenID: " + idToken;

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    //.WithPayload(tObjekt.payload)
                    .WithPayload(payloadWithTokenId)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                await mqttClient.DisconnectAsync();

                Console.WriteLine($"MQTT application message is published - tokenID: {idToken} ");

            }
        }



        //public async Task Handle_Received_Application_Message()
        public async Task<MqttMessageDto> Handle_Received_Application_Message(MqttMessageDto message)
        {
            /*
             * This sample subscribes to a topic and processes the received message.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("broker.hivemq.com").Build();

                // Setup message handling before connecting so that queued messages
                // are also handled properly. When there is no event handler attached all
                // received messages get lost.
                mqttClient.ApplicationMessageReceivedAsync += async e =>
                {
                    Console.WriteLine("Received application message.");

                    // Konwertuj payload na string
                    var payloadReceive = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                    Console.WriteLine($"Topic: {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"Payload: {payloadReceive}");
                    Console.WriteLine($"Quality of Service: {e.ApplicationMessage.QualityOfServiceLevel}");
                    Console.WriteLine($"Quality of Service: moje toStr {e.ApplicationMessage.QualityOfServiceLevel.ToString()}");

                    message.Payload = payloadReceive;                                       // jesli odebrał to wrzycam do obiektu nowa wartosc payload               

                    _hubContext.Clients.All.SendAsync("ReceiveMessage", e.ApplicationMessage.Topic, payloadReceive);

                    await Task.CompletedTask;
                };

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic(message.Topic);
                        })
                    .Build();

                await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);

                Console.WriteLine($"MQTT client subscribed to topic - {message.Topic}");
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();

                return message;
            }

        }

    }
}
