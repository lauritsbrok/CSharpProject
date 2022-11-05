namespace Application.Core;

public record GitRepoDTO(int Id, string Url, ISet<string> Commits, ISet<string> Authors);

public record GitRepoCreateDTO(string Url, ISet<string>? Commits, ISet<string>? Authors);

public record GitRepoUpdateDTO(string Url, ISet<string> Commits, ISet<string> Authors);