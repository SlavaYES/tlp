using System.Collections.Generic;
using System.Linq;
using lab_1_Interface.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace lab_1_Interface.Pages.Free_grammatic
{
    public partial class Algoritm
    {
        protected Grammatic mGrammatic = new Grammatic();

        string mInputVtText, mInputVnText;
        string[] mSplitVtText, mSplitVnText;

        private string mNewRegularLeft, mNewRegularRight;

        static string mDebug;
        protected List<string> Answer { get; set; }

        protected override void OnInitialized()
        {
            mGrammatic.VT = new List<string>();
            mGrammatic.VN = new List<string>();
            mGrammatic.Regulation = new List<Regular>();
            mGrammatic.lamb = new string("lamb");
        }

        protected void onClickNewRegular()
        {
            if (!string.IsNullOrWhiteSpace(mNewRegularLeft) && !(string.IsNullOrWhiteSpace(mNewRegularRight)))
            { 
                var reg = ConvertStringToRegular(mNewRegularLeft + "->" + mNewRegularRight + "\r\n", mGrammatic);
                if (reg == null)
                {
                    return;
                }

                foreach (var r in reg)
                {
                    mGrammatic.Regulation.Add(r);
                }
            }
        }


        protected static List<Regular> ConvertStringToRegular(string str, Grammatic grammatic)
        {
            List<Regular> list = new List<Regular>();
            while (str.Length > 1)
            {
                Regular regular = new Regular();
                regular.right = new List<List<string>>();
                var index = str.IndexOf("-");
                regular.left = str.Substring(0, index);

                str = str.Substring(index + 2);
                mDebug = ""; // DEBUG

                foreach (char iterator in str)
                {
                    mDebug += (int)iterator;
                }

                index = str.IndexOf("\n");

                if (index < 0)
                {
                    var tmp1 = ConvertStringToStringList(str.Substring(0), "|", grammatic);
                    foreach (var tmp in tmp1)
                    {
                        regular.right.Add(ConvertStringToStringList(tmp, grammatic));
                    }
                    list.Add(regular);
                    break;
                }

                var tmp2 = ConvertStringToStringList(str.Substring(0, index), "|", grammatic);
                foreach (var tmp in tmp2)
                {
                    regular.right.Add(ConvertStringToStringList(tmp, grammatic));
                }


                str = str.Substring(index + 1);
                list.Add(regular);
            }

            return list;
        }

        protected static List<string> ConvertStringToStringList(string str, Grammatic grammatic)
        {
            List<string> list = new List<string>();
            // str = aaT | lamd
            int i = 0;
            int start = 0;

            if (grammatic.lamb.Equals(str))
            {
                list.Add(grammatic.lamb);
                return list;
            }

            while (i < str.Length && grammatic.VT.FindIndex(t => t == str.Substring(i, 1)) > -1)
            {
                i++;
            }
            if (i > 0)
            {
                list.Add(str.Substring(start, i));
            }
            start = i;
            int j = 0;
            while (i < str.Length && grammatic.VN.FindIndex(t => t == str.Substring(i, 1)) > -1)
            {
                list.Add(str.Substring(start, 1));
                i++;
                start = i;
            }
            if (i > start)
            {
                list.Add(str.Substring(start, j));
            }

            start = i;
            j = 0;
            while (i < str.Length && grammatic.VT.FindIndex(t => t == str.Substring(i, 1)) > -1)
            {
                i++;
                j++;
            }

            if (i > start)
            {
                list.Add(str.Substring(start, j));
            }

            // list = aa, T
            return list;
        }

        protected static List<string> ConvertStringToStringList(string str, string border, Grammatic grammatic)
        {
            List<string> list = new List<string>();
            while (str.Length > 0)
            {
                var index = str.IndexOf(border);
                if (index == -1)
                {
                    break;
                }
                list.Add(str.Substring(0, index));
                str = str.Substring(index + 1);
            }

            var index1 = str.IndexOf("\n");
            if (index1 < 0)
            {
                list.Add(str.Substring(0));
            }
            else
            {
                list.Add(str.Substring(0, index1));
            }
            return list;
        }

        void inputVT()
        {
            if (!string.IsNullOrWhiteSpace(mInputVtText))
            {
                mSplitVtText = mInputVtText.Split(",");
                mGrammatic.VT = new List<string>();
                foreach (string list in mSplitVtText)
                {
                    mGrammatic.VT.Add(list);
                }
            }
        }

        protected void inputVN()
        {
            if (!string.IsNullOrWhiteSpace(mInputVnText))
            {
                mSplitVnText = mInputVnText.Split(",");
                mGrammatic.VN = new List<string>();
                foreach (string list in mSplitVnText)
                {
                    mGrammatic.VN.Add(list);
                }
            }
        }

        protected void CompRec()
        {
            Answer = CompRec(mGrammatic.S, 0);
        }
        List<string> CompRec(string S, int stringCount)
        {
            return null;
        }
    }
}
