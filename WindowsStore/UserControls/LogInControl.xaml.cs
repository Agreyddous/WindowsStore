using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Entities;
using WindowsStore.Handlers;
using WindowsStore.ValueObjects;

namespace WindowsStore.UserControls
{
    public sealed partial class LogInControl : UserControl
    {
        public LogInControl() => InitializeComponent();

        private async void UserNameBox_LostFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(await FilesHandler.CheckIfExistsFile(UserNameBox.Text))
            {
                User loadUser = await FilesHandler.RetrieveUserContent(UserNameBox.Text + ".user");
                UserNameBox.Text = "";
                DataContext = loadUser;
            }

            if (UserNameBox.Text.Trim() == "")
                AccountTypeBox.IsEnabled = false;
            else
                AccountTypeBox.IsEnabled = true;
        }

        private async void UserNameBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (await FilesHandler.CheckIfExistsFile(UserNameBox.Text + ".user"))
            {
                User loadUser = await FilesHandler.RetrieveUserContent(UserNameBox.Text + ".user");
                UserNameBox.Text = "";
                DataContext = loadUser;
            }

            else if (UserNameBox.Text.Trim() != "")
            {
                AccountTypeBox.IsEnabled = true;
            }
        }

        private async void AccountTypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Common.IsSelected || Administrator.IsSelected)
            {
                string pic = "ms-appx:///Assets/" + UserPictureListBox.SelectedIndex + "User.png";
                User newUser = new User(new Username(UserNameBox.Text), null, null, null, null, pic, Administrator.IsSelected);
                await FilesHandler.StoreUser(newUser);
                UserNameBox.Text = "";
                AccountTypeBox.SelectedItem = null;
                AccountTypeBox.IsEnabled = false;
                DataContext = newUser; 
            }
        }
    }
}