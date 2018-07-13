namespace Task4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Role
    {
        private int id;
        private string name;
        private string permision;

        public Programmer Programmer
        {
            get => default(Programmer);
            set
            {
            }
        }

        public Manager Manager
        {
            get => default(Manager);
            set
            {
            }
        }

        public Admin Admin
        {
            get => default(Admin);
            set
            {
            }
        }
    }
}
