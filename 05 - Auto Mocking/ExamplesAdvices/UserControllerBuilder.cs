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
        private IFixture _fixture;
        internal UserControllerBuilder()
        {
            _fixture = new Fixture()
               .Customize(new AutoMoqCustomization());
            //Install-Package AutoFixture -Version 4.11.0
            //Install-Package AutoFixture.AutoMoq -Version 4.11.0
            //TODO : 01 - Freeze Autofixture Moq
            UserService = _fixture.Freeze<Mock<IUserServices>>();
            EmailService = _fixture.Freeze<Mock<IEmailService>>();

            Encryption = _fixture.Freeze<Mock<IEncryption>>();
        }

        internal UserControllerBuilder WithEmailService(IEmailService emailService)
        {
            _fixture.Inject(emailService);
            return this;
        }
        internal UserControllerBuilder WithEncryptService(IEncryption encryption)
        {
            _fixture.Inject(encryption);
            return this;
        }
        internal UserControllerBuilder WithUserService(IUserServices userServices)
        {
            _fixture.Inject(userServices);
            return this;
        }
        internal UserControllerBuilder WithRealServices(IUserServices userServices,
            IEncryption encryption)
        {
            return this;
        }

        internal UserController Build()
        {
            //TODO: 02 - Utilizo los objetos freeze
            return _fixture.Create<UserController>();
        }
    }
}