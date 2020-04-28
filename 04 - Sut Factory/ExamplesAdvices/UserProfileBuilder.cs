using ExamplesAdvices.Core;

namespace ExamplesAdvices.Tests
{
    internal class UserProfileBuilder
    {
        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _passwordRepeated;

        internal UserProfileBuilder()
        {
            _userName = "User Name";
            _firstName = "First Name";
            _lastName = "Last Name";
            _password = "Password";
            _passwordRepeated = _password;
        }

        internal UserProfileBuilder WithUserName(string newUserName)
        {
            _userName = newUserName;
            return this;
        }

        internal UserProfileBuilder WithFirstName(string newFirstName)
        {
            _firstName = newFirstName;
            return this;
        }
        internal UserProfileBuilder WithLastName(string newLastName)
        {
            _lastName = newLastName;
            return this;
        }

        internal UserProfileBuilder WithPassword(string newPassword)
        {
            _password = newPassword;
            return this;
        }

        internal UserProfileBuilder WithPasswordRepeated(
            string newPasswordRepeated)
        {
            _passwordRepeated = newPasswordRepeated;
            return this;
        }

        internal UserProfileBuilder WithNonMatchingPasswords()
        {
            return WithPassword("Not too short")
                .WithPasswordRepeated("doesn't match");
        }
        internal UserProfileBuilder WithoutNames()
        {
            return WithFirstName(string.Empty)
                .WithLastName(string.Empty);
        }
        internal UserProfile Build()
        {
            return new UserProfile(
                _userName,
                _firstName,
                _lastName,
                _password,
                _passwordRepeated);
        }
        public static implicit operator UserProfile(
            UserProfileBuilder builder)
        {
            return builder.Build();
        }
    }
}