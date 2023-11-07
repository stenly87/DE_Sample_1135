using System;
using System.Windows.Input;

namespace Столовые_приборы.mvvm
{
    public class VmCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool> condition;

        public VmCommand(Action action, 
            Func<bool> condition)
        {
            this.action = action;
            this.condition = condition;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return condition();
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
