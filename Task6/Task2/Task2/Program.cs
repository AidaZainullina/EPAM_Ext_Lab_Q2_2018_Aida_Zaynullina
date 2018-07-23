namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public delegate void Greeting(Person person, TimeSpan time);

    public delegate void Farewell(Person person);

    public class Program
    {
        public static void Main(string[] args)
        {
            Office office = new Office();
            Person john = new Person("John");
            Person bill = new Person("Bill");
            Person hugo = new Person("Hugo");

            office.AppearenceOfAPerson(john, new TimeSpan(10, 00, 00));
            office.AppearenceOfAPerson(bill, new TimeSpan(12, 00, 00));
            office.AppearenceOfAPerson(hugo, new TimeSpan(17, 00, 00));

            office.OutAPerson(john);
            office.OutAPerson(bill);
            office.OutAPerson(hugo);

            Console.ReadLine();
        }
    }
}
