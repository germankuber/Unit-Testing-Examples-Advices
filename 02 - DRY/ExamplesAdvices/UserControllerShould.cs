using System;
using ExamplesAdvices.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace ExamplesAdvices.Tests
{
    public class UserControllerShould : IDisposable
    {
        private readonly Mock<IEncryption> _encryption;
        private readonly Mock<IUserServices> _userService;
        private readonly Mock<IEmailService> _emailService;
        private readonly UserProfile _userTest;

        //TODO : 01 - Implicit Setup
        public UserControllerShould()
        {
            _userService = new Mock<IUserServices>();
            _emailService = new Mock<IEmailService>();
            _encryption = new Mock<IEncryption>();
            _userTest = new UserProfile(
                userName: "userName",
                lastName: "LastName",
                firstName: "FirstName",
                password: "Password",
                rePassword: "Password");
        }
        [Fact]
        public void Return_True_User_Logged_Successfully()
        {
            //TODO: 04 - Utilizo el Mother OBject
            var sut = CreateSutWithRealDependencies();

            var result = sut.Login(_userTest);

            result.Should().BeTrue();

        }

        [Fact]
        public void Return_False_User_Does_Not_Logged_Successfully()
        {
            var sut = CreateSutWithRealDependencies();

            _userTest.RePassword = "Re Password";

            var result = sut.Login(_userTest);

            result.Should().BeFalse();

        }
        [Fact]
        public void Return_False_User_Does_Not_Logged_Does_Not_Have_FirstName_LastName()
        {
            var sut = CreateSut();

            var user = new UserProfile
            {
                UserName = "userName",
                Password = "Password",
                RePassword = "Re Password"
            };

            var result = sut.Login(user);

            result.Should().BeFalse();

        }

        public void Dispose()
        {
            //TODO : 01 - Implemento Dispose
        }

        //TODO : 03 - Mother Objects
        private UserController CreateSutWithRealDependencies() =>
            new UserController(new UserServices(new EmailService()), new ReverseEncryption());

        private UserController CreateSutWithRealDependenciesWithoutEmail() =>
            new UserController(new UserServices(_emailService.Object), new ReverseEncryption());

        private UserController CreateSut() =>
            new UserController(_userService.Object, _encryption.Object);
    }
}
