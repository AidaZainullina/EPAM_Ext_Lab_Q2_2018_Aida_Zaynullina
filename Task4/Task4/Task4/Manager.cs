namespace Task4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Manager
    {
        private int id;
        private string name;
        private string email;
        private string password;
        private string phone;
        
        public Programmer Programmer
        {
            get => default(Programmer);
            set
            {
            }
        }

        public Task Task
        {
            get => default(Task);
            set
            {
            }
        }
        
        public Report Report
        {
            get => default(Report);
            set
            {
            }
        }

        public TestAssessment TestResult
        {
            get => default(TestAssessment);
            set
            {
            }
        }

        public void Register()
        {
            throw new System.NotImplementedException();
        }

        public void LogIn()
        {
            throw new System.NotImplementedException();
        }

        public void AddProfilePhoto()
        {
            throw new System.NotImplementedException();
        }

        public void EditProfileInfo()
        {
            throw new System.NotImplementedException();
        }

        public void GetProgrammerInfo()
        {
            throw new System.NotFiniteNumberException();
        }

        public void GetInfoOfAllProgrammers()
        {
            throw new System.NotFiniteNumberException();
        }

        public void OpenParagraph()
        {
            throw new System.NotImplementedException();
        }

        public void OpenSubparagraph()
        {
            throw new System.NotImplementedException();
        }

        public void TestAssessment()
        {
            throw new System.NotImplementedException();
        }

        public void GetAssessment()
        {
            throw new System.NotFiniteNumberException();
        }

        public void CreateAReport()
        {
            throw new System.NotFiniteNumberException();
        }

        public void EditAReport()
        {
            throw new System.NotFiniteNumberException();
        }
    }
}
