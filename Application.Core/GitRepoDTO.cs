namespace Application.Core;

public record GitRepoDTO(int Id, string url, IReadOnlyCollection<int> commits, IReadOnlyCollection<string> authors);

public record GitRepoCreateDTO(string url, IReadOnlyCollection<int>? commits, IReadOnlyCollection<string>? authors);

public record GitRepoUpdateDTO(int Id, string url, IReadOnlyCollection<int> commits, IReadOnlyCollection<string> authors);