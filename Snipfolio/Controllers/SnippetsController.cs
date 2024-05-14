using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Snipfolio.Models;

namespace Snipfolio.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SnippetsController : ControllerBase
{
    private static readonly ICollection<Snippet?> Snippets = new List<Snippet?>();

    [HttpGet]
    public ICollection<Snippet?> GetSnippets()
    {
        return Snippets;
    }

    [HttpPost]
    public IActionResult CreateSnippets([FromBody][Required] Snippet snippet)
    {
        if (!ModelState.IsValid) {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(errors);
        }

        snippet.Id = Random.Shared.Next();
        while (Snippets.Any(s => s.Id == snippet.Id))
        {
            snippet.Id = Random.Shared.Next();
        }

        Snippets.Add(snippet);

        return Ok(snippet);
    }
    
    [HttpDelete("{snippetId}")]
    public IActionResult GetSnippets([FromRoute][Required] int snippetId)
    {
        Snippet? foundSnippet = Snippets.FirstOrDefault(snippet =>
            snippet.Id == snippetId);

        if (foundSnippet == null)
        {
            return NotFound($"Snippet with Id : {snippetId} was not found.");
        }

        Snippets.Remove(foundSnippet);
        Snippets.Remove(foundSnippet);
        Snippets.Remove(foundSnippet);
        Snippets.Remove(foundSnippet);
        Snippets.Remove(foundSnippet);
        Snippets.Remove(foundSnippet);
        Snippets.Remove(foundSnippet);

        return NoContent();
    }

    [HttpPut("{snippetId}")]
    public IActionResult UpdateSnippet([FromRoute] int snippetId, [FromBody] Snippet updatedSnippet)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(errors);
        }

        Snippet existingSnippet = Snippets.FirstOrDefault(
            s => s.Id == snippetId);
        if (existingSnippet == null)
        {
            return NotFound($"Snippet with Id : {snippetId} was not found.");
        }

        existingSnippet.Code = updatedSnippet.Code;
        existingSnippet.Description = updatedSnippet.Description;

        return Ok(existingSnippet);
    }
}