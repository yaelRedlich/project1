using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
//using lesson1.models;
namespace lesson1.Controllers;
[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
=======
// using lesson1.Models.Book;


namespace lesson1.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{            
>>>>>>> 7a140d203b396872be0380fff730b1052e3360d8
    private static List<Book> list;
    static BooksController()
    {
        list = new List<Book> 
        {
<<<<<<< HEAD
            new Book { Id = 1, Name = "math" ,Category=CategoryBooks.Textbook},
            new Book { Id = 2, Name = "With a nation builder", Category = CategoryBooks.History},
            new Book { Id = 3, Name = "The country", Category = CategoryBooks.Philosophy}
=======
            new Book { Id = 1, Name = "math" ,Category = "TextBook"},
            new Book { Id = 2, Name = "myDream" ,Category = "ReadingBook"},
            new Book { Id = 3, Name = "AlexanderHamilton" ,Category = "biography"},
>>>>>>> 7a140d203b396872be0380fff730b1052e3360d8
        };
    }

    [HttpGet]
    public IEnumerable<Book> Get()
    {
        return list;
    }
    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = list.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return BadRequest("invalid id");
        return book;
    }

<<<<<<< HEAD
    [HttpPost] 
    public ActionResult Insert(Book nb)
    {        
        var maxId = list.Max(b => b.Id);
        nb.Id = maxId + 1;
        list.Add(nb);
        return CreatedAtAction(nameof(Insert), new { id = nb.Id }, nb);
    }  
    [HttpPut("{id}")]
    public ActionResult Update(int id, Book nb)
=======
    [HttpPost]
    public ActionResult Insert(Book newBook)
    {        
        var maxId = list.Max(b => b.Id);
        newBook.Id = maxId + 1;
        list.Add(newBook);
        return CreatedAtAction(nameof(Insert), new { id = newBook.Id }, newBook);
    }  
    
    [HttpPut("{id}")]
    public ActionResult Update(int id, Book newBook)
>>>>>>> 7a140d203b396872be0380fff730b1052e3360d8
    { 
        var oldBook = list.FirstOrDefault(b => b.Id == id);
        if (oldBook == null) 
            return BadRequest("invalid id");
<<<<<<< HEAD
        if (nb.Id != oldBook.Id)
            return BadRequest("id mismatch");

        oldBook.Name = nb.Name;
        oldBook.Category = nb.Category;
        return NoContent();
    } 
   [HttpDelete("{id}")]
   public ActionResult Delete(int id){
        var foundBook = list.FirstOrDefault(b => b.Id == id);
         if (foundBook == null) 
            return BadRequest("invalid id");
        list.Remove(foundBook);
        return NoContent();
   }
=======
        if (newBook.Id != oldBook.Id)
            return BadRequest("id mismatch");
        oldBook.Name = newBook.Name;
        oldBook.Category = newBook.Category;
        return NoContent();
    } 
    [HttpDelete("{id}")] 
    public ActionResult Delete(int id)
    {
        var foundBook = list.FirstOrDefault(b => b.Id == id);
        if(foundBook == null)
         return NotFound($"Book with ID {id} not found.");
         list.Remove(foundBook);
        return NoContent();
    }
>>>>>>> 7a140d203b396872be0380fff730b1052e3360d8
}
