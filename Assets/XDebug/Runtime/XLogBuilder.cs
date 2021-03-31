using System.Text;
using System.Collections.Generic;
using UnityEngine;

namespace XGameKit.Core
{
    public class XLogBuilder : ILogBuilder
    {
        private string _Tag;   //��ǩ
        private string _Col;   //��ɫ rrggbbaa

        private string _TagStr;
        private string _ColStrHead;
        private string _ColStrTail;

        public void SetTag(string tag, bool showTag = true)
        {
            _Tag = tag;

            if (showTag)
            {
                _TagStr = $"[{tag}]";
            }
            else
            {
                _TagStr = string.Empty;
            }
        }
        public void SetCol(string col)
        {
            _Col = col;

            if(!string.IsNullOrEmpty(col))
            {
                _ColStrHead = $"<color=#{col}>";
                _ColStrTail = "</color>";
            }
        }

        public void AppendTag(StringBuilder sb)
        {
            if (string.IsNullOrEmpty(_TagStr))
                return;
            sb.Insert(0, _TagStr);
        }
        public void AppendCol(StringBuilder sb)
        {
            if (string.IsNullOrEmpty(_Col))
                return;

            sb.Insert(0, _ColStrHead);
            //ֻ��ǰ������Ҫ����Ⱦɫ
            var list = _CollectLineBreak(sb, 2);
            for (int i = list.Count - 1; i >= 0; --i)
            {
                int index = list[i];
                sb.Insert(index + 1, _ColStrHead);
                sb.Insert(index, _ColStrTail);
            }
            sb.Append(_ColStrTail);
        }

        private List<int> _TempList = new List<int>();
        //ͳ�ƻ��з� num:����
        private List<int> _CollectLineBreak(StringBuilder sb, int num)
        {
            _TempList.Clear();
            for (int i = 0; i < sb.Length; ++i)
            {
                if (sb[i] != '\n')
                    continue;
                _TempList.Add(i);
                if (_TempList.Count >= num)
                    break;
            }
            return _TempList;
        }
    }
}