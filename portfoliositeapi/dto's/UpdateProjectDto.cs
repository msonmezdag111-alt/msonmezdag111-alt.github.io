namespace portfoliositeapi.DTOs;

public class UpdateProjectDto
{
    public string Titel { get; set; } = "";
    public string Beschrijving { get; set; } = "";
    public string Categorie { get; set; } = "";
    public string GitHubUrl { get; set; } = "";
    public string Datum { get; set; } = "";
}