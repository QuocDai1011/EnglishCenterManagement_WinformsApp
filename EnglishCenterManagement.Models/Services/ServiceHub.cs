using EnglishCenterManagement.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCenterManagement.Models.Services
{
    public class ServiceHub
    {
        public  IClassService _classService { get; }
        public ICourseService _courseService { get; }
        public ITeacherService _teacherService { get; }

        public ServiceHub(
            IClassService classService,          
            ICourseService courseService,
            ITeacherService teacherService)
        {
            _classService = classService;
            _courseService = courseService;
            _teacherService = teacherService;
        }
    }
}
