using System;
using System.Collections.Generic;
using System.Text;

namespace UN.Core.Parsers
{
    public class UnFilterParser
    {
        private UnToken _cToken;
        private int _tid;
        private List<UnToken> _list;
        public UnTokenTreeNode ParserStart(List<UnToken> list)
        {
            _tid = 0;
            _list = list;
            _cToken = _list[_tid];
            return ParserLogicIII();
        }
        public void NextToken()
        {
            _tid = _tid + 1;
            if (_tid < _list.Count)
            {
                _cToken = _list[_tid];
               // return _cToken;
            }
            else
            {
                _cToken = new UnToken() { Id=UnTokenId.UnKnown };
            }
           // return null;
        }
        public UnTokenTreeNode GenBinTree(UnToken token, UnTokenTreeNode left, UnTokenTreeNode right)
        {
            var node = new UnTokenTreeNode();
            node.Token = token;
            node.Left = left;
            node.Right = right;
            return node;
        }
        public UnTokenTreeNode ParserLogicIII()
        {
            var left = ParserLogicII();
            while(_cToken.Id==UnTokenId.Bar3 || _cToken.Id == UnTokenId.Amp3)
            {
                var token = _cToken;
                NextToken();
                var right = ParserLogicII();
                left=GenBinTree(token, left, right);
            }
            return left;
        }
        public UnTokenTreeNode ParserLogicII()
        {
            var left = ParserLogicI();
            while (_cToken.Id == UnTokenId.Bar2 || _cToken.Id == UnTokenId.Amp2)
            {
                var token = _cToken;
                NextToken();
                var right = ParserLogicI();
                left = GenBinTree(token, left, right);
            }
            return left;

        }
        public UnTokenTreeNode ParserLogicI()
        {
            var left = ParserMain();
            while (_cToken.Id == UnTokenId.Bar1 || _cToken.Id == UnTokenId.Amp1)
            {
                var token = _cToken;
                NextToken();
                var right = ParserMain();
                left = GenBinTree(token, left, right);
            }
            return left;
        }
        public UnTokenTreeNode ParserMain()
        {
            var node= new UnTokenTreeNode() { Token = _cToken };
            NextToken();
            return node;
        }
    }
    public class UnTokenTreeNode
    {
       public  UnTokenTreeNode Left { get; set; }
        public UnTokenTreeNode Right { get; set; }
        public UnToken Token { get; set; }
    }
}
