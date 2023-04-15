using DoubleClickCommand.Model;
using System;

namespace DoubleClickCommand.Store
{
    public class UserStore
    {
        public event Action<MUser> UserSelected;
        public void SelectUser(MUser mUser)
        {
            UserSelected?.Invoke(mUser);
        }
    }
}