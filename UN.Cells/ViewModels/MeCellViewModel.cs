using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using UN.Core.Events;
using unvell.ReoGrid;
using Prism.Commands;
using UN.Core.Services;
using System.Windows;
using System.Windows.Controls;

namespace UN.Cells.ViewModels
{
    class MeCellViewModel : BindableBase
    {
        private string _cmd;
        public string Cmd
        {
            get { return _cmd; }
            set { SetProperty(ref _cmd, value); }
        }

        private DelegateCommand<string> _commandEnter;
        public DelegateCommand<string> CommandEnter =>
           _commandEnter ?? (_commandEnter = new DelegateCommand<string>(CmdEnter));
        private void CmdEnter(string s)
        {
            MessageBox.Show(s);
        }
        private DelegateCommand<object> _cmdTextChanged;
        public DelegateCommand<object> CmdTextChanged =>
           _cmdTextChanged ?? (_cmdTextChanged = new DelegateCommand<object>(TextChanged));
        private void TextChanged(object o)
        {
            Cmd =   ((TextBox)o).Text;
        }

    }
}
