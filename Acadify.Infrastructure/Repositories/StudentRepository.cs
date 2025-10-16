using Acadify.Data.Entities;
using Acadify.Infrastructure.Data;
using Acadify.Infrastructure.InfrastructureBases;
using Acadify.Infrastructure.Interfaces;
using Acadify.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student> , IStudentRepository
    {
        private readonly DbSet<Student> _students;
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _students.Include(x=>x.Department).ToListAsync();
        }
    }
}
