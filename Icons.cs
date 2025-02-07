
using System.ComponentModel.DataAnnotations;

public class Icons
{
    [Key]
    public int Id { get; set; }
    public string Icon { get; set; }
    public string Link { get; set; }
}

