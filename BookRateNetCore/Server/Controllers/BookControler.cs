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
using BookRateNetCore.Shared.Dtos;
using BookRateNetCore.Server.Queries;

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

        // ========================================= Book =========================================

        [HttpGet]
        [Route("GetBooks")]
        public ActionResult<List<Book>> GetAll([FromQuery] Guid? bookId)
        {
            //var url = bookId is null ? null : bookId;

            var books = _mediator.Send(new GetAllBookQuery(bookId));
            return Ok(books);
        }


        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddBook([FromBody] CreateBookCommand command)
        {
            _mediator.Send(command);
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

        // ========================================= Category =========================================


        [HttpGet]
        [Route("GetCategory")]
        public ActionResult<List<CategoryDto>> GetCategory()
        {
            var categories = _mediator.Send(new GetAllCategoryQuery());
            return Ok(categories);
        }


        [HttpPost]
        [Route("AddCategory")]
        public ActionResult AddCategory([FromBody] AddCategoryCommand command)
        {
            _mediator.Send(command);
            return Ok();
        }


        [HttpDelete]
        [Route("DeleteCategory/{categoryId}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] Guid categoryId)
        {
            var command = new DeleteCategoryCommand(categoryId);
            await _mediator.Send(command);
            return Ok();
        }


        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }


        // ========================================= Seed =========================================

        [HttpPost]
        [Route("SeedRandom")]
        public ActionResult Seed()
        {
            _bookSeeder.SeedBook();
            return Ok();
        }


    }
}
