using System;

namespace Library.Helpers.APIUtilities
{
    public class RepositoryActionResult : RepositoryResult, IRepositoryActionResult
    {
        public Exception Exception { get; }
        public new RepositoryActionStatus Status { get; }
        public int count { get; }

        public RepositoryActionResult(object result = null, RepositoryActionStatus status = RepositoryActionStatus.BadRequest, Exception exception = null, string message = null,int Count=0)
        {
            Data = result;
            Exception = exception;
            Message = message;
            Status = status;
            count = Count;
        }

        public IRepositoryActionResult GetRepositoryActionResult(object result = null, RepositoryActionStatus status = RepositoryActionStatus.BadRequest, Exception exception = null, string message = null,int Count = 0)
        {
            return  new RepositoryActionResult(result: result, status: status, exception: exception, message: message,Count:count);
        }
    }
    public class ReleaseNotes
    {
        public string Title { get; set; }
        public string Note { get; set; }
    }
}
