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
        public IStudentService StudentService { get; }
        public IClassService ClassService { get; }

        public ICourseService CourseService { get; }


        public ServiceHub
            (
            IStudentService studentService,
            IClassService classService,
            ICourseService courseService
            ) 
        {
            StudentService = studentService;
            ClassService = classService;
            CourseService = courseService;
        }
    }
}
