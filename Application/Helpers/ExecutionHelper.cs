using Microsoft.Extensions.Logging;
using Shared.Common;
using System.Runtime.CompilerServices;

namespace Application.Helpers;

public static class ExecutionHelper
{
    public static async Task<ServiceResult<T>> ExecuteAsync<T>(
        Func<Task<ServiceResult<T>>> action,
        ILogger logger,
        string operation,
        object? parameters = null,
        CancellationToken cancellationToken = default,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "",
        [CallerLineNumber] int lineNumber = 0)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await action();
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Failure in {Operation} | Method: {Member} | File: {File} | Line: {Line} | Params: {@Params}",
                operation, memberName, Path.GetFileName(filePath), lineNumber, parameters);

            return ServiceResult<T>.Failure(
                ErrorCodes.System.UNEXPECTED,
                Messages.GetMessage(MessageType.SystemProblem),
                HttpResponseStatus.InternalServerError);
        }
    }
}
