namespace lesson1;
public enum CategoryBooks
{
    Biography,    
    Textbook,   
    Tension,   
    History, 
    Science,    
    Philosophy  
}
public class Book{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryBooks Category { get; set; }
    
}