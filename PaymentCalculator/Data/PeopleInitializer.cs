using PaymentCalculator.Models;
using System.Linq;

namespace PaymentCalculator.Data
{
    public class PeopleInitializer
    {
        public static void Initialize(SteeltoeContext context)
        {
            context.Database.EnsureCreated();
            
            if (context.People.Any())
            {
                return;
            }

            var people = new Person[]
            {
                new Person{FirstName="Fred",LastName="Flintstone"},
                new Person{FirstName="Wilma",LastName="Flintstone"},
                new Person{FirstName="Pebbles",LastName="Flintstone"},
                new Person{FirstName="Barney",LastName="Rubble"},
                new Person{FirstName="Betty",LastName="Rubble"},
                new Person{FirstName="Bamm Bamm",LastName="Rubble"}
            };

            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
        }
    }
}
