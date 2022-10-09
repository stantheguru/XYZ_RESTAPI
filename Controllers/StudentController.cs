using XYZ.DBOperations;
using XYZ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace XYZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DBContext DBContext;
       
        public StudentController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }
        //list all students
        [HttpGet("GetStudents")]
        public async Task<ActionResult<List<DBStudent>>> Get()
        {
            var List = await DBContext.Students.Select(
                student => new DBStudent
                {
                    StudentID = student.StudentID,
                    StudentName = student.StudentName,
                    StudentEmail = student.StudentEmail,
                    StudentMobile = student.StudentMobile,
                    Department = student.Department,
                    Course = student.Course
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        //select a specific student
        [HttpGet("GetStudentByStudentId")]
        public async Task<ActionResult<DBStudent>> GetStudentByStudentId(int student_id)
        {
           DBStudent Student = await DBContext.Students.Select(
                    student => new DBStudent
                    {
                        StudentID = student.StudentID,
                        StudentName = student.StudentName,
                        StudentEmail = student.StudentEmail,
                        StudentMobile = student.StudentMobile,
                        Department = student.Department,
                        Course = student.Course
                    })
                .FirstOrDefaultAsync(student => student.StudentID == student_id);

            if (Student == null)
            {
                return NotFound();
            }
            else
            {
                return Student;
            }
        }

        //add a student record
        [HttpPost("InsertStudent")]
        public async Task<HttpStatusCode> InserStudent(DBStudent Student)
        {
            var entity = new Student()
            
            {
                StudentID = Student.StudentID,
                StudentName = Student.StudentName,
                StudentEmail = Student.StudentEmail,
                StudentMobile = Student.StudentMobile,
                Department = Student.Department,
                Course = Student.Course
            };
           

            DBContext.Students.Add(entity);
            await DBContext.SaveChangesAsync();

          

            return HttpStatusCode.Created;
        }


        //update a student record
        [HttpPut("UpdateStudent")]
        public async Task<HttpStatusCode> UpdateStudent(DBStudent Student)
        {
            var entity = await DBContext.Students.FirstOrDefaultAsync(student => student.StudentID == Student.StudentID);

            entity.StudentID = Student.StudentID;
            entity.StudentName = Student.StudentName;
            entity.StudentEmail = Student.StudentEmail;
            entity.StudentMobile = Student.StudentMobile;
            entity.Department = Student.Department;
            entity.Course = Student.Course;


            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        //delete a student record
        [HttpDelete("DeleteStudent/{Id}")]
        public async Task<HttpStatusCode> DeleteStudent(int Id)
        {
            var entity = new Student()
            {
                StudentID = Id
            };
            DBContext.Students.Attach(entity);
            DBContext.Students.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
