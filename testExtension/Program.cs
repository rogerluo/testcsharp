using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testExtension;

namespace testExtension
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> ps = new List<Person> ( 
                new Person[]{
                    new Person{Name = "Roger", Age = 23, ID = 100},
                    new Person{Name = "Dingjia", Age = 25, ID = 90},
                    new Person{Name = "razor", Age = 24, ID = 110},
                }
            );
            foreach (var p in ps) {
                Console.WriteLine("{0}, {1}, {2}", p.Name, p.Age, p.ID);
            }

            foreach (var p in ps.AsQueryable().OrderBy("Name")) {
                Console.WriteLine("{0}, {1}, {2}", p.Name, p.Age, p.ID);
            }
        }
    }
}
