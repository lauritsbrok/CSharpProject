namespace Application.Core;

public record GitCommitDTO(string Id, string Message, GitAuthorDTO Auhtor, GitRepoDTO Repo);

public record GitCommitCreateDTO(string Id, string Message, GitAuthorCreateDTO Author, GitRepoDTO Repo);

public record GitCommitUpdateDTO(string Id, string Message, GitAuthorDTO Auhtor, GitRepoDTO Repo);
