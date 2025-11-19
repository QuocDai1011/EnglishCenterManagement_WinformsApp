using EnglishCenterManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Controller.Teacher
{
    public class TeacherController
    {
        private readonly EnglishCenterDbContext _context;

        public TeacherController (EnglishCenterDbContext context)
        {
            _context = context;
        }

    }
}
