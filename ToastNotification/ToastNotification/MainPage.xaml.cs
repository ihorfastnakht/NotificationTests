using Acr.Notifications;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace ToastNotification
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            list.ItemSelected += (s, e) =>
            {
            };
        }

        private void OnClick2(object sender, EventArgs e)
        {
            Notifications.Instance.Badge = 1;
            Notifications.Instance.Send(new Notification().SetMessage("Header")
                .SetSchedule(TimeSpan.FromSeconds(30)).SetTitle("test"));
        }

        private async void OnClick(object sender, EventArgs e)
        {
            //var notificator = DependencyService.Get<IToastNotificator>();

            //bool tapped = await notificator.Notify(ToastNotificationType.Info,
            //    "Test", "Notificator", TimeSpan.FromSeconds(1));     
            UserDialogs.Instance.Toast("toast", TimeSpan.FromSeconds(10));//Progress(new ProgressDialogConfig() { Title = "OK", MaskType = MaskType.Gradient, IsDeterministic = true });
        }
    }
}
