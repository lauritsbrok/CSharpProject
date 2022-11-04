namespace Application.Core;

public record CommitDTO(int Id, string message, string authorName, string repoUrl);

public record CommitCreateDTO(string Name, string authorName, string repoUrl);

public record CommitUpdateDTO(int Id, string message, string authorName, string repoUrl);
