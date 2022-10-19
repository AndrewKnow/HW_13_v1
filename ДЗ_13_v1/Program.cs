using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ДЗ_13_v1
{
    public class Program
    {
        static void Main()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            list.Top(30);

            var personList = new List<Person>()
            {
                new Person() { Age = 10 },
                new Person() { Age = 20 },
                new Person() { Age = 30 },
                new Person() { Age = 40 },
                new Person() { Age = 50 },
                new Person() { Age = 60 },
                new Person() { Age = 70 },
                new Person() { Age = 80 },
                new Person() { Age = 90 }
            };

            personList.Top(30, person => person.Age);

        }
    }
}


