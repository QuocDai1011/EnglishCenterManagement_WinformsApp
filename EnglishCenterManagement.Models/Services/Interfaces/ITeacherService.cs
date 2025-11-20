using EnglishCenterManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Services.Interfaces
{
    public interface ITeacherService
    {
        Teacher GetById(int id);
        int Update(int id, Teacher teacher);
    }
}
