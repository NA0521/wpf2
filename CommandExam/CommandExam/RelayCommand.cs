using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace CommandExam
{
    class RelayCommand : ICommand
    {
        Func<object, bool> canExecute;
        Action<object> executeAction;

        public RelayCommand(Action<object> executeAction) : this(executeAction, null)
        {

        }

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExcute)
        {
            this.executeAction = executeAction ?? throw new ArgumentNullException("Excute Action null Icommand");
            this.canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter?.ToString().Length == 0)
                return false;
            bool result = this.canExecute == null ? true : this.canExecute.Invoke(parameter);
            return result;
        }

        public void Execute(object parameter)
        {
            this.executeAction.Invoke(parameter);
        }
    }
}
