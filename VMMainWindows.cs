using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DoubleClickCommand.ViewModel
{
    public class VMMainWindows : ViewModelBase
    {
        public VMLogin vmLogin { get; }
        public VMSearchEmail vmSearch { get; }
        public ICommand CommandShowCompanyCards { get; set; }

        public VMMainWindows(VMLogin mLogin, VMSearchEmail mSearchEmail)
        {
            vmLogin = mLogin;
            vmSearch = mSearchEmail;
        }

       
    }

}
