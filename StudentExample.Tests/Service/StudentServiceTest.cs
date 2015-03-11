using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentExample.Models;
using System.Collections.Generic;
using StudentExample.Service;

namespace StudentExample.Tests.Service
{
    [TestClass]
    public class StudentServiceTest
    {
        [TestMethod]
        public void getList()
        {
            StudentService service = new StudentService();
            service.resetService();
            List<Student> students = service.getStudents();
            Assert.IsNotNull(students);
            Assert.AreEqual(3, students.Count);
        }

        [TestMethod]
        public void getStudent() {
            StudentService service = new StudentService();
            service.resetService();
            Student student = service.getStudent(1);
            Assert.IsNotNull(student);
            Assert.AreEqual("New Dude", student.Name);
            Assert.AreEqual("newdude@email.com", student.Email);
        }

        [TestMethod]
        public void createStudent() {
            Student s1 = new Student()
            {
                Address = "123 My Other Address",
                Age = 34,
                City = "MountainView",
                Email = "hello@eamil.com",
                Name = "Hello Dawg",
                Phone = "123123333",
                State = "CA",
                Zip = "12345"
            };
            StudentService service = new StudentService();
            List<Student> students = service.getStudents();
            Assert.IsNotNull(students);
            Assert.AreEqual(3, students.Count);
            service.addStudent(s1);

            students = null;
            students = service.getStudents();
            Assert.IsNotNull(students);
            Assert.AreNotEqual(0, students[3].StudentID);
            Assert.AreEqual(4, students[3].StudentID);
            Assert.AreEqual(4, students.Count);
            Assert.AreEqual("Hello Dawg", students[3].Name);
        }

        [TestMethod]
        public void createStudent1()
        {
            Student s1 = new Student()
            {
                Address = "123 My Other Address",
                Age = 34,
                City = "MountainView",
                Email = "hello@eamil.com",
                Name = "Hello Dawg",
                Phone = "123123333",
                State = "CA",
                StudentID=89,
                Zip = "12345"
            };
            StudentService service = new StudentService();
            service.resetService();
            List<Student> students = service.getStudents();
            Assert.IsNotNull(students);
            Assert.AreEqual(3, students.Count);
            service.addStudent(s1);

            students = null;
            students = service.getStudents();
            Assert.IsNotNull(students);
            Assert.AreNotEqual(0, students[3].StudentID);
            Assert.AreEqual(89, students[3].StudentID);
            Assert.AreEqual(4, students.Count);
            Assert.AreEqual("Hello Dawg", students[3].Name);
        }


        [TestMethod]
        public void removeStudent()
        {
            StudentService service = new StudentService();
            service.resetService();
            List<Student> students = service.getStudents();
            Assert.IsNotNull(students);
            Assert.AreEqual(3, students.Count);

            service = new StudentService();
            service.removeStudent(students[0]);

            students = service.getStudents();
            Assert.IsNotNull(students);
            Assert.AreEqual(2, students.Count);
        }
    }
}
