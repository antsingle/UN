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
using UN.Core.Parsers;
namespace UN.Cells.ViewModels
{
    class MeCellViewModel : BindableBase
    {
        private List<UnToken> _tokens = new List<UnToken>();
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
            var ps = new UnParser(s);
            _tokens = ps.GetUnTokens();
            MessageBox.Show(s);
        }
        private DelegateCommand<object> _showList;
        public DelegateCommand<object> ShowList =>
           _showList ?? (_showList = new DelegateCommand<object>(ShowCmdList));
        private void ShowCmdList(object o)
        {
            var ps = new UnParser(Cmd);
            _tokens = ps.GetUnTokens();
            var ic = (ItemsControl)o;
            ic.Items.Clear();
            for (int i=0;i< _tokens.Count;i++)
            {
                ic.Items.Add(_tokens[i].Text + " " + _tokens[i].Id.ToString());
            }
          //  var aaa=(new UnFilterParser()).ParserStart(_tokens);

            //MessageBox.Show("f\nff");
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
