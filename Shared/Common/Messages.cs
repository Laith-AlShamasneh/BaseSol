namespace Shared.Common;

public static class Messages
{
    private static readonly Dictionary<MessageType, (string Ar, string En)> _map = new()
    {
        // CRUD
        { MessageType.SaveSuccessfully, ("تم حفظ المعلومات بنجاح", "Data saved successfully") },
        { MessageType.SaveFailed, ("حدثت مشكلة، لم يتم حفظ البيانات", "Failed to save data") },
        { MessageType.UpdateSuccessfully, ("تم تعديل المعلومات بنجاح", "Data updated successfully") },
        { MessageType.UpdateFailed, ("حدثت مشكلة، لم يتم تعديل البيانات", "Failed to update data") },
        { MessageType.DeleteSuccessfully, ("تم حذف المعلومات بنجاح", "Data deleted successfully") },
        { MessageType.DeleteFailed, ("حدثت مشكلة، لم يتم حذف البيانات", "Failed to delete data") },
        { MessageType.RetrieveSuccessfully, ("تم جلب البيانات بنجاح", "Data retrieved successfully") },
        { MessageType.RetrieveFailed, ("حدثت مشكلة، لم يتم جلب البيانات", "Failed to retrieve data") },

        // Auth
        { MessageType.UserLoginSuccess, ("تم تسجيل الدخول بنجاح", "Logged in successfully") },
        { MessageType.InvalidUserLogin, ("اسم المستخدم أو كلمة المرور غير صحيحة", "Invalid username or password") },
        { MessageType.PasswordIncorrect, ("كلمة المرور غير صحيحة", "Incorrect password") },
        { MessageType.EmailNotFound, ("البريد الإلكتروني غير موجود", "Email not found") },
        { MessageType.InvalidToken, ("رمز وصول غير صالح", "Invalid access token") },
        { MessageType.TokenExpired, ("رمز التحديث غير صالح أو منتهي الصلاحية", "Invalid or expired refresh token") },
        { MessageType.EmailAlreadyExists, ("اسم المستخدم أو البريد الإلكتروني قيد الاستخدام بالفعل", "Username or Email is already in use") },
        { MessageType.AccountLocked, ("الحساب مغلق", "Account locked") },

        // System
        { MessageType.InvalidInput, ("البيانات المدخلة غير صحيحة", "Incorrect input data") },
        { MessageType.SystemProblem, ("مشكلة في النظام", "System error occurred") }
    };

    private const string FallbackEn = "Message not found";
    private const string FallbackAr = "لم يتم العثور على الرسالة";

    public static string GetMessage(MessageType type, Lang lang = Lang.En)
    {
        if (!_map.TryGetValue(type, out var val))
            return lang == Lang.En ? FallbackEn : FallbackAr;
        return lang == Lang.En ? val.En : val.Ar;
    }
}
