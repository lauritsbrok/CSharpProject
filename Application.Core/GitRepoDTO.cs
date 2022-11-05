namespace Application.Core;

public record GitRepoDTO(int Id, string Url, ISet<GitCommitDTO> Commits, ISet<GitAuthorDTO> Authors);

public record GitRepoCreateDTO(string Url, ISet<GitCommitDTO>? Commits, ISet<GitAuthorDTO>? Authors);

public record GitRepoUpdateDTO(string Url, ISet<GitCommitDTO> Commits, ISet<GitAuthorDTO> Authors);