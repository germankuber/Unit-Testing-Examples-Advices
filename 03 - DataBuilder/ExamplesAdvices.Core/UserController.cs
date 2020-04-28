using System;

namespace ExamplesAdvices.Core
{
    public class UserController
    {
        private readonly IUserServices _userServices;
        private readonly IEncryption _encryption;

        public UserController(IUserServices userServices, IEncryption encryption)
        {
            _userServices = userServices;
            _encryption = encryption;
        }

        public bool Login(UserProfile user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
                return false;
            if (_encryption.Encrypt(user.Password) == _encryption.Encrypt(user.RePassword))
                return _userServices.Login(user);
            return false;
        }
    }
}
