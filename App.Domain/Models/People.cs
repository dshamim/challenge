using System.Collections.Generic;

namespace App.Domain.Models
{
    public class People
    {
        public class Person
        {
            public string name { get; set; }
            public string gender { get; set; }
            public int age { get; set; }
            public List<Pet> pets { get; set; }
        }

        public class Pet
        {
            public string name { get; set; }
            public string type { get; set; }
        }

    }

}