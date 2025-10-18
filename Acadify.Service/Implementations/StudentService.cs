using Acadify.Data.Entities;
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
            var studentResult = await _studentRepository
                .GetTableNoTracking()
                .Where(s => s.Name == student.Name)
                .FirstOrDefaultAsync();

            if (studentResult != null)
                return "Exist";

            await _studentRepository.AddAsync(student);
            return "Success";
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
    }
}
