namespace ADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            // Student student = new Student { Name = "Nigar", Surname = "Aliyeva", Age = 25, AvgPoint = 90 };
            // studentService.Add(student);
            //studentService.Delete(5);
           // List<Student> students = studentService.GetAll();
           // foreach (var item in students)
           // {
            //    Console.WriteLine(item.Id+" "+item.Name+" "+item.Surname);
          //  }
         

         // Student student=studentService.GetId(4);
           
            //Console.WriteLine($"Student Found: Name:{student.Name},Surname: {student.Surname}, Age: {student.Age}, AvgPoint: {student.AvgPoint}");
            Student updatedStudent = new Student
            {
                Id = 4,       
                Name = "Nigar", 
                Surname = "Aliyeva", 
                Age = 25,      
                AvgPoint = 85 
            };

           
            studentService.Update(updatedStudent);
        }
    }
}