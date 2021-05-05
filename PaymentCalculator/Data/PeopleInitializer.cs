using PaymentCalculator.Models;
using System.Linq;

namespace PaymentCalculator.Data
{
    public class PeopleInitializer
    {
        public static void Initialize(SteeltoeContext context)
        {
            if (context.People.Any())
            {
                return;
            }

            var people = new Person[]
            {
                new Person{ID=1,FirstName="Fred",LastName="Flintstone"},
                new Person{ID=2,FirstName="Wilma",LastName="Flintstone"},
                new Person{ID=3,FirstName="Pebbles",LastName="Flintstone"},
                new Person{ID=4,FirstName="Barney",LastName="Rubble"},
                new Person{ID=5,FirstName="Betty",LastName="Rubble"},
                new Person{ID=6,FirstName="Bamm Bamm",LastName="Rubble"}
            };

            foreach (Person p in people)
            {
                context.People.Add(p);
            }
            context.SaveChanges();
        }
    }
}
