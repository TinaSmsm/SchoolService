using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService
{
    public class Student
    {
        private string _FirtstName;
        private string _LastName;
        private string _Email;

        public string FirtstName
        {
            get { return _FirtstName; }
            set { _FirtstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
    }
}
