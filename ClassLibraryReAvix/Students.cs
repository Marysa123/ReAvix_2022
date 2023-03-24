using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryReAvix
{
    public class Students
    {
        public string s_FirstName { get; set; }
        public string s_LastName { get; set; }
        public string s_MiddleName { get; set; }
        public DateTime s_Birthday { get; set; }
        public string s_PhoneNumber { get; set; }
        public string s_EmailAddress { get; set; }
        public byte s_Course { get; set; }

        public Students()
        {

        }
        //public Students(string Firstname,string Lastname,string MiddleName,DateTime Birthday, string PhoneNumber,string EmailAddress, byte Course)
        //{
        //    s_FirstName = Firstname;
        //    s_LastName = Lastname;
        //    s_MiddleName = MiddleName;
        //    s_Birthday = Birthday;
        //    s_PhoneNumber= PhoneNumber;
        //    s_EmailAddress = EmailAddress;
        //    s_Course = Course;
        //}

        public void Validity_of_the_Name(string Firstname, string Lastname, string MiddleName)
        {
            if (Firstname.Length >= 20 && Lastname.Length >= 20 && MiddleName.Length >= 20)
            {
                throw new DivideByZeroException();
            }
            
        }
    }
}
