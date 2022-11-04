namespace Application.Core;

public record RepoDTO(int Id, string url, IReadOnlyCollection<int> commits, IReadOnlyCollection<string> authors);

public record RepoCreateDTO(string url, IReadOnlyCollection<int> commits, IReadOnlyCollection<string> authors);

public record RepoUpdateDTO(int Id, string url, IReadOnlyCollection<int> commits, IReadOnlyCollection<string> authors);