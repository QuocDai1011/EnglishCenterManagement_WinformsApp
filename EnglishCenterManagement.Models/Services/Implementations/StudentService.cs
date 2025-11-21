using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories.Interfaces;
using EnglishCenterManagement.Models.Services.Interfaces;
using EnglishCenterManagement.Models.Utils;
using System.Collections.Generic;
using System.Text;
using static EnglishCenterManagement.Models.Utils.ValidationUtils;
namespace EnglishCenterManagement.Models.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public IEnumerable<Student> GetAllStudentsByClassId(int classId)
        {
            return _studentRepository.getAllStudentByClassId(classId);
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public string Create(Student student)
        {
            if (student == null)
                return "Dữ liệu sinh viên không hợp lệ!";

            string validationMessage = CheckStudent(student);
            if (!string.IsNullOrEmpty(validationMessage))
                return validationMessage;

            // Gọi repository
            string dbResult = _studentRepository.Create(student);

            if (!string.IsNullOrEmpty(dbResult))
            {
                // Có lỗi DB → xử lý để trả message rõ ràng cho UI
                if (dbResult.Contains("IX_students_user_name"))
                    return "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!";

                if (dbResult.Contains("IX_students_email"))
                    return "Email đã tồn tại trong hệ thống!";

                return "Lỗi khi lưu dữ liệu vào hệ thống: " + dbResult;
            }

            return null; // null = không lỗi
        }
        private string CheckStudent(Student student)
        {
            StringBuilder error = new StringBuilder();

            // Email
            if (!IsValidEmail(student.Email))
            {
                error.AppendLine("Email không hợp lệ!");
            }

            // Full name
            if (string.IsNullOrWhiteSpace(student.FullName))
            {
                error.AppendLine("Họ và tên không được để trống!");
            }

            // Phone number
            if (string.IsNullOrWhiteSpace(student.PhoneNumber) ||
                !IsValidPhone(student.PhoneNumber))
            {
                error.AppendLine("Số điện thoại không hợp lệ!");
            }

            // Username
            if (string.IsNullOrWhiteSpace(student.UserName))
            {
                error.AppendLine("Tên đăng nhập không được để trống!");
            }

            // Password
            if (string.IsNullOrWhiteSpace(student.Password) || student.Password.Length < 6)
            {
                error.AppendLine("Mật khẩu phải ít nhất 6 ký tự!");
            }

            return error.Length == 0 ? null : error.ToString();
        }


        public string Update(Student student)
        {
            if (student == null)
                return "Dữ liệu sinh viên không hợp lệ!";

            string validationMessage = CheckStudent(student);
            if (!string.IsNullOrEmpty(validationMessage))
                return validationMessage;

            // Gọi repository
            string dbResult = _studentRepository.Update(student);

            if (!string.IsNullOrEmpty(dbResult))
            {
                // Có lỗi DB → xử lý để trả message rõ ràng cho UI
                if (dbResult.Contains("IX_students_user_name"))
                    return "Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!";

                if (dbResult.Contains("IX_students_email"))
                    return "Email đã tồn tại trong hệ thống!";

                return "Lỗi khi lưu dữ liệu vào hệ thống: " + dbResult;
            }

            return null; // null = không lỗi
        }

        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }

    }
}
