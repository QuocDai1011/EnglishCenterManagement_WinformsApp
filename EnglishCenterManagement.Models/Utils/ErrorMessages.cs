namespace EnglishCenterManagement.Models.Utils
{
    public static class ErrorMessages
    {
        // Validation Messages
        public const string REQUIRED_USERNAME = "Tên đăng nhập không được để trống!";
        public const string INVALID_USERNAME = "Tên đăng nhập không hợp lệ!\n(4-30 ký tự, chỉ chữ, số và dấu gạch dưới)";
        public const string REQUIRED_PASSWORD = "Mật khẩu không được để trống!";
        public const string INVALID_PASSWORD = "Mật khẩu phải có ít nhất 6 ký tự!";
        public const string REQUIRED_FULLNAME = "Họ và tên không được để trống!";
        public const string INVALID_FULLNAME = "Họ và tên không hợp lệ!\n(2-50 ký tự, không chứa số hoặc ký tự đặc biệt)";
        public const string REQUIRED_EMAIL = "Email không được để trống!";
        public const string INVALID_EMAIL = "Email không đúng định dạng!\n(VD: example@email.com)";
        public const string REQUIRED_PHONE = "Số điện thoại không được để trống!";
        public const string INVALID_PHONE = "Số điện thoại không hợp lệ!\n(10 số, bắt đầu bằng 03, 05, 07, 08, 09)";

        // Database Error Messages
        public const string DUPLICATE_USERNAME = "Tên đăng nhập đã tồn tại!\n\nVui lòng chọn tên đăng nhập khác.";
        public const string DUPLICATE_EMAIL = "Email đã được sử dụng!\n\nEmail này đã tồn tại trong hệ thống.\nVui lòng sử dụng email khác.";
        public const string FOREIGN_KEY_ERROR = "Lỗi ràng buộc dữ liệu!\n\nKhông thể lưu do có liên kết với dữ liệu khác.\nVui lòng kiểm tra lại thông tin.";
        public const string CONNECTION_ERROR = "Lỗi kết nối cơ sở dữ liệu!\n\nKhông thể kết nối đến máy chủ.\nVui lòng kiểm tra kết nối mạng và thử lại.";

        // Success Messages
        public const string SAVE_SUCCESS = "Lưu thông tin thành công!";
        public const string UPDATE_SUCCESS = "Cập nhật thông tin thành công!";
        public const string DELETE_SUCCESS = "Xóa thành công!";
    }
}