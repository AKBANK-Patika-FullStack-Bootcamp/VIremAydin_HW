using Microsoft.AspNetCore.Mvc;
using Week1.Data;
using Week1.Model;

namespace Week1.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class BookController : Controller
    {


        public readonly AppDbContext db;

        public BookController(AppDbContext d)
        {
            db = d;
        }
        private static List<Book> books = new List<Book>()
        {
            new Book() { Id = 1, BookName = "Digital Design",
            Author = "Harris"},

            new Book() { Id = 2, BookName ="harry potter", Author = " JK Rowlling"}
        };

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            var lst = db.demoInfo.ToList();
            Console.WriteLine(lst);
            return lst;
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book =  books.Find(x => x.Id == id);
            if (book == null)
                return BadRequest("book not found");

            return book;
        }

        [HttpGet("{id}/{name}")]
        public async Task<ActionResult<Book>> Get(int id, string name)
        {
            var book = db.demoInfo.FirstOrDefault(itm => itm.Id == id && itm.BookName.Equals(name));
            if(book == null) 
                return NotFound();
            return book;
        }


        [HttpPost]
        public async Task<ActionResult<List<Book>>> addBook(Book book)
        {
            // books.Add(book);
            //return books;

            db.demoInfo.Add(book);
            db.SaveChanges();
            return db.demoInfo.ToList();
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> updateBook(Book book1)
        {
          /*  var f = books.Find(itm => itm.Id == book.Id);
            if(f == null)
                return BadRequest("book not found");
            
            books[book.Id] = book;
            return books;*/
          var book = db.demoInfo.FirstOrDefault(itm => itm.Id == book1.Id);
            if(book == null)
                return NotFound();
            book.BookName = book1.BookName;
            db.SaveChanges();
            return db.demoInfo.ToList();
        }

        [HttpDelete]
        public async Task<ActionResult<List<Book>>> daleteBook(Book book)
        {
         //   var f = books.Find(itm => itm.Id == book.Id);
            var f = db.demoInfo.FirstOrDefault(b => b.Id == book.Id); 
            if (f == null)
                return BadRequest("book not found");

           // books.Remove(f);

            db.Remove(f);
            db.SaveChanges();
            return db.demoInfo.ToList();
        }
    }
}
