using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlackCoderUniversityApp.Models;

namespace BlackCoderUniversityApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "StudentName1",   LastName = "LastName1",
                    EnrollmentDate = DateTime.Parse("2010-01-01") },
                new Student { FirstMidName = "StudentName2", LastName = "LastName2",
                    EnrollmentDate = DateTime.Parse("2012-01-01") },
                new Student { FirstMidName = "StudentName3",   LastName = "LastName3",
                    EnrollmentDate = DateTime.Parse("2013-01-01") },
                new Student { FirstMidName = "StudentName4",    LastName = "LastName4",
                    EnrollmentDate = DateTime.Parse("2012-01-01") },
                new Student { FirstMidName = "StudentName5",    LastName = "LastName5",
                    EnrollmentDate = DateTime.Parse("2011-01-01") },
                new Student { FirstMidName = "StudentName6",    LastName = "LastName6",
                    EnrollmentDate = DateTime.Parse("2013-01-01") },
                new Student { FirstMidName = "StudentName7",     LastName = "LastName7",
                    EnrollmentDate = DateTime.Parse("2005-01-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Instructor1",     LastName = "LastName1",
                    HireDate = DateTime.Parse("1985-04-14") },
                new Instructor { FirstMidName = "Instructor2",    LastName = "LastName2",
                    HireDate = DateTime.Parse("1587-08-14") },
                new Instructor { FirstMidName = "Instructor3",   LastName = "LastName3",
                    HireDate = DateTime.Parse("1998-09-12") },
                new Instructor { FirstMidName = "Instructor4", LastName = "LastName4",
                    HireDate = DateTime.Parse("1985-07-01") },
                new Instructor { FirstMidName = "Instructor5",   LastName = "LastName5",
                    HireDate = DateTime.Parse("2012-05-11") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Advanced Design",     Budget = 350000,
                    StartDate = DateTime.Parse("2014-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "BlackCoder1").ID },
                new Department { Name = "Design", Budget = 100000,
                    StartDate = DateTime.Parse("2012-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "BlackCoder2").ID },
                new Department { Name = "Advanced Structures", Budget = 350000,
                    StartDate = DateTime.Parse("2015-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "BlackCoder3").ID },
                new Department { Name = "Advanced Programming",   Budget = 100000,
                    StartDate = DateTime.Parse("2016-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "BlackCoder4").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseId = 1050, Title = "General Programming",      Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Structures").DepartmentId
                },
                new Course {CourseId = 4022, Title = "Programming 101", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },
                new Course {CourseId = 4041, Title = "Programming 201", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },
                new Course {CourseId = 1045, Title = "Algorithms",       Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Design").DepartmentId
                },
                new Course {CourseId = 3141, Title = "Front End",   Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Design").DepartmentId
                },
                new Course {CourseId = 2021, Title = "Back End",    Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Design").DepartmentId
                },
                new Course {CourseId = 2042, Title = "CSS",     Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Design").DepartmentId
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "BlackCoder10").ID,
                    Location = "Location1" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "BlackCoder11").ID,
                    Location = "Location2" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "BlackCoder12").ID,
                    Location = "Location3" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder20").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder21").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Programming 101" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder22").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Programming 201" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder23").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Algorithms" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder24").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Front End" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder25").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Back End" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder26").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "CSS" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "BlackCoder27").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder31").Id,
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder32").Id,
                    CourseId = courses.Single(c => c.Title == "Programming 101" ).CourseId,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder33").Id,
                    CourseId = courses.Single(c => c.Title == "Programming 201" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder34").Id,
                    CourseId = courses.Single(c => c.Title == "Algorithms" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder35").Id,
                    CourseId = courses.Single(c => c.Title == "Front End" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder36").Id,
                    CourseId = courses.Single(c => c.Title == "Back End" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder37").Id,
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder38").Id,
                    CourseId = courses.Single(c => c.Title == "Programming 101").CourseId,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder39").Id,
                    CourseId = courses.Single(c => c.Title == "General Programming").CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "BlackCoder40").Id,
                    CourseId = courses.Single(c => c.Title == "CSS").CourseId,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.Id == e.StudentId &&
                            s.Course.CourseId == e.CourseId).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
