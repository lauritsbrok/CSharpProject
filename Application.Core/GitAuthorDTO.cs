namespace Application.Core;

public record GitAuthorDTO(string Name, [EmailAddress]string Email);

public record GitAuthorCreateDTO(string Name, [EmailAddress]string Email);

public record GitAuthorUpdateDTO(int Id, string Name, [EmailAddress]string Email);
