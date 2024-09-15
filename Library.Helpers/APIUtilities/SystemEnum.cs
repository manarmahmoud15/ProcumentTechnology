

namespace Library.Helpers.APIUtilities
{
    public enum RepositoryActionStatus
    {
        Ok,
        Created,
        Updated,
        NotFound,
        Deleted,
        NothingModified,
        Error,
        BadRequest,
        UnAuthorized,
        ExistedBefore,
        NothingAdded,
        ImportScussfully,
        ImportWithErrors,
        UpdateFileScussfully,
        UpdateFileWithErrors,
        EmptyFile,
        ValidationError,
        OfflineFalied,
        ActiveQuotation,
        NeedApproval,
        ValidationDataError,
    }
    public enum Language
    {
        Arabic = 2,
        English = 1
    } 
    public enum CategoryPropTypes
    {
        String = 1,
        Float = 2, 
        DateTime = 3
    }
}
