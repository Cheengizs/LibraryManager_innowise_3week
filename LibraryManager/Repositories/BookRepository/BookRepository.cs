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

    public async Task<bool> CheckAuthorExistsAsync(int authorId)
    {
        var obj = _context.Authors.FirstOrDefault(a => a.Id == authorId);
        if (obj == null)
            return false;
        
        return true;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return _context.Books;
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        return _context.Books.Where(b => b.AuthorId == authorId).ToList();
    }

    public async Task CreateBookAsync(Book book)
    {
        book.Id = _context.Books.Max(b => b.Id) + 1;
        _context.Books.Add(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        int index = _context.Books.FindIndex(b => b.Id == book.Id);
        _context.Books[index] = book;
    }

    public async Task DeleteBookAsync(int id)
    {
        var obj = _context.Books.First(b => b.Id == id);
        _context.Books.Remove(obj);
    }
}