using OnlineCollegeAdmission.DAL;
using OnlineCollegeAdmission.Entity;

namespace OnlineCollegeAdmission.BL
{
    public interface IUserBL
    {
        string Login(string EmailId, string password);
        bool SignUp(User user);
    }
    public class UserBL : IUserBL
    {
        IUserRepository userRepository;
        public UserBL()
        {
            userRepository = new UserRepository();
        }
        public string Login(string EmailId, string password)
        {
            return userRepository.Login(EmailId, password);
        }
        public bool SignUp(User user)
        {
            return userRepository.SignUp(user);
        }
    }
}
