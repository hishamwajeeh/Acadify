using Acadify.Data.Entities;
using Acadify.Data.Enums;
using Acadify.Infrastructure.Interfaces;
using Acadify.Service.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            //var studentResult = await _studentRepository
            //    .GetTableNoTracking()
            //    .Where(s => s.Name == student.Name)
            //    .FirstOrDefaultAsync();

            //if (studentResult != null)
            //    return "Exist";

            await _studentRepository.AddAsync(student);
            return "Success";
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Error";
            }
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public IQueryable<Student> FilterStudentPaginationQueryable(StudentOrderingEnum studentOrderingEnum, string search)
        {
            var querable = _studentRepository.GetTableNoTracking()
                .Include(s => s.Department)
                .AsQueryable();
            if (search != null)
            {
                querable = querable.Where(s => s.Name.Contains(search) || s.Address.Contains(search));
            }
            switch (studentOrderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(s => s.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(s => s.Name);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(s => s.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(s => s.Department.DName);
                    break;
                default:
                    querable = querable.OrderBy(s => s.StudID);
                    break;
            }
            return querable;
        }

        public IQueryable<Student> GetAllStudentsAsQueryable()
        {
            return _studentRepository.GetTableNoTracking()
                .Include(s => s.Department).AsQueryable();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                .Include(s => s.Department)
                .Where(s => s.StudID == id)
                .FirstOrDefaultAsync();
            return student;
        }

        public Task<Student> GetStudentByIdWithoutIncludeAsync(int id)
        {
            var student = _studentRepository.GetByIdAsync(id);
            return student;
        }

        public Task<bool> IsNameExist(string name)
        {
            var student = _studentRepository.GetTableNoTracking().Where(s => s.Name == name);
            if (student == null || student.Count() == 0)
                return Task.FromResult(false);
            return Task.FromResult(true);
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            return await _studentRepository.GetTableNoTracking()
                .AnyAsync(s => s.Name == name && s.StudID != id);
        }

    }
}
