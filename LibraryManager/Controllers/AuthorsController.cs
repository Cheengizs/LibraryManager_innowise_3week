using LibraryManager.Models;
using LibraryManager.Repositories.AuthorRepository;
using LibraryManager.Validators;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers;

[ApiController]
[Route("/api/v1/authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorRepository _repository;
    private readonly AuthorValidator _authorValidator;

    public AuthorsController(IAuthorRepository repository)
    {
        _repository = repository;
        _authorValidator = new AuthorValidator();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthorsAsync(int id)
    {
        try
        {
            return Ok(await _repository.GetAllAuthorsAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorByIdAsync(int id)
    {
        try
        {
            Author? author = await _repository.GetAuthorByIdAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuthorAsync(Author author)
    {
        try
        {
            if (!(await _authorValidator.ValidateAsync(author)).IsValid)
                return BadRequest();
            
            var tempAuthor = await _repository.GetAuthorByIdAsync(author.Id);
            if (tempAuthor != null)
                return Conflict("This Author already exist");

            await _repository.CreateAuthorAsync(author);
            return Created($"/api/v1/authors/{author.Id}", author);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthorAsync(Author author)
    {
        try
        {
            if (!((await _authorValidator.ValidateAsync(author)).IsValid))
                return BadRequest();
            
            await _repository.UpdateAuthorAsync(author);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthorByIdAsync(int id)
    {
        try
        {
            var temp = await _repository.GetAuthorByIdAsync(id);
            if(temp == null)
                return NotFound();

            await _repository.DeleteAuthorAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}