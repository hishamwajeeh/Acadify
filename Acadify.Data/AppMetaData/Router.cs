using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acadify.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string baseUrl = root + "/" + version + "/";

        public static class StudentRouting
        {
            public const string Prefix = baseUrl + "Students/";
            public const string getAllStudents = Prefix + "GetAllStudents";
            public const string getStudentById = Prefix + "GetStudentById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string Paginated = Prefix + "Paginated";
        }
    }
}
