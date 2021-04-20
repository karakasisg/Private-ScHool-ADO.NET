using System;
using System.Collections.Generic;

namespace PrivateSchoolDatabase
{
    class PrivateSchool
    {
        public readonly string Name; // Name of the private school

        public PrivateSchool(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "The name of the school cannot be null or empty!");
            }
            Name = name;
        }
        
        // Inserts a new course to the database
        private void InsertACourse(DbManager db)
        {
            Course course = new Course();
            InsertCourseData(course);
            Console.WriteLine();
            List<Course> courses = db.SelectAllCourses();
            // Check if the course already exists in the database
            if (courses.Contains(course))
            {
                Console.WriteLine("This course already exists. No insertion will happen.");
            }
            else
            {
                if (db.InsertCourse(course))
                {
                    Console.WriteLine("The course has been successfully inserted.");
                }
                else
                {
                    Console.WriteLine("The insertion failed. Please check data and try again.");
                }
            }
            Console.WriteLine();
        }

        // Inserts a new trainer to the database
        private void InsertATrainer(DbManager db)
        {
            Trainer trainer = new Trainer();
            InsertTrainerData(trainer);
            Console.WriteLine();
            List<Trainer> trainers = db.SelectAllTrainers();
            // Check if the trainer already exists in the database
            if (trainers.Contains(trainer))
            {
                Console.WriteLine("This trainer already exists. No insertion will happen.");
            }
            else
            {
                if (db.InsertTrainer(trainer))
                {
                    Console.WriteLine("The trainer has been successfully inserted.");
                }
                else
                {
                    Console.WriteLine("The insertion failed. Please check data and try again.");
                }
            }
            Console.WriteLine();
        }

        // Inserts a new student to the database
        private void InsertAStudent(DbManager db)
        {
            Student student = new Student();
            InsertStudentData(student);
            Console.WriteLine();
            List<Student> students = db.SelectAllStudents();
            // Check if the student already exists in the database
            if (students.Contains(student))
            {
                Console.WriteLine("This student already exists. No insertion will happen.");
            }
            else
            {
                if (db.InsertStudent(student))
                {
                    Console.WriteLine("The student has been successfully inserted.");
                }
                else
                {
                    Console.WriteLine("The insertion failed. Please check data and try again.");
                }
            } 
            Console.WriteLine();
        }

        // Inserts a new assignment to the database
        private void InsertAnAssignment(DbManager db) 
        {
            Assignment assignment = new Assignment();
            InsertAssignmentData(assignment);
            Console.WriteLine();
            List<Assignment> assignments = db.SelectAllAssignments();
            // Check if the assignment already exists in the database
            if (assignments.Contains(assignment))
            {
                Console.WriteLine("This assignment already exists. No insertion will happen.");
            }
            else
            {
                if (db.InsertAssignment(assignment))
                {
                    Console.WriteLine("The assignment has been successfully inserted.");
                }
                else
                {
                    Console.WriteLine("The insertion failed. Please check data and try again.");
                }
            } 
            Console.WriteLine();
        }

        // Inserts a student to a course to the database
        private void InsertAStudentToACourse(DbManager db)
        {
            List<Student> students = db.SelectAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students have been inserted yet in the database to insert to a course.");
            }
            else
            {
                Console.WriteLine("Please type the StudentId of the student from the below table you want to insert to a course or type 0 to exit if the student you want does not appear in the table.");
                Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", "StudentId", "First Name", "Last Name", "Date Of Birth", "Tuition Fees");
                // List all the students already existing in database for the user to choose
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine();
                int studentId;
                while (true)
                {
                    Console.Write("Your choice: ");
                    while (!int.TryParse(Console.ReadLine(), out studentId))
                    {
                        Console.WriteLine("You did not give a number");
                        Console.Write("Your choice: ");
                    }
                    if (studentId == 0) // In case student has not been inserted in database, exit
                    {
                        Console.WriteLine();
                        return;
                    }
                    else if (!students.Exists(x => x.StudentId == studentId)) // In case user gives invalid StudentId, write message and ask for it again
                    {
                        Console.WriteLine("The id you gave does not exist. Please choose again.");
                    }
                    else
                    {
                        break;
                    }
                }
                List<Course> courses = db.SelectAllCourses();
                Console.WriteLine();
                if (courses.Count == 0)
                {
                    Console.WriteLine("No courses have been inserted yet in the database to insert the student to.");
                }
                else
                {
                    Console.WriteLine("Please type the CourseId of the course from the below table where you want to insert the chosen student or type 0 if the course you want does not appear in the table.");
                    Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                    // List all the courses already existing in database for the user to choose
                    foreach (Course course in courses)
                    {
                        Console.WriteLine(course);
                    }
                    Console.WriteLine();
                    int courseId;
                    while (true)
                    {
                        Console.Write("Your choice: ");
                        while (!int.TryParse(Console.ReadLine(), out courseId))
                        {
                            Console.WriteLine("You did not give a number");
                            Console.Write("Your choice: ");
                        }
                        if (courseId == 0) // In case course has not been inserted in database, exit
                        {
                            Console.WriteLine();
                            return;
                        }
                        else if (!courses.Exists(x => x.CourseId == courseId)) // In case user gives invalid CourseId, write message and ask for it again
                        {
                            Console.WriteLine("The id you gave does not exist. Please choose again.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine();
                    List<StudentsPerCourse> studentsPerCourse = db.SelectAllStudentsPerCourse();
                    // Check if the chosen student already exists in the chosen course. In this case no insertion happens.
                    if (studentsPerCourse.Exists(x => x.Course.CourseId == courseId && x.StudentsListExistsStudentWithId(studentId)))
                    {
                        Console.WriteLine("The student you have chosen already exists in this course. No insertion will happen.");
                    }
                    else
                    {
                        if (db.InsertStudentToACourse(courseId, studentId))
                        {
                            Console.WriteLine("The student has been successfully inserted to the course.");
                            List<AssignmentsPerCourse> assignmentsPerCourse = db.SelectAllAssignmentsPerCourse();
                            // Check if the chosen course has assignments
                            if (assignmentsPerCourse.Exists(x => x.Course.CourseId == courseId))
                            {
                                // Inform the user and ask to insert marks of student for the assignments now or later
                                Console.Write("The selected course includes assignments. Do you want to provide the student's marks for them now or will you do it later? Type \"now\" to do it now or anything else to do it later: ");
                                string input = Console.ReadLine();
                                if (input.Equals("now"))
                                {
                                    // Get the assignmentsList for the chosen course
                                    AssignmentsPerCourse listOfAssignments = assignmentsPerCourse.Find(x => x.Course.CourseId == courseId);
                                    for (int i = 0; i < listOfAssignments.GetAssignmentsListSize(); i++)
                                    {
                                        // Show assignment's info and ask user for the student's marks for it
                                        Assignment assignment = listOfAssignments.GetAssignmentFromList(i);
                                        Console.WriteLine("{0, -14} {1, -30} {2, -84} {3, -21} {4, -21} {5, -19}", "AssignmentId", "Title", "Description", "Submission Date Time", "Max Oral Mark", "Max Total Mark");
                                        Console.WriteLine(assignment);
                                        while (true)
                                        {
                                            Console.WriteLine();
                                            double studentsOralMark;
                                            Console.Write("Give the Student's Oral Mark for the above assignment: ");
                                            while (!double.TryParse(Console.ReadLine(), out studentsOralMark) || studentsOralMark < 0 || studentsOralMark > assignment.OralMark)
                                            {
                                                Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's maximum Oral Mark -> {0}!", assignment.OralMark);
                                                Console.Write("Give the Student's Oral Mark for the above assignment: ");
                                            }
                                            double studentsTotalMark;
                                            Console.Write("Give the Student's Total Mark for the above assignment: ");
                                            while (!double.TryParse(Console.ReadLine(), out studentsTotalMark) || studentsTotalMark < 0 || studentsTotalMark > assignment.TotalMark - (assignment.OralMark - studentsOralMark))
                                            {
                                                Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's possible maximum Total Mark with the above Oral Mark -> {0}!", assignment.TotalMark - (assignment.OralMark - studentsOralMark));
                                                Console.Write("Give the Student's Total Mark for the above assignment: ");
                                            }
                                            Console.WriteLine();
                                            if (db.InsertAssignmentOfACourseAndItsMarksForAStudent(studentId, courseId, assignment.AssignmentId, studentsOralMark, studentsTotalMark))
                                            {
                                                Console.WriteLine("The assignment and its marks have been successfully stored");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("The insertion failed. Please check data and try again.");
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The insertion failed. Please check data and try again.");
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        // Inserts a trainer to a course to the database
        private void InsertATrainerToACourse(DbManager db)
        {
            List<Trainer> trainers = db.SelectAllTrainers();
            if (trainers.Count == 0)
            {
                Console.WriteLine("No trainers have been inserted yet in the database to add to a course.");
            }
            else
            {

                Console.WriteLine("Please type the TrainerId of the trainer from the below table you want to insert to a course or type 0 if the trainer you want does not appear in the table.");
                Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -52}", "TrainerId", "First Name", "Last Name", "Subject");
                // List all the trainers already existing in database for the user to choose
                foreach (Trainer trainer in trainers)
                {
                    Console.WriteLine(trainer);
                }
                Console.WriteLine();
                int trainerId;
                while (true)
                {
                    Console.Write("Your choice: ");
                    while (!int.TryParse(Console.ReadLine(), out trainerId))
                    {
                        Console.WriteLine("You did not give a number");
                        Console.Write("Your choice: ");
                    }
                    if (trainerId == 0) // In case trainer has not been inserted in database, exit
                    {
                        Console.WriteLine();
                        return;
                    }
                    else if (!trainers.Exists(x => x.TrainerId == trainerId)) // In case user gives invalid TrainerId, write message and ask for it again
                    {
                        Console.WriteLine("The id you gave does not exist. Please choose again.");
                    }
                    else
                    {
                        break;
                    }
                }
                List<Course> courses = db.SelectAllCourses();
                Console.WriteLine();
                if (courses.Count == 0)
                {
                    Console.WriteLine("No courses have been inserted yet in the database to insert the trainer to.");
                }
                else
                {
                    Console.WriteLine("Please type the CourseId of the course from the below table where you want to insert the chosen trainer.");
                    Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                    // List all the courses already existing in database for the user to choose
                    foreach (Course course in courses)
                    {
                        Console.WriteLine(course);
                    }
                    Console.WriteLine();
                    int courseId;
                    while (true)
                    {
                        Console.Write("Your choice: ");
                        while (!int.TryParse(Console.ReadLine(), out courseId))
                        {
                            Console.WriteLine("You did not give a number");
                            Console.Write("Your choice: ");
                        }
                        if (courseId == 0) // In case course has not been inserted in database, exit
                        {
                            Console.WriteLine();
                            return;
                        }
                        else if (!courses.Exists(x => x.CourseId == courseId)) // In case user gives invalid CourseId, write message and ask for it again
                        {
                            Console.WriteLine("The id you gave does not exist. Please choose again.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine();
                    List<TrainersPerCourse> trainersPerCourse = db.SelectAllTrainersPerCourse();
                    // Check if the chosen trainer already exists in the chosen course. In this case no insertion happens.
                    if (trainersPerCourse.Exists(x => x.Course.CourseId == courseId && x.TrainersListExistsTrainerWithId(trainerId)))
                    {
                        Console.WriteLine("The trainer you have chosen already exists in this course. No insertion will happen.");
                    }
                    else
                    {
                        if (db.InsertTrainerToACourse(courseId, trainerId))
                        {
                            Console.WriteLine("The trainer has been successfully inserted to the course.");
                        }
                        else
                        {
                            Console.WriteLine("The insertion failed. Please check data and try again.");
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        // Inserts an assignment to a course to the database
        private void InsertAnAssignmentToACourse(DbManager db)
        {
            List<Assignment> assignments = db.SelectAllAssignments();
            if (assignments.Count == 0)
            {
                Console.WriteLine("No assignments have been inserted yet in the database to add to a course.");
            }
            else
            {
                Console.WriteLine("Please type the AssignmentId of the assignment from the below table you want to insert to a course or type 0 to exit if the assignment you want does not appear in the table.");
                Console.WriteLine("{0, -14} {1, -30} {2, -84} {3, -21} {4, -21} {5, -19}", "AssignmentId", "Title", "Description", "Submission Date Time", "Oral Mark", "Total Mark");
                // List all the assignments already existing in database for the user to choose
                foreach (Assignment assignment in assignments)
                {
                    Console.WriteLine(assignment);
                }
                Console.WriteLine();
                int assignmentId;
                while (true)
                {
                    Console.Write("Your choice: ");
                    while (!int.TryParse(Console.ReadLine(), out assignmentId))
                    {
                        Console.WriteLine("You did not give a number");
                        Console.Write("Your choice: ");
                    }
                    if (assignmentId == 0) // In case assignment has not been inserted in database, exit
                    {
                        Console.WriteLine();
                        return;
                    }
                    else if (!assignments.Exists(x => x.AssignmentId == assignmentId)) // In case user gives invalid AssignmentId, write message and ask for it again
                    {
                        Console.WriteLine("The id you gave does not exist. Please choose again.");
                    }
                    else
                    {
                        break;
                    }
                }
                List<Course> courses = db.SelectAllCourses();
                Console.WriteLine();
                if (courses.Count == 0)
                {
                    Console.WriteLine("No courses have been inserted yet in the database to insert the assignment to.");
                }
                else
                {
                    Console.WriteLine("Please type the CourseId of the course from the below table where you want to insert the chosen student or type 0 if the course you want does not appear in the table.");
                    Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                    foreach (Course course in courses)
                    {
                        Console.WriteLine(course);
                    }
                    Console.WriteLine();
                    int courseId;
                    while (true)
                    {
                        Console.Write("Your choice: ");
                        while (!int.TryParse(Console.ReadLine(), out courseId))
                        {
                            Console.WriteLine("You did not give a number");
                            Console.Write("Your choice: ");
                        }
                        if (courseId == 0) // In case course has not been inserted in database, exit
                        {
                            Console.WriteLine();
                            return;
                        }
                        else if (!courses.Exists(x => x.CourseId == courseId)) // In case user gives invalid CourseId, write message and ask for it again
                        {
                            Console.WriteLine("The id you gave does not exist. Please choose again.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine();
                    List<AssignmentsPerCourse> assignmentsPerCourse = db.SelectAllAssignmentsPerCourse();
                    // Check if the chosen assignment already exists in the chosen course. In this case no insertion happens.
                    if (assignmentsPerCourse.Exists(x => x.Course.CourseId == courseId && x.AssignmentsListExistsAssignmentWithId(assignmentId)))
                    {
                        Console.WriteLine("The assignment you have chosen already exists in this course. No insertion will happen.");
                    }
                    else
                    {
                        if (db.InsertAssignmentToACourse(courseId, assignmentId))
                        {
                            Console.WriteLine("The assignment has been successfully inserted to the course.");
                            List<StudentsPerCourse> studentsPerCourse = db.SelectAllStudentsPerCourse();
                            // Check if the chosen course has students
                            if (studentsPerCourse.Exists(x => x.Course.CourseId == courseId))
                            {
                                // Inform the user and ask to insert marks of the students for the assignment now or later
                                Console.Write("The selected course includes students attending it. Do you want to provide the student's marks for this assignment now or will you do it later? Type \"now\" to do it now or anything else to do it later: ");
                                string input = Console.ReadLine();
                                if (input.Equals("now"))
                                {
                                    // Get the studentsList for the chosen course
                                    StudentsPerCourse listOStudents = studentsPerCourse.Find(x => x.Course.CourseId == courseId);
                                    Assignment assignment = assignments.Find(x => x.AssignmentId == assignmentId);
                                    for (int i = 0; i < listOStudents.GetStudentsListSize(); i++)
                                    {
                                        // Show student's info and ask user for the assignment's marks for him/her
                                        Student student = listOStudents.GetStudentFromList(i);
                                        Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", "StudentId", "First Name", "Last Name", "Date Of Birth", "Tuition Fees");
                                        Console.WriteLine(student);
                                        while (true)
                                        {
                                            Console.WriteLine();
                                            double studentsOralMark;
                                            Console.Write("Give the Student's Oral Mark for the above assignment: ");
                                            while (!double.TryParse(Console.ReadLine(), out studentsOralMark) || studentsOralMark < 0 || studentsOralMark > assignment.OralMark)
                                            {
                                                Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's maximum Oral Mark -> {0}!", assignment.OralMark);
                                                Console.Write("Give the Student's Oral Mark for the above assignment: ");
                                            }
                                            double studentsTotalMark;
                                            Console.Write("Give the Student's Total Mark for the above assignment: ");
                                            while (!double.TryParse(Console.ReadLine(), out studentsTotalMark) || studentsTotalMark < 0 || studentsTotalMark > assignment.TotalMark - (assignment.OralMark - studentsOralMark))
                                            {
                                                Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's possible maximum Total Mark with the above Oral Mark -> {0}!", assignment.TotalMark - (assignment.OralMark - studentsOralMark));
                                                Console.Write("Give the Student's Total Mark for the above assignment: ");
                                            }
                                            Console.WriteLine();
                                            if (db.InsertAssignmentOfACourseAndItsMarksForAStudent(student.StudentId, courseId, assignmentId, studentsOralMark, studentsTotalMark))
                                            {
                                                Console.WriteLine("The assignment and its marks have been successfully stored");
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("The insertion failed. Please check data and try again.");
                                            }
                                        }
                                        Console.WriteLine();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("The insertion failed. Please check data and try again.");
                        }
                    }
                }
            }
            Console.WriteLine();
        }

        // Inserts an assignment of a course and its marks for a student to the database
        private void InsertAnAssignmentAndMarksOfStudentForACourse(DbManager db)
        {
            List<Student> students = db.SelectAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students have been inserted yet to insert their marks for an assignment.");
            }
            else
            {
                Console.WriteLine("Please type the StudentId of the student from the below table you want to insert his/her marks for an assignment or type 0 to exit if the student you want does not appear in the table.");
                Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", "StudentId", "First Name", "Last Name", "Date Of Birth", "Tuition Fees");
                // List all students already existing in database for the user to choose
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine();
                int studentId;
                while (true)
                {
                    Console.Write("Your choice: ");
                    while (!int.TryParse(Console.ReadLine(), out studentId))
                    {
                        Console.WriteLine("You did not give a number");
                        Console.Write("Your choice: ");
                    }
                    if (studentId == 0) // In case student has not been inserted in database, exit
                    {
                        Console.WriteLine();
                        return;
                    }
                    else if (!students.Exists(x => x.StudentId == studentId)) // In case user gives invalid StudentId, write message and ask for it again
                    {
                        Console.WriteLine("The id you gave does not exist. Please choose again.");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine();
                // Get the list of courses where the chosen student belongs to
                List<StudentsPerCourse> courses = db.SelectAllStudentsPerCourse().FindAll(x => x.StudentsListExistsStudentWithId(studentId));
                if (courses.Count != 0)
                {
                    Console.WriteLine("Below you can see all the courses the student you have chosen belongs to.");
                    Console.WriteLine("Please type the CourseId of the course from the below table where belongs the assignment its marks you will enter or type 0 if the course you want does not appear in the table.");
                    Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                    // Output these courses to user
                    foreach (StudentsPerCourse course in courses)
                    {
                        Console.WriteLine(course.Course);
                    }
                    Console.WriteLine();
                    int courseId;
                    while (true)
                    {
                        Console.Write("Your choice: ");
                        while (!int.TryParse(Console.ReadLine(), out courseId))
                        {
                            Console.WriteLine("You did not give a number");
                            Console.Write("Your choice: ");
                        }
                        if (courseId == 0) // In case course has not been inserted in database, exit
                        {
                            Console.WriteLine();
                            return;
                        }
                        else if (!courses.Exists(x => x.Course.CourseId == courseId)) // In case user gives invalid CourseId, write message and ask for it again
                        {
                            Console.WriteLine("The id you gave does not exist. Please choose again.");
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.WriteLine();
                    // Get the list of assignments for the chosen course
                    AssignmentsPerCourse assignments = db.SelectAllAssignmentsPerCourse().Find(x => x.Course.CourseId == courseId);
                    if (assignments != null && assignments.GetAssignmentsListSize() != 0)
                    {
                        Console.WriteLine("Below you can see all the assignments that belong to the above course for the student you have chosen.");
                        Console.WriteLine("Please type the AssignmentId of the assignment from the below table whose marks you will enter or type 0 if the assignment you want does not appear in the table.");
                        Console.WriteLine("{0, -14} {1, -30} {2, -84} {3, -21} {4, -21} {5, -19}", "AssignmentId", "Title", "Description", "Submission Date Time", "Max Oral Mark", "Max Total Mark");
                        // Output these assignments
                        for (int i = 0; i < assignments.GetAssignmentsListSize(); i++)
                        {
                            Console.WriteLine(assignments.GetAssignmentFromList(i));
                        }
                        Console.WriteLine();
                        int assignmentId;
                        while (true)
                        {
                            Console.Write("Your choice: ");
                            while (!int.TryParse(Console.ReadLine(), out assignmentId))
                            {
                                Console.WriteLine("You did not give a number");
                                Console.Write("Your choice: ");
                            }
                            if (assignmentId == 0) // In case assignment has not been inserted in database, exit
                            {
                                Console.WriteLine();
                                return;
                            }
                            else if (!assignments.AssignmentsListExistsAssignmentWithId(assignmentId)) // In case user gives invalid AssignmentId, write message and ask for it again
                            {
                                Console.WriteLine("The id you gave does not exist. Please choose again.");
                            }
                            else
                            {
                                break;
                            }
                        }
                        Console.WriteLine();
                        List<AssignmentsPerCoursePerStudent> assignmentsPerCoursePerStudent = db.SelectAllAssignmentsPerCoursePerStudent();
                        // If the marks for this assignment for this course for this student have already been given no insertion will happen. Inform user about it.
                        if (assignmentsPerCoursePerStudent.Exists(x => x.Student.StudentId == studentId && x.AssignmentsPerCourseListExistsAssignmentWithId(courseId, assignmentId)))
                        {
                            Console.WriteLine("The student's marks for this assignment and this course already have been inserted. No insertion will happen.");
                        }
                        else
                        {
                            // Get the assignment from assignmentsList because its info is needed
                            Assignment assignment = assignments.GetAssignmentFromListWithId(assignmentId);
                            // Ask user for the student's marks for this assignment
                            double studentsOralMark;
                            Console.Write("Give the Student's Oral Mark for the above assignment: ");
                            while (!double.TryParse(Console.ReadLine(), out studentsOralMark) || studentsOralMark < 0 || studentsOralMark > assignment.OralMark)
                            {
                                Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's maximum Oral Mark -> {0}!", assignment.OralMark);
                                Console.Write("Give the Student's Oral Mark for the above assignment: ");
                            }
                            double studentsTotalMark;
                            Console.Write("Give the Student's Total Mark for the above assignment: ");
                            while (!double.TryParse(Console.ReadLine(), out studentsTotalMark) || studentsTotalMark < 0 || studentsTotalMark > assignment.TotalMark - (assignment.OralMark - studentsOralMark))
                            {
                                Console.WriteLine("You did not gave a number or you gave a negative one or you gave a number greater than assignment's possible maximum Total Mark with the above Oral Mark -> {0}!", assignment.TotalMark - (assignment.OralMark - studentsOralMark));
                                Console.Write("Give the Student's Total Mark for the above assignment: ");
                            }
                            Console.WriteLine();
                            if (db.InsertAssignmentOfACourseAndItsMarksForAStudent(studentId, courseId, assignmentId, studentsOralMark, studentsTotalMark))
                            {
                                Console.WriteLine("The assignment and its marks have been successfully stored");
                            }
                            else
                            {
                                Console.WriteLine("The insertion failed. Please check data and try again.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The chosen course for this student has no assignments yet, thus the student cannot submit any assignments for it.");
                    }

                }
                else
                {
                    Console.WriteLine("The student chosen does not belong to any courses yet, thus cannot submit any assignments.");
                }
            }
            Console.WriteLine();
        }

        // Prints all students inserted by user
        private void ListAllStudentsInserted(DbManager db)
        {
            List<Student> students = db.SelectAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students have been inserted yet.");
            }
            else
            {
                Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", "StudentId", "First Name", "Last Name", "Date Of Birth", "Tuition Fees");
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
            }
            Console.WriteLine();
        }

        // Prints all trainers inserted by user
        private void ListAllTrainersInserted(DbManager db)
        {
            List<Trainer> trainers = db.SelectAllTrainers();
            if (trainers.Count == 0)
            {
                Console.WriteLine("No trainers have been inserted yet.");
            }
            else
            {
                Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -52}", "TrainerId", "First Name", "Last Name", "Subject");
                foreach(Trainer trainer in trainers)
                {
                    Console.WriteLine(trainer);
                }
            }
            Console.WriteLine();
        }

        // Prints all assignments inserted by user
        private void ListAllAssignmentsInserted(DbManager db)
        {
            List<Assignment> assignments = db.SelectAllAssignments();
            if (assignments.Count == 0)
            {
                Console.WriteLine("No assignments have been inserted yet.");
            }
            else
            {
                Console.WriteLine("{0, -14} {1, -30} {2, -84} {3, -21} {4, -21} {5, -19}", "AssignmentId", "Title", "Description", "Submission Date Time", "Oral Mark", "Total Mark");
                foreach(Assignment assignment in assignments)
                { 
                    Console.WriteLine(assignment);
                }
            }
            Console.WriteLine();
        }

        // Prints all courses inserted by user
        private void ListAllCoursesInserted(DbManager db)
        {
            List<Course> courses = db.SelectAllCourses();
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses have been inserted yet.");
            }
            else
            {
                Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                foreach(Course course in courses)
                { 
                    Console.WriteLine(course);
                }
            }
            Console.WriteLine();
        }

        // Prints all students per course
        private void ListAllStudentsPerCourse(DbManager db)
        {
            List<StudentsPerCourse> studentsPerCourse = db.SelectAllStudentsPerCourse();
            if (studentsPerCourse.Count == 0)
            {
                Console.WriteLine("No students have been inserted to any courses.");
                Console.WriteLine();
            }
            else
            {
                // Get the list of all courses existing in database
                List<Course> courses = db.SelectAllCourses();
                foreach (Course course in courses)
                {
                    Console.WriteLine("Course info:");
                    Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                    Console.WriteLine(course);
                    // If a course does not exist in studentsPerCourse list, it means no students are attending it, so inform the user for it
                    if (!studentsPerCourse.Exists(x => x.Course.Equals(course)))
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tNo students attend the above course.");
                    }
                    // else list the students' info for the course
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tBelow you can see the students' info for the above course:");
                        Console.WriteLine("\t{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", "StudentId", "First Name", "Last Name", "Date Of Birth", "Tuition Fees");
                        studentsPerCourse.Find(x => x.Course.Equals(course)).ListStudents();
                    }
                    Console.WriteLine();
                }
            }
        }

        // Prints all trainers per course
        private void ListAllTrainersPerCourse(DbManager db)
        {
            List<TrainersPerCourse> trainersPerCourse = db.SelectAllTrainersPerCourse();
            if (trainersPerCourse.Count == 0)
            {
                Console.WriteLine("No trainers have been inserted to any courses.");
                Console.WriteLine();
            }
            else
            {
                // Get the list of all courses existing in database
                List<Course> courses = db.SelectAllCourses();
                foreach (Course course in courses)
                {
                    Console.WriteLine("Course info:");
                    Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                    Console.WriteLine(course);
                    // If a course does not exist in trainersPerCourse list, it means no trainers are teaching in it, so inform the user for it
                    if (!trainersPerCourse.Exists(x => x.Course.Equals(course)))
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tNo trainers teach in the above course.");
                    }
                    // else list trainers' info for the course
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tBelow you can see the trainers' info for the above course:");
                        Console.WriteLine("\t{0, -11} {1, -22} {2, -32} {3, -52}", "TrainerId", "First Name", "Last Name", "Subject");
                        trainersPerCourse.Find(x => x.Course.Equals(course)).ListTrainers();
                    }
                    Console.WriteLine();
                }
            }
        }

        // Prints all assignments per course
        private void ListAllAssignmentsPerCourse(DbManager db)
        {
            List<AssignmentsPerCourse> assignmentsPerCourse = db.SelectAllAssignmentsPerCourse();
            if (assignmentsPerCourse.Count == 0)
            {
                Console.WriteLine("No assignments have been inserted to any courses.");
                Console.WriteLine();
            }
            else
            {
                // Get the list of all courses existing in database
                List<Course> courses = db.SelectAllCourses();
                foreach (Course course in courses)
                {
                    Console.WriteLine("Course info:");
                    Console.WriteLine("{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                    Console.WriteLine(course);
                    // If a course does not exist in assignmentsPerCourse list, it means no assignments belong to it, so inform the user for it
                    if (!assignmentsPerCourse.Exists(x => x.Course.Equals(course)))
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tNo assignments belong to the above course.");
                    }
                    // else list assignments' info for the course
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tBelow you can see the assignments' info for the above course:");
                        Console.WriteLine("\t{0, -14} {1, -30} {2, -84} {3, -21} {4, -21} {5, -19}", "AssignmentId", "Title", "Description", "Submission Date Time", "Oral Mark", "Total Mark");
                        assignmentsPerCourse.Find(x => x.Course.Equals(course)).ListAssignments();
                    }
                    Console.WriteLine();
                }
            }
        }

        // Prints all assignments per student
        private void ListAllAssignmentsPerCoursePerStudent(DbManager db)
        {
            List<AssignmentsPerCoursePerStudent> assignmentsPerCoursePerStudent = db.SelectAllAssignmentsPerCoursePerStudent();
            List<Student> students = db.SelectAllStudents();
            List<StudentsPerCourse> studentsPerCourse = db.SelectAllStudentsPerCourse();
            if (students.Count == 0)
            {
                Console.WriteLine("No students have been inserted yet in the database, so no assignments have been submitted yet.");
                Console.WriteLine();
            }
            else 
            {
                foreach (Student student in students)
                {
                    // Output student's info
                    Console.WriteLine("Student info:");
                    Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", "StudentId", "First Name", "Last Name", "Date Of Birth", "Tuition Fees");
                    Console.WriteLine(student);
                    Console.WriteLine();
                    // Get courses this student attend
                    List<StudentsPerCourse> courses = studentsPerCourse.FindAll(x => x.StudentsListContains(student));
                    // If the student attends no courses, obviously no assignments have been submitted it from him/her so inform the user for it
                    if (courses.Count == 0)
                    {
                        Console.WriteLine("\tThe above student attends no courses and thus has not submitted any assignments.");
                        Console.WriteLine();
                    }
                    else
                    {
                        // List all courses the student attends
                        foreach (StudentsPerCourse course in courses)
                        {
                            Console.WriteLine();
                            // Output course's info
                            Console.WriteLine("\tThe above student attends the below course:");
                            Console.WriteLine("\tCourse info:");
                            Console.WriteLine("\t{0, -10} {1, -32} {2, -8} {3, -11} {4, -12} {5, -10}", "CourseId", "Title", "Stream", "Type", "Start Date", "End Date");
                            Console.WriteLine("\t" + course.Course);
                            // If the student is not included in assignmentsPerCoursePerStudent list, then either the course has no assignments or the student has not submitted any yet.
                            // There's all the case that the student is included in the list but because he has submitted assignments for another course.
                            // In both cases there are no assignments to show info for, so we inform the user.
                            if (assignmentsPerCoursePerStudent.Find(x => x.Student.Equals(student)) == null || !assignmentsPerCoursePerStudent.Find(x => x.Student.Equals(student)).AssignmentsPerCourseListContainsCourse(course.Course))
                            {
                                Console.WriteLine();
                                Console.WriteLine("\tThe course has no assignments belonging to it or the student above has not submitted any assignments for it yet.");
                            }
                            // Otherwise we output the assignments' info for the student for this course
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("\t\tBelow you can see the assignments' info the student has submitted for this course:");
                                Console.WriteLine("\t\t{0, -14} {1, -30} {2, -84} {3, -21} {4, -21} {5, -19}", "AssignmentId", "Title", "Description", "Submission Date Time", "Students Oral Mark", "Students Total Mark");
                                assignmentsPerCoursePerStudent.Find(x => x.Student.Equals(student)).ListAssignmentsOfACourse(course.Course);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        // Prints all students belonging to more than one courses
        private void ListAllStudentsBeloningToManyCourses(DbManager db)
        {
            List<Student> _studentsBelongingToManyCourses = db.SelectAllStudentsBelongingToManyCourses();
            if (_studentsBelongingToManyCourses.Count == 0)
            {
                Console.WriteLine("There are no students belonging to more than one courses.");
            }
            else
            {
                Console.WriteLine("{0, -11} {1, -22} {2, -32} {3, -15} {4, -14}", "StudentId", "First Name", "Last Name", "Date Of Birth", "Tuition Fees");
                foreach (Student student in _studentsBelongingToManyCourses)
                { 
                    Console.WriteLine(student);
                }
            }
            Console.WriteLine();
        }

        // Prints the menu of choices after data insertion
        private void PrintMenuOfChoices()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("Type 1 for a list of all the students.");
            Console.WriteLine("Type 2 for a list of all the trainers.");
            Console.WriteLine("Type 3 for a list of all the assignments.");
            Console.WriteLine("Type 4 for a list of all the courses.");
            Console.WriteLine("Type 5 for a list of all the students per course.");
            Console.WriteLine("Type 6 for a list of all the trainers per course.");
            Console.WriteLine("Type 7 for a list of all the assignments per course.");
            Console.WriteLine("Type 8 for a list of all the assignments per course per student.");
            Console.WriteLine("Type 9 for a list of students that belong to more than one courses.");
            Console.WriteLine("Type 10 to insert a student.");
            Console.WriteLine("Type 11 to insert a trainer.");
            Console.WriteLine("Type 12 to insert an assignment.");
            Console.WriteLine("Type 13 to insert a course.");
            Console.WriteLine("Type 14 to insert a student to a course.");
            Console.WriteLine("Type 15 to insert a trainer to a course.");
            Console.WriteLine("Type 16 to insert an assignment to a course.");
            Console.WriteLine("Type 17 to insert an assignment and its marks of a student for a course.");
            Console.WriteLine("Type 18 to clear console");
            Console.WriteLine("Type anything else to stop the execution of the program.");
        }

        // Implements the operation of the private school
        public void Run()
        {
            string connectionString = @"Data Source=GEORGE\SQLEXPRESS;Initial Catalog=PrivateSchool;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DbManager db = new DbManager(connectionString);
            string input;
            Console.WriteLine("Welcome to {0} School.", Name);
            Console.WriteLine();
            bool stop = false;
            do
            {
                // Print menu of choices
                PrintMenuOfChoices();
                Console.WriteLine();
                Console.Write("Your choice: ");
                input = Console.ReadLine();
                Console.WriteLine();
                // Do something depending user's choice
                switch (input)
                {
                    case "1":
                        {
                            ListAllStudentsInserted(db);
                            break;
                        }
                    case "2":
                        {
                            ListAllTrainersInserted(db);
                            break;
                        }
                    case "3":
                        {
                            ListAllAssignmentsInserted(db);
                            break;
                        }
                    case "4":
                        {
                            ListAllCoursesInserted(db);
                            break;
                        }
                    case "5":
                        {
                            ListAllStudentsPerCourse(db);
                            break;
                        }
                    case "6":
                        {
                            ListAllTrainersPerCourse(db);
                            break;
                        }
                    case "7":
                        {
                            ListAllAssignmentsPerCourse(db);
                            break;
                        }
                    case "8":
                        {
                            ListAllAssignmentsPerCoursePerStudent(db);
                            break;
                        }
                    case "9":
                        {
                            ListAllStudentsBeloningToManyCourses(db);
                            break;
                        }
                    case "10":
                        {
                            InsertAStudent(db);
                            break;
                        }
                    case "11":
                        {
                            InsertATrainer(db);
                            break;
                        }
                    case "12":
                        {
                            InsertAnAssignment(db);
                            break;
                        }
                    case "13":
                        {
                            InsertACourse(db);
                            break;
                        }
                    case "14":
                        {
                            InsertAStudentToACourse(db);
                            break;
                        }
                    case "15":
                        {
                            InsertATrainerToACourse(db);
                            break;
                        }
                    case "16":
                        {
                            InsertAnAssignmentToACourse(db);
                            break;
                        }
                    case "17":
                        {
                            InsertAnAssignmentAndMarksOfStudentForACourse(db);
                            break;
                        }
                    case "18":
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            stop = true;
                            break;
                        }
                }
            } while (!stop);

            Console.WriteLine("Press any key to exit the application.");
            Console.ReadKey();
        }

        private bool IsValidName(string name)
        {
            if (Char.IsLower(name[0]))
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void InsertHumanData(Human human, string identifier) // The parameter is needed in order to implement inheritance and print different messages depending class
        {
            string input;

            if (String.IsNullOrWhiteSpace(identifier))
            {
                throw new ArgumentNullException("identifier", "Identifier cannot be null or empty!");
            }
            do
            {
                Console.Write("Give the {0}'s First Name: ", identifier);
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("First Name cannot be empty");
                }
                else if (!IsValidName(input))
                {
                    Console.WriteLine("First Name must start with capital letter and contain only alphabet letters");
                }
                else
                {
                    human.FirstName = input;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the {0}'s Last Name: ", identifier);
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Last Name cannot be empty");
                }
                else if (!IsValidName(input))
                {
                    Console.WriteLine("Last Name must start with capital letter and contain only alphabet letters");
                }
                else
                {
                    human.LastName = input;
                    break;
                }
            } while (true);
        }

        private void InsertStudentData(Student student)
        {
            InsertHumanData(student, "Student");
            DateTime dateOfBirth;
            Console.Write("Give the Student's Date Of Birth: ");
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth) || dateOfBirth.CompareTo(DateTime.Now) > 0)
            {
                Console.WriteLine("You did not give a date or the date has not come yet!!");
                Console.Write("Give the Student's Date Of Birth: ");
            }
            student.DateOfBirth = dateOfBirth;
            decimal tuitionFees;
            Console.Write("Give the Student's Tuition Fees: ");
            while (!decimal.TryParse(Console.ReadLine(), out tuitionFees) || tuitionFees < 0)
            {
                Console.WriteLine("You did not give a number or you gave a negative one!!");
                Console.Write("Give the Student's Tuition Fees: ");
            }
            student.TuitionFees = tuitionFees;
        }

        private void InsertTrainerData(Trainer trainer)
        {
            InsertHumanData(trainer, "Trainer");
            string input;
            do
            {
                Console.Write("Give the Trainer's Subject: ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Trainer's subject cannot be empty");
                }
                else
                {
                    trainer.Subject = input;
                    break;
                }
            } while (true);
        }

        private void InsertCourseData(Course course)
        {
            string input;
            do
            {
                Console.Write("Give the Course's Title: ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Courses's title cannot be empty");
                }
                else
                {
                    course.Title = input;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the Course's Stream. Type 1 for C# or 2 for Java: ");
                input = Console.ReadLine();
                if (input != "1" && input != "2")
                {
                    Console.WriteLine("Wrong choice!");
                }
                else if (input == "1")
                {
                    course.Stream = StreamValue.CSharp;
                    break;
                }
                else
                {
                    course.Stream = StreamValue.Java;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the Course's Type. Type 1 for Full-Time or 2 for Part-Time: ");
                input = Console.ReadLine();
                if (input != "1" && input != "2")
                {
                    Console.WriteLine("Wrong choice!");
                }
                else if (input == "1")
                {
                    course.Type = TypeValue.Full_Time;
                    break;
                }
                else
                {
                    course.Type = TypeValue.Part_Time;
                    break;
                }
            } while (true);
            DateTime startDate;
            Console.Write("Give the Course's Start Date: ");
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("You did not give a date!!");
                Console.Write("Give the Course's Start Date: ");
            }
            course.StartDate = startDate;
            DateTime endDate;
            Console.Write("Give the Course's End Date: ");
            while (!DateTime.TryParse(Console.ReadLine(), out endDate) || endDate.CompareTo(course.StartDate) <= 0)
            {
                Console.WriteLine("You did not give a date or you gave a date earlier than or equal to the starting date of the course!!");
                Console.Write("Give the Course's End Date: ");
            }
            course.EndDate = endDate;
        }

        private void InsertAssignmentData(Assignment assignment)
        {
            string input;
            do
            {
                Console.Write("Give the Assignment's Title: ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Title cannot be empty");
                }
                else
                {
                    assignment.Title = input;
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Give the Assignment's Description: ");
                input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Description cannot be empty");
                }
                else
                {
                    assignment.Description = input;
                    break;
                }
            } while (true);
            DateTime subDateTime;
            Console.Write("Give the Assignment's Submission Date & Time: ");
            while (!DateTime.TryParse(Console.ReadLine(), out subDateTime))
            {
                Console.WriteLine("You did not give date or time correctly!!");
                Console.Write("Give the Assignment's Submission Date & Time: ");
            }
            assignment.SubDateTime = subDateTime;
            double oralMark;
            Console.Write("Give the Assignment's Oral Mark: ");
            while (!double.TryParse(Console.ReadLine(), out oralMark) || oralMark < 0)
            {
                Console.WriteLine("You did not gave a number or you gave a negative one!");
                Console.Write("Give the Assignment's Oral Mark: ");
            }
            assignment.OralMark = oralMark;
            double totalMark;
            Console.Write("Give the Assignment's Total Mark: ");
            while (!double.TryParse(Console.ReadLine(), out totalMark) || totalMark < 0)
            {
                Console.WriteLine("You did not gave a number or you gave a negative one!");
                Console.Write("Give the Assignment's Total Mark: ");
            }
            assignment.TotalMark = totalMark;
        }
    }
}




