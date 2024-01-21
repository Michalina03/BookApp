using BookApp.UserComunication;

namespace BookApp
{
    public class App : IApp
    {
        private readonly IUserCommunication _userCommunication;

        public App(IUserCommunication userCommunication)
        {
            _userCommunication = userCommunication;
        }

        public void Run()
        {
            _userCommunication.CommunicationWithUser();
        }
    }
}
