using Microsoft.AspNetCore.Components;
namespace GitInsight.Blazor.Pages;

public class CommitListBase : ComponentBase
{
    [Parameter]
    public string Username { get; set; }

    [Parameter]
    public string repositoryName { get; set; }

    [Inject]
    public IRepoService? _repoService { get; set; }

    public ISet<CommitFreqDTO>? dataList { get; set; }

    public string ErrorMessage { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        try
        {
            var result = (await _repoService!.GetCommitFrequencyList(Username, repositoryName)!);
            dataList = new HashSet<CommitFreqDTO>();

            if (result != null && result.Count() > 0)
            {
                foreach (var res in result)
                {
                    var json = res.Split(" ");
                    var data = new CommitFreqDTO(Int32.Parse(json[0]), DateTime.Parse(json[1]));
                    dataList.Add(data);
                }
            }

        }
        catch (System.Exception ex)
        {

            ErrorMessage = ex.Message;
        }

    }
}