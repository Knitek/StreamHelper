﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StreamHelper.Controls
{
    public class CommandBase : ICommand
    {
        Action _TargetExecuteMethod;
        Func<bool>? _TargetCanExecuteMethod;

        public CommandBase(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public CommandBase(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object? parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public event EventHandler? CanExecuteChanged = delegate { };

        void ICommand.Execute(object? parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }
    }
}
