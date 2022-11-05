namespace Application.Core;

public record GitCommitDTO(string Id, string Message, string AuthorName, string RepoUrl);

public record GitCommitCreateDTO(string Name, string AuthorName, string RepoUrl);

public record GitCommitUpdateDTO(string Id, string Message, string AuthorName, string RepoUrl);
