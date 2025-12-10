using System.ComponentModel;

namespace Shared.Common;

// ────────────────────────────── Localization ──────────────────────────────
public enum Lang
{
    En = 1,
    Ar = 2
}

// ────────────────────────────── HTTP Semantic Codes (Internal Use) ──────────────────────────────
public enum HttpResponseStatus
{
    [Description("OK")] OK = 200,
    [Description("Created")] Created = 201,
    [Description("Bad Request")] BadRequest = 400,
    [Description("Unauthorized")] Unauthorized = 401,
    [Description("Forbidden")] Forbidden = 403,
    [Description("Not Found")] DataNotFound = 404,
    [Description("Conflict")] Conflict = 409,
    [Description("Internal Server Error")] InternalServerError = 500
}

// ────────────────────────────── Utility ──────────────────────────────
public enum SortDirection
{
    Ascending = 1,
    Descending = 2
}

// ────────────────────────────── Generic Messages (Consider Pruning Later) ──────────────────────────────
public enum MessageType
{
    // CRUD
    SaveSuccessfully,
    SaveFailed,
    UpdateSuccessfully,
    UpdateFailed,
    DeleteSuccessfully,
    DeleteFailed,
    RetrieveSuccessfully,
    RetrieveFailed,
    NoDataFound,

    // Auth
    UserLoginSuccess,
    InvalidUserLogin,
    PasswordIncorrect,
    EmailNotFound,
    DontHavePermission,
    InvalidToken,
    TokenExpired,
    EmailAlreadyExists,
    AccountLocked,

    // System
    InvalidInput,
    SystemProblem
}
