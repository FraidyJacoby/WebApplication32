using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication32.Models;
using WebApplication32.Data;

namespace WebApplication32.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People;Integrated Security=True";
        
        public IActionResult Index()
        {
            PersonDb db = new PersonDb(_connectionString);
            PeopleViewModel vm = new PeopleViewModel
            {
                People = db.GetPeople()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddPeople(List<Person> ppl)
        {
            PersonDb db = new PersonDb(_connectionString);
            foreach (Person person in ppl)
            {
                db.AddPerson(person);
            }
            return Redirect("/");
        }

        public IActionResult AddPeople()
        {
            return View();
        }
    }
}
