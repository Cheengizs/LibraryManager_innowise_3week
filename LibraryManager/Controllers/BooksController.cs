using FluentValidation;
using LibraryManager.DtoModels;
using LibraryManager.Models;
using LibraryManager.Repositories.BookRepository;
using LibraryManager.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace LibraryManager.Controllers;

[ApiController]
[Route("/api/v1/books")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _repository;
    private readonly BookValidator _bookValidator;

    public BooksController(IBookRepository repository)
    {
        _repository = repository;
        _bookValidator = new BookValidator();
    }

    [HttpGet("author/{authorId}")]
    public async Task<IActionResult> GetAllAuthorsBooksAsync(int authorId)
    {
        try
        {
            if (!(await _repository.CheckAuthorExistsAsync(authorId)))
                return NotFound("Author not found");

            var list = await _repository.GetBooksByAuthorIdAsync(authorId);
            return Ok(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        try
        {
            var books = await _repository.GetAllBooksAsync();
            return Ok(books);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        try
        {
            var obj = await _repository.GetBookByIdAsync(id);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookAsync(BookRequestDto bookDto)
    {
        try
        {
            Book book = new Book()
            {
                // id is temporary
                Id = 1,
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
                PublishedYear = bookDto.PublishedYear,
            };
            
            if (!(await _bookValidator.ValidateAsync(book)).IsValid)
                return BadRequest("Invalid book");
            
            // var temp = await _repository.GetBookByIdAsync(book.Id);
            // if (temp != null)
            //     return Conflict("Book already exists");

            await _repository.CreateBookAsync(book);
            return Created($"/api/v1/books/{book.Id}", book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookAsync(Book book)
    {
        try
        {
            if (!(await _bookValidator.ValidateAsync(book)).IsValid)
                return BadRequest("Invalid book");

            var temp = await _repository.GetBookByIdAsync(book.Id);
            if (temp == null)
                return NotFound("Book not found");

            await _repository.UpdateBookAsync(book);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookByIdAsync(int id)
    {
        try
        {
            var book = await _repository.GetBookByIdAsync(id);
            if (book == null)
                return NotFound("Book not found");

            await _repository.DeleteBookAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}