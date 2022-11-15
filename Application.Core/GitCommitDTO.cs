namespace Application.Core;

public record GitCommitDTO(string commitId, string Message, string AuthorName, string RepoUrl);

public record GitCommitCreateDTO(string commitId, string Message, GitAuthorDTO Author, string RepoUrl);

