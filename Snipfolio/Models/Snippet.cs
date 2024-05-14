using System.ComponentModel.DataAnnotations;

namespace Snipfolio.Models;

public class Snippet
{
    public long Id { get; set; }
    [Required]
    public string? Author { get; set; }
    public string? Description { get; set; }
    [Required]
    public string? Code { get; set; }
}