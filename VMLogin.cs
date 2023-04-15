using DoubleClickCommand.Model;
using DoubleClickCommand.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleClickCommand.ViewModel
{
    public class VMLogin : ViewModelBase
    {
        private string setName;
        private string setPassword;
        private UserStore _UserStore;

        public string SetPassword
        {
            get
            {
                return setPassword;
            }
            set
            {
                this.setPassword = value;
                OnPropertyChanged(nameof(SetPassword));
            }
        }

        public string SetName
        {
            get
            {
                return setName;
            }
            set
            {
                this.setName = value;
                OnPropertyChanged(nameof(SetName));
            }
        }

        public VMLogin(UserStore userStore)
        {
            _UserStore = userStore;
            _UserStore.UserSelected += OnUserSelected;
        }

        private void OnUserSelected(MUser user)
        {
            SetName = user.Id;
            SetPassword = user.Passwort;
        }
    }
}
