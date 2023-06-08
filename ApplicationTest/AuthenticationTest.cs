using ApplicationTest.Mocks;
using Domain.Entities;
using Domain.Logic;

namespace ApplicationTest
{
    [TestClass]
    public class AuthenticationTest
    {
        private MockUserRepository mockAccountRepository;
        private AuthenticationHandler authenticationHandler;

        [TestInitialize]
        public void Setup()
        {
            mockAccountRepository = new MockUserRepository(new List<User>());
            authenticationHandler = new AuthenticationHandler(mockAccountRepository);
        }

        [TestMethod]
        public void Register_ValidClientAccount_CallsInsertIntoAccount()
        {
            // Arrange
            string username = "john";
            string email = "john@example.com";
            string password = "password";
            UserRole role = UserRole.Client;

            // Act
            authenticationHandler.Register(username, email, password, role);

            // Assert
            Assert.AreEqual(1, mockAccountRepository.Accounts.Count);
        }

        [TestMethod]
        public void Register_ExistingAccount_ThrowsException()
        {
            // Arrange
            string username = "existing";
            string email = "existing@example.com";
            string password = "password";
            UserRole role = UserRole.Client;

            User existingUser = new User(username, email, BCrypt.Net.BCrypt.HashPassword(password), role);
            mockAccountRepository.Accounts.Add(existingUser);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => authenticationHandler.Register(username, email, password, role));
        }

        [TestMethod]
        public void Authenticate_ValidCredentials_ReturnsUser()
        {
            // Arrange
            string username = "john";
            string email = "john@example.com";
            string password = "password";
            UserRole role = UserRole.Client;

            User user = new User(username, email, BCrypt.Net.BCrypt.HashPassword(password), role);
            mockAccountRepository.Accounts.Add(user);

            // Act
            User? result = authenticationHandler.Authenticate(username, email, password);

            // Assert
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void Authenticate_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            string username = "john";
            string email = "john@example.com";
            string password = "password";
            UserRole role = UserRole.Client;

            User user = new User(username, email, BCrypt.Net.BCrypt.HashPassword("wrongPassword"), role);
            mockAccountRepository.Accounts.Add(user);

            // Act
            User? result = authenticationHandler.Authenticate(username, email, password);

            // Assert
            Assert.IsNull(result);
        }
    }
}