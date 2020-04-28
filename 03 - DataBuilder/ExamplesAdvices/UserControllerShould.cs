using System;
using ExamplesAdvices.Core;
using FluentAssertions;
using Moq;
using Xunit;

namespace ExamplesAdvices.Tests
{
    //TODO : 00 - Implemento Builder
    public class UserControllerShould : IDisposable
    {
        private readonly Mock<IEncryption> _encryption;
        private readonly Mock<IUserServices> _userService;
        private readonly Mock<IEmailService> _emailService;


        public UserControllerShould()
        {
            _userService = new Mock<IUserServices>();
            _emailService = new Mock<IEmailService>();
            _encryption = new Mock<IEncryption>();
            //TODO : 01 - Contruyo en métodos
            //_userTest = new UserProfile(
            //    userName: "userName",
            //    lastName: "LastName",
            //    firstName: "FirstName",
            //    password: "Password",
            //    rePassword: "Password");
        }
        [Fact]
        public void Return_True_User_Logged_Successfully()
        {
            var sut = CreateSutWithRealDependencies();

            var user = new UserProfileBuilder()
                .Build();

            var result = sut.Login(user);

            result.Should().BeTrue();

        }

        [Fact]
        public void Return_False_User_Does_Not_Logged_Successfully()
        {
            var sut = CreateSutWithRealDependencies();

            //TODO : 02 - Contruyo con el builder
            var userTest = new UserProfileBuilder()
                .WithPassword("Password")
                .WithPasswordRepeated("Other Password")
                .Build();

            //TODO: 03 - Implemento métodos helper
            //var userTest = new UserProfileBuilder()
            //                                .WithNonMatchingPasswords()
            //                                .Build();

            var result = sut.Login(userTest);

            result.Should().BeFalse();

        }
        [Fact]
        public void Return_False_User_Does_Not_Logged_Does_Not_Have_FirstName_LastName()
        {
            var sut = CreateSut();

            //TODO : 04 Implicit 
            UserProfile user = new UserProfileBuilder()
                .WithFirstName(string.Empty)
                .WithoutNames();
                

            var result = sut.Login(user);

            result.Should().BeFalse();

        }

        public void Dispose()
        {
        }

        private UserController CreateSutWithRealDependencies() =>
            new UserController(new UserServices(new EmailService()), new ReverseEncryption());

        private UserController CreateSutWithRealDependenciesWithoutEmail() =>
            new UserController(new UserServices(_emailService.Object), new ReverseEncryption());

        private UserController CreateSut() =>
            new UserController(_userService.Object, _encryption.Object);
    }
}
