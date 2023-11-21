using System.Windows;
using System.Windows.Controls;
using Столовые_приборы.Pages;
using Столовые_приборы.Static;

namespace Столовые_приборы.mvvm.vm
{
    public class MainVM : BaseVM
    {
        public Visibility LoggedIn
        {
            get => User.Logged.UserId != 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public string UserFIO
        {
            get => $"{User.Logged.UserSurname} {User.Logged.UserName} {User.Logged.UserPatronymic}";
        }

        public VmCommand Logout { get; set; }

        public Page CurrentPage
        {
            get => PageNavigator.CurrentPage;        
        }

        public MainVM()
        {
            User.LoggedChanged += User_LoggedChanged;
            PageNavigator.CurrentPageChanged += PageNavigator_CurrentPageChanged;
            Logout = new VmCommand(
                () => {
                    User.Logged = new DB.User();
                    PageNavigator.CurrentPage = new LoginPage();
                }, () => true);
            PageNavigator.CurrentPage = new LoginPage();
        }

        private void PageNavigator_CurrentPageChanged(object? sender, Page e)
        {
            Signal(nameof(CurrentPage));
        }

        private void User_LoggedChanged(object? sender, DB.User e)
        {
            Signal(nameof(UserFIO));
            Signal(nameof(LoggedIn));
        }
    }
}
