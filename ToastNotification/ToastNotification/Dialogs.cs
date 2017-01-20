using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToastNotification
{
    public interface IDialogs
    {
        IUserDialogs UserDialog { get; }

        void ShowAlertDialog(string message, string header);
    }
}
