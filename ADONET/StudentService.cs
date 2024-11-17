using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ADONET
{
    internal class StudentService
    {
        private static Sql _sql;

        public StudentService()
        {
            _sql = new Sql();
        }
        public void Add(Student student)
        {
            int result = _sql.ExecuteCommands($"INSERT INTO Students VALUES('{student.Name}','{student.Surname}',{student.Age},{student.AvgPoint})");
            if (result > 0)
            {
                Console.WriteLine("Complited");
            }

            else
            {
                Console.WriteLine("Error");
            }
        }
        public List<Student> GetAll()
        {

            List<Student> students = new List<Student>();
            DataTable table = _sql.ExecuteQuery("SELECT * FROM Students");
            foreach (DataRow item in table.Rows)
            {

                Student student = new Student
                {
                    Id = (int)item["Id"],
                    Name = (string)item["Name"],
                    Surname = (string)item["Surname"],
                    Age = (int)item["Age"],
                    AvgPoint = (int)item["AvgPoint"]

                };
                students.Add(student);

            }
            return students;
        }
        public void Delete(int id)
        {
            int result = _sql.ExecuteCommands($"DELETE FROM Students WHERE Id={id}");
            if (result > 0)
            {
                Console.WriteLine("Complited");
            }

            else
            {
                Console.WriteLine("Error");
            }

        }
        public Student GetId(int id)
        {
            Student student = null;

            DataTable table = _sql.ExecuteQuery($"SELECT * FROM Students WHERE Id={id}");
            DataRow row = table.Rows[0];

            student = new Student
            {
                Id = (int)(row["Id"]),
                Name = row["Name"].ToString(),
                Surname = row["Surname"].ToString(),
                Age = (int)(row["Age"]),
                AvgPoint = (int)(row["AvgPoint"])
            };



            return student;
        }
        public void Update(Student student)
        {
            // SQL sorğusu parametrli istifadə edilmədiyi halda
            student = new Student
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Age = student.Age,
                AvgPoint = student.AvgPoint
            };

            _sql.ExecuteCommands($"UPDATE Students SET Name = '{student.Name}', Surname = '{student.Surname}', Age = {student.Age}, AvgPoint = {student.AvgPoint} WHERE Id = {student.Id}");
        }
    }
    }


