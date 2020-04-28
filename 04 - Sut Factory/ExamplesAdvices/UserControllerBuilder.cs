using ExamplesAdvices.Core;
using Moq;

namespace ExamplesAdvices.Tests
{
    public class UserControllerBuilder
    {
        //TODO: 01 - Implemento BUilder
        private IEncryption _encryption;
        private IUserServices _userService;
        private IEmailService _emailService;
        internal UserControllerBuilder()
        {
            _userService = new Mock<IUserServices>().Object;
            _emailService = new Mock<IEmailService>().Object;
            _encryption = new Mock<IEncryption>().Object;
        }

        internal UserControllerBuilder WithEmailService(IEmailService emailService)
        {
            _emailService = emailService;
            return this;
        }
        internal UserControllerBuilder WithEncryptService(IEncryption encryption)
        {
            _encryption = encryption;
            return this;
        }
        internal UserControllerBuilder WithUserService(IUserServices userServices)
        {
            _userService = userServices;
            return this;
        }
        internal UserControllerBuilder WithRealServices(IUserServices userServices,
            IEncryption encryption)
        {
            _encryption = encryption;
            _userService = userServices;
            return this;
        }
        internal UserController Build() =>
            new UserController(_userService, _encryption);
    }
}