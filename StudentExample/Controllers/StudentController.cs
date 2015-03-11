using StudentExample.Models;
using StudentExample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentExample.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentService service = new StudentService();
            List<Student> students = service.getStudents();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            StudentViewModel vm = new StudentViewModel();
            vm.States=getStates();
            return View(vm);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "StudentID,Name,Email,Age,Address,City,Zip,State")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StudentService service = new StudentService();
                    service.addStudent(student);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentService service = new StudentService();
            StudentViewModel vm = new StudentViewModel();
            vm.States = getStates();
            vm.Student = service.getStudent(id);
            return View(vm);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "StudentID,Name,Email,Age,Address,City,Zip,State")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StudentService service = new StudentService();
                    service.updateStudent(student);
                    return RedirectToAction("Index");
                }
                catch
                {
                    //failed to update
                    return View();
                }
            }
            else
            {
                //failed to update
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0) {
                return RedirectToAction("Index"); 
            }
            StudentService service = new StudentService();
            Student student = service.getStudent(id);
            service.removeStudent(student);
            return RedirectToAction("Index");
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private List<string> getStates()
        {
            List<String> states = new List<String>();
            states.Add("Alabama");
            states.Add("California");
            states.Add("Indiana");
            states.Add("Kentucky");
            states.Add("Texas");
            states.Add("Utah");

            return states;
        }
    }
}
