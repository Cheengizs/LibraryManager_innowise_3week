using LibraryManager.Models;

namespace LibraryManager.Repositories.BookRepository;

public interface IBookRepository
{
    Task<bool> CheckAuthorExistsAsync(int authorId);
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<List<Book>> GetBooksByAuthorIdAsync(int authorId);
    Task CreateBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
}