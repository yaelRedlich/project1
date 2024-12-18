using Microsoft.AspNetCore.Mvc;
// using lesson1.Models.Book;


namespace lesson1.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{            
    private static List<Book> list;
    static BooksController()
    {
        list = new List<Book> 
        {
            new Book { Id = 1, Name = "math" ,Category = "TextBook"},
            new Book { Id = 2, Name = "myDream" ,Category = "ReadingBook"},
            new Book { Id = 3, Name = "AlexanderHamilton" ,Category = "biography"},
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
    { 
        var oldBook = list.FirstOrDefault(b => b.Id == id);
        if (oldBook == null) 
            return BadRequest("invalid id");
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
}
