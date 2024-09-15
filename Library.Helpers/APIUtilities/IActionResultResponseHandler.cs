namespace Library.Helpers.APIUtilities
{
    public interface IActionResultResponseHandler
    {
        IRepositoryResult GetResult(IRepositoryActionResult repositoryActionResult);
    }
}
