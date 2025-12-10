using Shared.Common;

namespace Shared.Helpers;

/// <summary>
/// Maps service results to API responses with localization.
/// </summary>
public class ResponseHandler
{
    public static ApiResponse<T> Handle<T>(ServiceResult<T> result)
    {
        if (result.IsSuccess)
        {
            return ApiResponse<T>.Ok(
                result.Data!,
                result.Message,
                result.Code);
        }

        return ApiResponse<T>.Fail(
            result.ErrorCode ?? ErrorCodes.System.UNEXPECTED,
            result.Message,
            result.Code);
    }
}
