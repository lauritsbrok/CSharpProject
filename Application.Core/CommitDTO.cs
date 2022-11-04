namespace Application.Core;

public record CommitDTO(string Id, string message, string authorName, string repoUrl);

public record CommitCreateDTO(string Name, string authorName, string repoUrl);

public record CommitUpdateDTO(string Id, string message, string authorName, string repoUrl);
