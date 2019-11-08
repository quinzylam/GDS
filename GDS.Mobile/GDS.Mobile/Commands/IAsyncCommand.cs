using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static GDS.Mobile.Commands.AsyncCommand;

namespace GDS.Mobile.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);

        void RaiseCanExecuteChanged();

        event ExecuteEventHandler PreExecution;

        event ExecuteEventHandler PostExecution;

        event ExecuteEventHandler FailedExecution;
    }
}