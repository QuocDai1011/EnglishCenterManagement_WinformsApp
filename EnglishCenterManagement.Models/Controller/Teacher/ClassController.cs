using EnglishCenterManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Controller.Teacher
{
    public class ClassController
    {
        private readonly EnglishCenterDbContext _context;

        public ClassController (EnglishCenterDbContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAll()
        {
            return await _context.Classes.ToListAsync();
        }
    }
}
