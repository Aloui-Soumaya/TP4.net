using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp4.Models;

namespace tp4.Controllers
{
    public class PersonController : Controller
    {
        [Route("Person/")]
        public ActionResult allviews()
        {
            Personal_info personal_Info = new Personal_info();

            return View(personal_Info.GetAllPerson());
        }
        [Route("Person/{id:int}")]
        public ActionResult index(int id)
        {
            Personal_info personal_Info = new Personal_info();

            return View(personal_Info.GetPerson(id));
        }
        
        
        [HttpPost]
        public ActionResult serchPerson(String first_name, String country)
        {
            Personal_info personal_info = new Personal_info();
            List<Person> personlist = personal_info.GetAllPerson();
            foreach (Person person in personlist)
            {
                if (person.first_name == first_name && person.country == country)
                {
                    return Redirect(person.id.ToString());

                }
            }
            ViewBag.notFound = true;
            return View();
        }
        [HttpGet]
        public ActionResult serchPerson()
        {
            ViewBag.notFound = false;
            return View();
        }

    }
}