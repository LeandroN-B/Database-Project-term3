using System;

namespace Database_Project_LMB.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public int RoomID { get; set; }


        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - DateOfBirth.Year;
                if (DateTime.Now < DateOfBirth.AddYears(age)) age--; // Adjust for birthdate not reached
                return age;
            }
        }

        public DateTime DateOfBirth { get; set; }  // Must be added in the database
    }
}
