namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        public event Greeting OnCame;

        public event Farewell OnOut;

        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public void ComingTime(TimeSpan time)
        {
            this.OnCame?.Invoke(this, time);

            Console.WriteLine("\n");
        }

        public void OutTime(TimeSpan time)
        {
            this.OnCame?.Invoke(this, time);

            Console.WriteLine("\n");
        }

        private enum Time : int
        {
            OneHourOfNight = 1,
            Noon = 12,
            StartEvening = 17,
            Midnight = 24
        }

        public void Welcome(Person person, TimeSpan time)
        {
            var phrase = string.Empty;
            if ((time.Hours >= (int)Time.OneHourOfNight) && (time.Hours <= (int)Time.Midnight))
            {
                if (time.Hours < (int)Time.Noon)
                {
                    phrase = Properties.Resources.GM;
                }
                
                if ((time.Hours >= (int)Time.Noon) && (time.Hours < (int)Time.StartEvening))
                {
                    phrase = Properties.Resources.GA;
                }

                if (time.Hours >= (int)Time.StartEvening) 
                {
                    phrase = Properties.Resources.GE;
                }
            }
            else
            {
                phrase = Properties.Resources.H;
            }

            Console.WriteLine("'{0}, {1}!', - {2} {3}", phrase, person.Name, this.Name, Properties.Resources.said);
        }

        public void Farewell(Person person)
        {
            Console.WriteLine("'Goodbye, {0}!', - {1}  {2}", person.Name, this.Name, Properties.Resources.said);
        }

        public void Exit()
        {
            if (this.OnOut != null)
            {
                this.OnOut(this);
                Console.WriteLine("\n");
            }
        }
    }
}
