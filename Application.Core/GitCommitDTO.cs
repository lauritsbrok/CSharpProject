namespace Application.Core;

public record GitCommitDTO(string Id, string message, string authorName, string repoUrl);

public record GitCommitCreateDTO(string Name, string authorName, string repoUrl);

public record GitCommitUpdateDTO(string Id, string message, string authorName, string repoUrl);
