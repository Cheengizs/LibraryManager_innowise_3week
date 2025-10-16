using LibraryManager.Controllers;
using LibraryManager.DatabaseImitation;
using LibraryManager.Models;
using LibraryManager.Validators;

namespace LibraryManager.Repositories.BookRepository;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _context;
    
    public BookRepository(LibraryDbContext libraryDbContext)
    {
        _context = libraryDbContext;
    }
    
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return _context.Books;
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public async Task CreateBookAsync(Book book)
    {
        _context.Books.Add(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        var obj = _context.Books.FirstOrDefault(b => b.Id == book.Id);
        obj = book;
    }

    public async Task DeleteBookAsync(int id)
    {
        var obj = _context.Books.First(b => b.Id == id);
        _context.Books.Remove(obj);
    }
}