using BookRateNetCore.Client.Services;
using BookRateNetCore.Server.Persistence;
using BookRateNetCore.Shared.Models;
using BookRateNetCore.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookRateNetCore.Server.Controllers
{
    [Route("api/book")]
    //[Route("api/[controller]")]
    [ApiController]
    public class BookControler : ControllerBase
    {

        private readonly IBookService _bookService;
        private readonly IBookSeeder _bookSeeder;


        public BookControler(IBookService bookService, IBookSeeder bookSeeder)
        {
            _bookService = bookService;
            _bookSeeder = bookSeeder;
        }

        [HttpGet]
        [Route("GetBooks")]
        public ActionResult<List<Book>> GetAll()
        {
            var books = _bookService.GetAll();
            return Ok(books);

            //return _bookService.GetAll();

        }

        [HttpPost]
        [Route("AddBook")]
        public ActionResult AddProduct([FromBody] Book book)
        {
            _bookService.Create(book);
            return Ok();
        }


        [HttpPost]
        [Route("SeedRandom")]
        public ActionResult Seed()
        {
            _bookSeeder.Seed();
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public ActionResult DeleteProduct([FromQuery] Guid bookId)
        {
            _bookService.Delete(bookId);
            return Ok();
        }



        [HttpDelete]
        [Route("DeleteAll")]
        public ActionResult DeleteAll()
        {
            _bookService.DeleteAll();
            return Ok();
        }












    }
}
