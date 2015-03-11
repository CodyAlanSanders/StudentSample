using StudentExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentExample.Service
{
    public class StudentService
    {
        private static List<Student> students;
        static StudentService() {
            students = populateStudents();
        }
        public void resetService() {
            students = populateStudents();
        }

        public List<Student> getStudents() {
            return students;
        }
        public void updateStudent(Student student) {
            removeStudent(student);
            addStudent(student);
        }

        public Student getStudent(int id) {
            Student foundStudent = new Student();
            foreach (Student student in students) {
                if (student.StudentID==id) {
                    foundStudent = student;
                }
            }
            return foundStudent;
        }

        public void removeStudent(Student s) {
            //todo: refactor this with get by id and them removing later
            Student student = getStudent(s.StudentID);
            students.Remove(student);
        }

        public void addStudent(Student s) {
            int max = 0;
            if (s.StudentID == 0){
                //find max student id
                foreach (Student student in students)
                {
                    if (student.StudentID > max)
                    {
                        max = student.StudentID;
                    }
                }
                s.StudentID = max + 1;
            }
            //add student
            students.Add(s);
        }

        private static List<Student> populateStudents()
        {
            List<Student> students = new List<Student>();
            Student s1 = new Student();
            s1.Address = "123 North Street";
            s1.Age = 21;
            s1.City = "Louisville";
            s1.Email = "newdude@email.com";
            s1.Name = "New Dude";
            s1.StudentID = 1;
            s1.Zip = "12345";
            students.Add(s1);

            Student s2 = new Student()
            {
                Address = "123 My Other Address",
                Age = 34,
                City = "MountainView",
                Email = "wannabe@eamil.com",
                Name = "Big Dawg",
                Phone = "123123333",
                State = "CA",
                StudentID = 2,
                Zip = "12345"
            };
            students.Add(s2);

            Student s3 = new Student()
            {
                Address = "123 My Other Address",
                Age = 34,
                City = "MountainView",
                Email = "wily@eamil.com",
                Name = "Wily Wes",
                Phone = "123123333",
                State = "CA",
                StudentID = 3,
                Zip = "12345"
            };
            students.Add(s3);
            return students;
        }
    }
}