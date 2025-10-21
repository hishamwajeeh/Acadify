using Acadify.Data.Entities;
using Acadify.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddStudentAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<string> EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);
        public Task<Student> GetStudentByIdWithoutIncludeAsync(int id);
        public IQueryable<Student> GetAllStudentsAsQueryable();
        public IQueryable<Student> FilterStudentPaginationQueryable(StudentOrderingEnum studentOrderingEnum,string search);

    }
}
