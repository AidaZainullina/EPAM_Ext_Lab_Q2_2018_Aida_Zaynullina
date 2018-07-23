namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Office
    {
        private List<Person> people;

        public Office()
        {
            this.people = new List<Person>();
        }

        public void AppearenceOfAPerson(Person person, TimeSpan time)
        {
            Console.WriteLine("[{0} {1}]", person.Name, Properties.Resources.Came);
            foreach (var p in this.people)
            {
                person.OnCame += p.Welcome;
                person.OnOut += p.Farewell;
                p.OnOut += person.Farewell;
            }

            this.people.Add(person);
            person.ComingTime(time);
        }

        public void OutAPerson(Person person)
        {
            Console.WriteLine("[{0} {1}]", person.Name, Properties.Resources.Left);
            person.Exit();
            foreach (var p in this.people)
            {
                p.OnCame -= person.Welcome;
                p.OnOut -= person.Farewell;
            }

            this.people.Remove(person);
        }
    }
}
