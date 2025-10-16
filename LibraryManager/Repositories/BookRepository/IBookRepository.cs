using LibraryManager.Models;

namespace LibraryManager.Repositories.BookRepository;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
}