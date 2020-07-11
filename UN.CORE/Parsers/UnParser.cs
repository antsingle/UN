using System;
using System.Collections.Generic;
using System.Text;

namespace UN.Core.Parsers
{
    public class UnParser
    {
        private char[] _cmdTextCharArray;
        //private int _cmdTextLens = 0;
        private int _pos = 0;
        private string _ch;

        public UnParser(string cmdText)
        {
            _cmdTextCharArray = cmdText.ToCharArray();
        }
        private void NextChar()
        {
            _pos = _pos + 1;
            if (_pos < _cmdTextCharArray.Length)
                _ch = _cmdTextCharArray[_pos].ToString();
            else
                _ch = "";
            
        }
        public void NextToken()
        {
            
        }
    }
    public class UnToken
    {
        public UnTokenId Id { get; set; }
        public string Text { get; set; }
        public  int Pos { get; set; }
    }
    public enum UnTokenId
    {
        Dot,
        Sharp,
        Slash,

        VerbFunc


    }

}
