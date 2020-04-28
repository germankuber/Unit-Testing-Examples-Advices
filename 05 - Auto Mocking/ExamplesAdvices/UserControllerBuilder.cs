using AutoFixture;
using AutoFixture.AutoMoq;
using ExamplesAdvices.Core;
using Moq;

namespace ExamplesAdvices.Tests
{
    public class UserControllerBuilder
    {
        public Mock<IEncryption> Encryption;
        public Mock<IUserServices> UserService;
        public Mock<IEmailService> EmailService;
        private IEncryption _realEncryption;
        private IUserServices _realUserServices;
        private IEmailService _realEmailService;

        internal UserControllerBuilder()
        {
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
            //Install-Package AutoFixture -Version 4.11.0
            //Install-Package AutoFixture.AutoMoq -Version 4.11.0
            //TODO : 01 - Freeze Autofixture Moq
            UserService = fixture.Freeze<Mock<IUserServices>>();
            EmailService = fixture.Freeze<Mock<IEmailService>>();
            Encryption = fixture.Freeze<Mock<IEncryption>>();
        }

        internal UserControllerBuilder WithEmailService(IEmailService emailService)
        {
            _realEmailService = emailService;
            return this;
        }
        internal UserControllerBuilder WithEncryptService(IEncryption encryption)
        {
            _realEncryption = encryption;
            return this;
        }
        internal UserControllerBuilder WithUserService(IUserServices userServices)
        {
            _realUserServices = userServices;
            return this;
        }
        internal UserControllerBuilder WithRealServices(IUserServices userServices,
            IEncryption encryption)
        {
            _realUserServices = userServices;
            _realEncryption = encryption;
            return this;
        }

        internal UserController Build()
        {
            //TODO: 02 - Utilizo los objetos freeze
            var userService = _realUserServices ?? UserService.Object;
            var encryption = _realEncryption ?? Encryption.Object;
            return new UserController(userService, encryption);
        }
    }
}