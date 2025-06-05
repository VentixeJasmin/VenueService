using System.ComponentModel.DataAnnotations;

namespace Presentation.Models; 

public class VenueEntity
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    public string? VenueType { get; set; }

    public string? Description { get; set; } 

    public int Capacity { get; set; }

    public string? StreetAddress { get; set; }

    public string? PostCode { get; set; }

    [Required]
    public string City { get; set; } = null!;

    public string? MapUrl { get; set; } 

}
