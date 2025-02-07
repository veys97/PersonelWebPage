using System.ComponentModel.DataAnnotations;

public class IndexPage
{
    [Key]
    public int Id { get; set; }
    public string Profile { get; set; }
    public string Isim { get; set; }
    public string Appellation { get; set; }
    public string Description { get; set; }
    public string SocialMedia { get; set; }
}