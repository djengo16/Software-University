namespace SharedTrip.Services
{
    public interface IUsersService
    {
        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        void DoRegister(string username, string password, string email);

        string GetUserId(string username, string password);
    }
}
