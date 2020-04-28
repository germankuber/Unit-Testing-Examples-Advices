namespace ExamplesAdvices.Core
{
    public class UserServices : IUserServices
    {
        private readonly IEmailService _emailService;

        public UserServices(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public UserServices()
        {
            
        }
        public bool Login(UserProfile user)
        {
            if (user.Password == user.RePassword)
                return true;
            return false;
        }
    }
}