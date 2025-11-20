using EnglishCenterManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Teacher GetById(int id);
        int Update(int id, Teacher teacher);
    }
}
