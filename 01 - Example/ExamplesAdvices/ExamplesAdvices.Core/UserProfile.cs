namespace ExamplesAdvices.Core
{
    public class UserProfile
    {

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public UserProfile(string userName, string firstName, string lastName, string password, string rePassword)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            RePassword = rePassword;
        }

        public UserProfile()
        {

        }

    }
}