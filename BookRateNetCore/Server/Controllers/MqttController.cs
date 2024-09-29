using BookRateNetCore.Server.Services;
using Microsoft.AspNetCore.Mvc;
using BookRateNetCore.Shared;

namespace BookRateNetCore.Server.Controllers
{

    [Route("api/mqtt")]
    //[Route("api/[controller]")]
    [ApiController]
    public class MqttController : Controller
    {

        private readonly MqttService _mqttService;

        public MqttController(MqttService mqttService)
        {
            _mqttService = mqttService;
        }

        
        [HttpPost("publish")]
        public async Task<IActionResult> Publish([FromBody] MqttMessageDto dto)
        {
            Console.WriteLine("publishing");
            await _mqttService.Publish_Application_Message(dto);
            //await _mqttService.PublishAsync("to2", dto.Payload);
            return Ok("publishing");
        }

       [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            return Ok("wszytsko okej");
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] MqttMessageDto dto)
        //public async Task<IActionResult> Subscribe([FromBody] string topic)
        {
            Console.WriteLine("subscribing");
            await _mqttService.Handle_Received_Application_Message(dto);
            return Ok();
        }
    }

    
}
