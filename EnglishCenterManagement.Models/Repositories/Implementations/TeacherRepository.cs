using EnglishCenterManagement.Models.Entities;
using EnglishCenterManagement.Models.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly EnglishCenterDbContext _context;

        public TeacherRepository(EnglishCenterDbContext context)
        {
            _context = context;
        }

        public Teacher? GetById(int id)
        {
            var teacher = _context.Teachers.Find(id);
            return teacher; // Find() trả về null nếu không tìm thấy, nên return trực tiếp
        }

        public int Update(int id, Teacher teacher)
        {
            var teacherTemp = _context.Teachers.Find(id);
            if(teacherTemp == null)
            {
                return 0;
            }

            teacherTemp.UpdateAt = (DateTime.Now);

            _context.Entry(teacherTemp).CurrentValues.SetValues(teacher);
            _context.SaveChangesAsync();

            return 1;
        }
    }
}
