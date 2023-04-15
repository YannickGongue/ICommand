using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DoubleClickCommand.Commands
{
    public class DelegateCommand : ViewModelCommands
    {
        public Action<object> _ExecuteMethod;
        public Func<object, bool> _CanExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> ExecuteCommand, Func<object,bool> CanExecuteCommand)
        {
            _ExecuteMethod = ExecuteCommand;
            _CanExecuteMethod = CanExecuteCommand;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _ExecuteMethod(parameter);
        }
    }
}
