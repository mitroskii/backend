﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersondbContext _context;

        public PersonRepository(PersondbContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            var deletedPerson = Read(id);
            _context.Remove(deletedPerson);
            _context.SaveChanges();
            return;
        }

        public List<Person> Read()
        {
            // SELECT * FROM PERSON;
            return _context.Person
                .Include(p=>p.Phone)
                .ToList();
        }

        public Person Read(int id)
        {
            //SELECT * FROM PERSON WHERE ID={id};
            return _context.Person
                .Include(p=>p.Phone)
                .FirstOrDefault(p =>p.Id==id);
        }

        public Person Update(Person person)
        {
                _context.Update(person);
                _context.SaveChanges();
                return person;
            }
        }
    }
}
