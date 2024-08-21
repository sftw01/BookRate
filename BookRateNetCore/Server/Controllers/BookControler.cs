using BookRateNetCore.Client.Services;
using BookRateNetCore.Server.Persistence;
using BookRateNetCore.Shared.Models;
using BookRateNetCore.Shared.Queries;
using BookRateNetCore.Shared.Services;
using BookRateNetCore.Shared.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookRateNetCore.Server.Commands;

namespace BookRateNetCore.Server.Controllers
{
    [Route("api/book")]
    //[Route("api/[controller]")]
    [ApiController]
    public class BookControler : ControllerBase
    {

        private readonly IBookSeeder _bookSeeder;
        private readonly IMediator _mediator;

        public BookControler(IMediator mediator, IBookSeeder bookSeeder)
        {
            _bookSeeder = bookSeeder;
            _mediator = mediator;
        }



        [HttpGet]
        [Route("GetBooks")]
        public ActionResult<List<Book>> GetAll()
        {
            var books = _mediator.Send(new GetAllBookQuery());
            return Ok(books);
        }



        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBook([FromBody] CreateBookCommand command)
        {
            _mediator.Send(command);
            return Ok();
        }



        [HttpPost]
        [Route("SeedRandom")]
        public ActionResult Seed()
        {
            _bookSeeder.Seed();
            return Ok();
        }



        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook([FromQuery] Guid bookId)
        {
            await _mediator.Send(new DeleteBookCommand(bookId));
            return Ok();
        }



        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<ActionResult> DeleteAll()
        {
            await _mediator.Send(new DeleteAllBooksCommand());
            return Ok();
        }












    }
}
