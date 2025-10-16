using LibraryManager.DatabaseImitation;
using LibraryManager.Models;

namespace LibraryManager.Repositories.AuthorRepository;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryDbContext _context;
    
    public AuthorRepository(LibraryDbContext libraryDbContext)
    {
        _context = libraryDbContext;   
    }

    public async Task<List<Author>> GetAllAuthorsAsync()
    {
        return _context.Authors;
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        return _context.Authors.FirstOrDefault(a => a.Id == id);
    }

    public async Task CreateAuthorAsync(Author author)
    {
        _context.Authors.Add(author);
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        var obj = _context.Authors.First(a => a.Id == author.Id);
        obj = author;
    }

    public async Task DeleteAuthorAsync(int id)
    {
        var author = _context.Authors.First(a => a.Id == id);
        _context.Authors.Remove(author);
    }
}