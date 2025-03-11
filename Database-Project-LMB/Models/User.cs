using Microsoft.AspNetCore.Mvc;

namespace Database_Project_LMB.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }

        public User(int userID, string userName, string mobileNumber,
                    string email)
        {
            UserID = userID;
            UserName = userName;
            MobileNumber = mobileNumber;
            Email = email;
        }
    }
}
