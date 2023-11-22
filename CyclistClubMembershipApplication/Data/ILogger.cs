
using CyclistMembershipApplication.Models;

namespace CyclistClubMembershipApplication.Data
{
    public interface ILogger
    {
        User Login(string emailAddress, string password);
        bool EmailExists(string emailAddress);
    }
}