namespace Application.Core;

public record AuthorDTO(int Id, string Name, string Email);

public record AuthorCreateDTO(string Name, [EmailAddress]string Email);

public record AuthorUpdateDTO(int Id, string Name, [EmailAddress]string Email);
