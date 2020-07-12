using System;
using System.Collections.Generic;
using System.Text;

namespace UN.Core.Parsers
{
    public class UnParser
    {
        private char[] _cmdList;
        private int _cmdLens = 0;
        private int _pos = -1;
        private char _ch;
        private string _cmdText="";
       
        public UnParser(string cmdText)
        {
            _cmdText = cmdText;
            _cmdList = cmdText.ToCharArray();
            _cmdLens = _cmdList.Length;
        }
        private void NextChar()
        {
            _pos = _pos + 1;
            if (_pos < _cmdLens)
                _ch = _cmdList[_pos];
            else
                _ch = '\0';
        }
        public List<UnToken> GetUnTokens()
        {
            List<UnToken> TokenList = new List<UnToken>();
            NextChar();
            while (_pos < _cmdLens )
            {
                var tk = NextToken();
                TokenList.Add(tk);
            }
            return TokenList;
        }
        public UnToken NextToken()
        {
            int s_pos = 0;
            UnTokenId tokenid = UnTokenId.UnKnown;

            while (_ch == ' ' || _ch == '\n')
            {
                NextChar();
            }
            if (_pos == _cmdLens) return ReturnToken(UnTokenId.Blank, _pos);
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
                case '|':
                    tokenid = UnTokenId.Bar1; NextChar();
                    if (_ch == '|') { tokenid = UnTokenId.Bar2; NextChar(); }
                    if (_ch == '|') { tokenid = UnTokenId.Bar3; NextChar(); }
                    break;
                case '&':
                    tokenid = UnTokenId.Amp1; NextChar();
                    if (_ch == '&') { tokenid = UnTokenId.Amp2; NextChar(); }
                    if (_ch == '&') { tokenid = UnTokenId.Amp3; NextChar(); }
                    break;
                case '"':
                case '\'':
                    var ch = _ch;
                    while ( _pos < _cmdLens)
                    {
                        NextChar();
                        if (ch == _ch) break;
                        if(_ch=='\\') NextChar();
                        //if (_ch == ' ') NextChar();

                    }
                    if (_ch == ch)
                    {
                        tokenid = UnTokenId.TStringCell; 
                        NextChar();
                        if(_ch!=' ' && _pos < _cmdLens)
                        {
                            _pos = _cmdLens;
                            return ReturnToken(UnTokenId.SyntaxError, s_pos);
                        }  
                            
                    }
                    else
                    {
                        tokenid = UnTokenId.SyntaxError; NextChar(); return ReturnToken(tokenid, s_pos);
                    }
                    
                    break;
                default:
                    while (_ch != '|' && _ch != '&' && _ch != ' ' && _ch != ':' && _pos < _cmdLens)
                    {
                        NextChar();
                    }
                    tokenid = UnTokenId.FStringCell;
                    break;

            }
            var untoken = new UnToken();
            untoken.Id = tokenid;
            untoken.Text = _cmdText.Substring(s_pos, _pos - s_pos);
            return untoken;
        }
        public UnToken ReturnToken(UnTokenId tokenid,int s_pos)
        {
            var pos = _pos < _cmdLens ? _pos : _cmdLens ;
            var untoken = new UnToken();
            untoken.Id = tokenid;
            untoken.Text = _cmdText.Substring(s_pos, pos - s_pos);
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
        Blank,
        SyntaxError,
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

        FStringCell,
        TStringCell,
        VerbFunc


    }

}
