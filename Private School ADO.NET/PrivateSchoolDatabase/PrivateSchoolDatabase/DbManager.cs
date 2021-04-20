using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace PrivateSchoolDatabase
{
    class DbManager
    {
        private readonly string _connectionString; 
        
        public DbManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool InsertStudent(Student student)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Students (FirstName, LastName, DateOfBirth, TuitionFees) " +
                    "VALUES(@firstName, @lastName, @dateOfBirth, @tuitionFees)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@firstName", student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@dateOfBirth", student.DateOfBirth));
                    cmd.Parameters.Add(new SqlParameter("@tuitionFees", student.TuitionFees));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch(SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch(SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public bool InsertTrainer(Trainer trainer)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Trainers (FirstName, LastName, Subject) " +
                    "VALUES(@firstName, @lastName, @subject)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@firstName", trainer.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", trainer.LastName));
                    cmd.Parameters.Add(new SqlParameter("@subject", trainer.Subject));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public bool InsertAssignment(Assignment assignment)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Assignments (Title, Description, SubDateTime, OralMark, TotalMark) " +
                    "VALUES(@title, @description, @subDateTime, @oralMark, @totalMark)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@title", assignment.Title));
                    cmd.Parameters.Add(new SqlParameter("@description", assignment.Description));
                    cmd.Parameters.Add(new SqlParameter("@subDateTime", assignment.SubDateTime));
                    cmd.Parameters.Add(new SqlParameter("@oralMark", assignment.OralMark));
                    cmd.Parameters.Add(new SqlParameter("@totalMark", assignment.TotalMark));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public bool InsertCourse(Course course)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Courses (Title, Stream, Type, StartDate, EndDate) " +
                    "VALUES(@title, @stream, @type, @startDate, @endDate)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@title", course.Title));
                    cmd.Parameters.Add(new SqlParameter("@stream", course.Stream == StreamValue.CSharp ? "C#" : "Java"));
                    cmd.Parameters.Add(new SqlParameter("@type", course.Type == TypeValue.Full_Time ? "Full-Time" : "Part-Time"));
                    cmd.Parameters.Add(new SqlParameter("@startDate", course.StartDate));
                    cmd.Parameters.Add(new SqlParameter("@endDate", course.EndDate));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public bool InsertStudentToACourse(int courseId, int studentId)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO StudentsPerCourse (CourseId, StudentId) " +
                    "VALUES(@courseId, @studentId)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                    cmd.Parameters.Add(new SqlParameter("@studentId", studentId));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public bool InsertTrainerToACourse(int courseId, int trainerId)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO TrainersPerCourse (CourseId, TrainerId) " +
                    "VALUES(@courseId, @trainerId)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                    cmd.Parameters.Add(new SqlParameter("@trainerId", trainerId));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public bool InsertAssignmentToACourse(int courseId, int assignmentId)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO AssignmentsPerCourse (CourseId, AssignmentId) " +
                    "VALUES(@courseId, @assignmentId)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                    cmd.Parameters.Add(new SqlParameter("@assignmentId", assignmentId));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public bool InsertAssignmentOfACourseAndItsMarksForAStudent(int studentId, int courseId, int assignmentId, double studentsOralMark, double studentsTotalMark)
        {
            int rows_affected = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO AssignmentsPerCoursePerStudent (StudentId, CourseId, AssignmentId, StudentsOralMark, StudentsTotalMark) " +
                    "VALUES(@studentId, @courseId, @assignmentId, @studentsOralMark, @studentsTotalMark)", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@studentId", studentId));
                    cmd.Parameters.Add(new SqlParameter("@courseId", courseId));
                    cmd.Parameters.Add(new SqlParameter("@assignmentId", assignmentId));
                    cmd.Parameters.Add(new SqlParameter("@studentsOralMark", studentsOralMark));
                    cmd.Parameters.Add(new SqlParameter("@studentsTotalMark", studentsTotalMark));
                    try
                    {
                        rows_affected = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SqlTypeException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return rows_affected == 1;
        }

        public List<Student> SelectAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students ORDER BY StudentId;", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                students.Add(new Student((int)reader["StudentId"], (string)reader["FirstName"], (string)reader["LastName"], (DateTime)reader["DateOfBirth"], Convert.ToDecimal(reader["TuitionFees"])));
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return students;
        }

        public List<Trainer> SelectAllTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Trainers ORDER BY TrainerId;", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                trainers.Add(new Trainer((int)reader["TrainerId"], (string)reader["FirstName"], (string)reader["LastName"], (string)reader["Subject"]));
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return trainers;
        }

        public List<Assignment> SelectAllAssignments()
        {
            List<Assignment> assignments = new List<Assignment>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Assignments ORDER BY AssignmentId", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                assignments.Add(new Assignment((int)reader["AssignmentId"], (string)reader["Title"],
                                    (string)reader["Description"], (DateTime)reader["SubDateTime"], (double)reader["OralMark"], (double)reader["TotalMark"]));
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return assignments;
        }

        public List<Course> SelectAllCourses()
        {
            List<Course> courses = new List<Course>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses ORDER BY CourseId;", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StreamValue stream;
                                TypeValue type;
                                string value = (string)reader["Stream"];
                                if (value.Equals("C#"))
                                {
                                    stream = StreamValue.CSharp;
                                }
                                else
                                {
                                    stream = StreamValue.Java;
                                }
                                value = (string)reader["Type"];
                                if (value.Equals("Full-Time"))
                                {
                                    type = TypeValue.Full_Time;
                                }
                                else
                                {
                                    type = TypeValue.Part_Time;
                                }
                                courses.Add(new Course((int)reader["CourseId"], (string)reader["Title"], stream, type, (DateTime)reader["StartDate"], (DateTime)reader["EndDate"]));
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return courses;
        }

        public List<StudentsPerCourse> SelectAllStudentsPerCourse()
        {
            List<StudentsPerCourse> studentsPerCourseList = new List<StudentsPerCourse>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT StudentsPerCourse.CourseId, Courses.Title, Courses.Stream, Courses.Type, Courses.StartDate, Courses.EndDate, " +
                                                       "StudentsPerCourse.StudentId, Students.FirstName, Students.LastName, Students.DateOfBirth, Students.TuitionFees" +
                                                       " FROM Students INNER JOIN StudentsPerCourse ON Students.StudentId = StudentsPerCourse.StudentId" +
                                                       " INNER JOIN Courses ON StudentsPerCourse.CourseId = Courses.CourseId" +
                                                       " ORDER BY StudentsPerCourse.CourseId, StudentsPerCourse.StudentId; ", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int courseId = 0; // initialize this to 0 since CourseId starts from 1
                            Course course = null;
                            Student student;
                            while (reader.Read())
                            {
                                // Since rows are coming ordered by CourseId we create new course entry in studentsPerCourseList only when we find a CourseId different than the one we have already
                                if (courseId != (int)reader["CourseId"])
                                {
                                    courseId = (int)reader["CourseId"];
                                    StreamValue stream;
                                    TypeValue type;
                                    string value = (string)reader["Stream"];
                                    if (value.Equals("C#"))
                                    {
                                        stream = StreamValue.CSharp;
                                    }
                                    else
                                    {
                                        stream = StreamValue.Java;
                                    }
                                    value = (string)reader["Type"];
                                    if (value.Equals("Full-Time"))
                                    {
                                        type = TypeValue.Full_Time;
                                    }
                                    else
                                    {
                                        type = TypeValue.Part_Time;
                                    }
                                    course = new Course((int)reader["CourseId"], (string)reader["Title"], stream, type, (DateTime)reader["StartDate"], (DateTime)reader["EndDate"]);
                                    studentsPerCourseList.Add(new StudentsPerCourse(course));
                                }
                                student = new Student((int)reader["StudentId"], (string)reader["FirstName"], (string)reader["LastName"], (DateTime)reader["DateOfBirth"], Convert.ToDecimal(reader["TuitionFees"]));
                                // Students are added always in the course entry that equals current course instance since they come ordered by course
                                if (studentsPerCourseList.Find(x => x.Course.Equals(course)) != null) 
                                {
                                    studentsPerCourseList.Find(x => x.Course.Equals(course)).AddStudent(student);
                                }
                                else
                                {
                                    throw new NullReferenceException("Course not found.");
                                }
                                
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return studentsPerCourseList;
        }

        public List<TrainersPerCourse> SelectAllTrainersPerCourse()
        {
            List<TrainersPerCourse> trainersPerCourseList = new List<TrainersPerCourse>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TrainersPerCourse.CourseId, Courses.Title, Courses.Stream, Courses.Type, Courses.StartDate, Courses.EndDate, " +
                                                       "TrainersPerCourse.TrainerId, Trainers.FirstName, Trainers.LastName, Trainers.Subject" +
                                                       " FROM Trainers INNER JOIN TrainersPerCourse ON Trainers.TrainerId = TrainersPerCourse.TrainerId" +
                                                       " INNER JOIN Courses ON TrainersPerCourse.CourseId = Courses.CourseId" +
                                                       " ORDER BY TrainersPerCourse.CourseId, TrainersPerCourse.TrainerId; ", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int courseId = 0; // initialize this to 0 since CourseId starts from 1
                            Course course = null;
                            Trainer trainer;
                            while (reader.Read())
                            {                                    
                                // Since rows are coming ordered by CourseId we create new course entry in trainersPerCourseList only when we find a CourseId different than the one we have already
                                if (courseId != (int)reader["CourseId"])
                                {
                                    courseId = (int)reader["CourseId"];
                                    StreamValue stream;
                                    TypeValue type;
                                    string value = (string)reader["Stream"];
                                    if (value.Equals("C#"))
                                    {
                                        stream = StreamValue.CSharp;
                                    }
                                    else
                                    {
                                        stream = StreamValue.Java;
                                    }
                                    value = (string)reader["Type"];
                                    if (value.Equals("Full-Time"))
                                    {
                                        type = TypeValue.Full_Time;
                                    }
                                    else
                                    {
                                        type = TypeValue.Part_Time;
                                    }
                                    course = new Course((int)reader["CourseId"], (string)reader["Title"], stream, type, (DateTime)reader["StartDate"], (DateTime)reader["EndDate"]);
                                    trainersPerCourseList.Add(new TrainersPerCourse(course));
                                }
                                trainer = new Trainer((int)reader["TrainerId"], (string)reader["FirstName"], (string)reader["LastName"], (string)reader["Subject"]);
                                // Trainers are added always in the course entry that equals current course instance since they come ordered by course
                                if (trainersPerCourseList.Find(x => x.Course.Equals(course)) != null)
                                {
                                    trainersPerCourseList.Find(x => x.Course.Equals(course)).AddTrainer(trainer);
                                }
                                else 
                                {
                                    throw new NullReferenceException("Course not found.");
                                }
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return trainersPerCourseList;
        }

        public List<AssignmentsPerCourse> SelectAllAssignmentsPerCourse()
        {
            List<AssignmentsPerCourse> assignmentsPerCourseList = new List<AssignmentsPerCourse>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT AssignmentsPerCourse.CourseId, Courses.Title AS CourseTitle, Courses.Stream, Courses.Type, Courses.StartDate, Courses.EndDate," +
                                                       " AssignmentsPerCourse.AssignmentId, Assignments.Title AS AssignmentTitle, Assignments.Description, " +
                                                       "Assignments.SubDateTime, Assignments.OralMark, Assignments.TotalMark" +
                                                       " FROM Assignments INNER JOIN AssignmentsPerCourse ON Assignments.AssignmentId = AssignmentsPerCourse.AssignmentId" +
                                                       " INNER JOIN Courses ON AssignmentsPerCourse.CourseId = Courses.CourseId" +
                                                       " ORDER BY AssignmentsPerCourse.CourseId, AssignmentsPerCourse.AssignmentId; ", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int courseId = 0; // initialize this to 0 since CourseId starts from 1
                            Course course = null;
                            Assignment assignment;
                            while (reader.Read())
                            {
                                // Since rows are coming ordered by CourseId we create new course entry in assignmentsPerCourseList only when we find a CourseId different than the one we have already
                                if (courseId != (int)reader["CourseId"])
                                {
                                    courseId = (int)reader["CourseId"];
                                    StreamValue stream;
                                    TypeValue type;
                                    string value = (string)reader["Stream"];
                                    if (value.Equals("C#"))
                                    {
                                        stream = StreamValue.CSharp;
                                    }
                                    else
                                    {
                                        stream = StreamValue.Java;
                                    }
                                    value = (string)reader["Type"];
                                    if (value.Equals("Full-Time"))
                                    {
                                        type = TypeValue.Full_Time;
                                    }
                                    else
                                    {
                                        type = TypeValue.Part_Time;
                                    }
                                    course = new Course((int)reader["CourseId"], (string)reader["CourseTitle"], stream, type, (DateTime)reader["StartDate"], (DateTime)reader["EndDate"]);
                                    assignmentsPerCourseList.Add(new AssignmentsPerCourse(course));
                                }
                                assignment = new Assignment((int)reader["AssignmentId"], (string)reader["AssignmentTitle"], (string)reader["Description"], (DateTime)reader["SubDateTime"], (double)reader["OralMark"], (double)reader["TotalMark"]);
                                // Assignments are added always in the course entry that equals current course instance since they come ordered by course
                                if (assignmentsPerCourseList.Find(x => x.Course.Equals(course)) != null)
                                {
                                    assignmentsPerCourseList.Find(x => x.Course.Equals(course)).AddAssignment(assignment);
                                }
                                else
                                {
                                    throw new NullReferenceException("Course not found.");
                                }
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return assignmentsPerCourseList;
        }

        public List<AssignmentsPerCoursePerStudent> SelectAllAssignmentsPerCoursePerStudent()
        {
            List<AssignmentsPerCoursePerStudent> assignmentsPerCoursePerStudentList = new List<AssignmentsPerCoursePerStudent>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT AssignmentsPerCoursePerStudent.StudentId, Students.FirstName, Students.LastName, Students.DateOfBirth, Students.TuitionFees, " +
                                                       "AssignmentsPerCoursePerStudent.CourseId, Courses.Title AS CourseTitle, Courses.Stream, Courses.Type, Courses.StartDate, Courses.EndDate, " +
                                                       "AssignmentsPerCoursePerStudent.AssignmentId, Assignments.Title AS AssignmentTitle, Assignments.Description, Assignments.SubDateTime," +
                                                       " AssignmentsPerCoursePerStudent.StudentsOralMark, AssignmentsPerCoursePerStudent.StudentsTotalMark" +
                                                       " FROM Assignments INNER JOIN AssignmentsPerCoursePerStudent ON Assignments.AssignmentId = AssignmentsPerCoursePerStudent.AssignmentId " +
                                                       "INNER JOIN Courses ON AssignmentsPerCoursePerStudent.CourseId = Courses.CourseId" +
                                                       " INNER JOIN Students ON AssignmentsPerCoursePerStudent.StudentId = Students.StudentId" +
                                                       " ORDER BY AssignmentsPerCoursePerStudent.StudentId, AssignmentsPerCoursePerStudent.CourseId, AssignmentsPerCoursePerStudent.AssignmentId; ", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            int courseId = 0; // initialize this to 0 since CourseId starts from 1
                            int studentId = 0; // initialize this to 0 since StudentId starts from 1
                            Course course = null;
                            Assignment assignment;
                            Student student = null;
                            while (reader.Read())
                            {
                                // Since rows are coming ordered first by StudentId we create new student entry in assignmentsPerCoursePerStudentList only when we find a StudentId different than the one we have already
                                if (studentId != (int)reader["StudentId"])
                                {
                                    studentId = (int)reader["StudentId"];
                                    student = new Student((int)reader["StudentId"], (string)reader["FirstName"], (string)reader["LastName"], (DateTime)reader["DateOfBirth"], Convert.ToDecimal(reader["TuitionFees"]));
                                    assignmentsPerCoursePerStudentList.Add(new AssignmentsPerCoursePerStudent(student));
                                    courseId = 0;
                                }
                                // Since rows are coming ordered secondly by CourseId we add a new course entry in assignmentsPerCourseList for the current student only when we find a CourseId different than the one we have already
                                if (courseId != (int)reader["CourseId"])
                                {
                                    courseId = (int)reader["CourseId"];
                                    StreamValue stream;
                                    TypeValue type;
                                    string value = (string)reader["Stream"];
                                    if (value.Equals("C#"))
                                    {
                                        stream = StreamValue.CSharp;
                                    }
                                    else
                                    {
                                        stream = StreamValue.Java;
                                    }
                                    value = (string)reader["Type"];
                                    if (value.Equals("Full-Time"))
                                    {
                                        type = TypeValue.Full_Time;
                                    }
                                    else
                                    {
                                        type = TypeValue.Part_Time;
                                    }
                                    course = new Course((int)reader["CourseId"], (string)reader["CourseTitle"], stream, type, (DateTime)reader["StartDate"], (DateTime)reader["EndDate"]);
                                    // Find the student entry in assignmentsPerCoursePerStudentList which equals current student and add a new AssignmentsPerCourseList entry for the newly created course
                                    if (assignmentsPerCoursePerStudentList.Find(x => x.Student.Equals(student)) != null)
                                    {
                                        assignmentsPerCoursePerStudentList.Find(x => x.Student.Equals(student)).AddNewAssignmentsPerCourseList(course);
                                    }
                                    else
                                    {
                                        throw new NullReferenceException("Student not found.");
                                    }
                                }
                                assignment = new Assignment((int)reader["AssignmentId"], (string)reader["AssignmentTitle"], (string)reader["Description"], (DateTime)reader["SubDateTime"], (double)reader["StudentsOralMark"], (double)reader["StudentsTotalMark"]);
                                // Add the newly created Assignment to the AssignmentsPerCourse list for the current course for the current student
                                if (assignmentsPerCoursePerStudentList.Find(x => x.Student.Equals(student)) != null)
                                {
                                    assignmentsPerCoursePerStudentList.Find(x => x.Student.Equals(student)).AddAssignmentOfACourseToStudent(course, assignment);
                                }
                                else
                                {
                                    throw new NullReferenceException("Student not found.");
                                }
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return assignmentsPerCoursePerStudentList;
        }

        public List<Student> SelectAllStudentsBelongingToManyCourses()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Students s WHERE StudentId IN " +
                                                       "(SELECT StudentId FROM StudentsPerCourse " +
                                                       "GROUP BY StudentId " +
                                                       "HAVING COUNT(CourseId) > 1)" +
                                                       "ORDER BY StudentId;", conn))
                {
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                students.Add(new Student((int)reader["StudentId"], (string)reader["FirstName"], (string)reader["LastName"], (DateTime)reader["DateOfBirth"], Convert.ToDecimal(reader["TuitionFees"])));
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return students;
        }
    }
}
