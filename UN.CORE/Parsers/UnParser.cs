using System;
using System.Collections.Generic;
using System.Text;

namespace UN.Core.Parsers
{
    public class UnParser
    {
        private char[] _cmdTextCharArray;
        //private int _cmdTextLens = 0;
        private int _pos = -1;
        private char _ch;
        private string _cmdText="";
       
        public UnParser(string cmdText)
        {
            _cmdText = cmdText;
            _cmdTextCharArray = cmdText.ToCharArray();
        }
        private void NextChar()
        {
            _pos = _pos + 1;
            if (_pos < _cmdTextCharArray.Length)
                _ch = _cmdTextCharArray[_pos];
            else
                _ch = '\0';
        }
        public List<UnToken> GetUnTokens()
        {
            List<UnToken> TokenList = new List<UnToken>();
            NextChar();
            while (_pos < _cmdTextCharArray.Length )
            {
                var tk = NextToken();
                TokenList.Add(tk);
            }
            return TokenList;
        }
        public UnToken NextToken()
        {
            int s_pos = 0;
            UnTokenId tokenid=UnTokenId.UnKnown;
           
            while (_ch == ' ' || _ch == '\n')
            {
                NextChar();
            }
            s_pos = _pos;
            switch (_ch)
            {
                case '.':
                    tokenid = UnTokenId.Dot; NextChar();
                    break;
                case '#':
                    tokenid = UnTokenId.Sharp; NextChar();
                    break;
                case '/':
                    tokenid = UnTokenId.Slash; NextChar();
                    break;
                case ':':
                    tokenid = UnTokenId.Colon; NextChar();
                    break;
                case '"':
                    tokenid = UnTokenId.Slash; NextChar();
                    break;
                default:
                    while (_ch != ' '&& _ch != ':' && _pos < _cmdTextCharArray.Length) NextChar();
                    tokenid = UnTokenId.LawStringCell;
                    break;

            }
            var untoken = new UnToken();
            untoken.Id = tokenid;
            untoken.Text = _cmdText.Substring(s_pos, _pos - s_pos  );
            return untoken;
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
        UnKnown,
        Dot,
        Sharp,
        Slash,
        Colon,

        Bar1,
        Bar2,
        Bar3,
        Amp1,
        Amp2,
        Amp3,

        LawStringCell,
        StringCell,
        VerbFunc


    }

}
