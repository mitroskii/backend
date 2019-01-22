﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Repositories
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        void Delete(int id);
    }
}
