using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;
using WebApiExample.Repositories;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET api/persons
        [HttpGet]
        public ActionResult<List<Person>> GetPersons()
        {
            /*  var users = new List<Person>
              {
                  new Person("James", 45),
                  new Person("Lisa", 65)
              }; */
            var persons = _personRepository.Read();
            return new JsonResult(persons);
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _personRepository.Read(id);
            return new JsonResult(person);
        }

        // POST api/persons
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personRepository.Create(person);
            return new JsonResult(newPerson);
        }

        // PUT api/persons/5
        [HttpPut]
        public ActionResult<Person> Put(int id, Person person)
        {
            var updatedPerson = _personRepository.Update(id, person);
            return new JsonResult(updatedPerson);
        }

        // DELETE api/persons
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personRepository.Delete(id);
            return new OkResult();
        }
    }
}