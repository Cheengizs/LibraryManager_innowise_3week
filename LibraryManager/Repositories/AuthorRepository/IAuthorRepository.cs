using LibraryManager.Models;

namespace LibraryManager.Repositories.AuthorRepository;

public interface IAuthorRepository 
{
    Task<List<Author>> GetAllAuthorsAsync();
    Task<Author?> GetAuthorByIdAsync(int id);
    Task CreateAuthorAsync(Author author);
    Task UpdateAuthorAsync(Author author);
    Task DeleteAuthorAsync(int id);
}