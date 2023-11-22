using CyclistClubMembershipApplication.FieldValidators;
using CyclistMembershipApplication.Data;
using CyclistMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CyclistClubMembershipApplication.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;
            using (var dbContext = new ClubMembershipDBContext())
            {
                
            }
            return true;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new ClubMembershipDBContext())
            {
                var user = new User
                {
                    Email = fields[(int)FieldConstants.UserRegistrationFields.EmailAddress],
                    FirstName = fields[(int)FieldConstants.UserRegistrationFields.FirstName],
                    LastName = fields[(int)FieldConstants.UserRegistrationFields.LastName],
                    PhoneNumber = fields[(int)FieldConstants.UserRegistrationFields.PhoneNumber],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldConstants.UserRegistrationFields.DateOfBirth])
                };

                dbContext.Add(user);
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}