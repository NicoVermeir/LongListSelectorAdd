using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace LongListSelectorAdd
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<NotificationMessage>(this, msg =>
            {
                //if(msg.Notification.Equals("ListReposition"))
                    //this.LLS.ScrollTo(this.LLS.ItemsSource[0]);
            });
            Messenger.Default.Send(new NotificationMessage("ViewLoaded"));
        }
    }
}