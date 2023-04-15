using DoubleClickCommand.Model;
using DoubleClickCommand.Store;
using DoubleClickCommand.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleClickCommand.Commands
{
    public class SelectedUserCommand : ViewModelCommands
    {
        private readonly VMSearchEmail _vmSearchEmail;
        private readonly UserStore _userStore;

        public SelectedUserCommand(VMSearchEmail SearchEmail, UserStore userStore)
        {
            _vmSearchEmail = SearchEmail;
            _userStore = userStore;
        }

        public override void Execute(object parameter)
        {      
           _userStore.SelectUser(_vmSearchEmail.GetUserInfos(_vmSearchEmail.SetEmail));
        }
    }
}
