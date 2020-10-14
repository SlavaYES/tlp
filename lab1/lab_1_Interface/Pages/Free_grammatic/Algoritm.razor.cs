using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            // 
            mGrammatic.VT.Add("1");
            mGrammatic.VT.Add("2");


            mGrammatic.VN.Add("a");
            mGrammatic.VN.Add("b");
            mNewRegularRight = "1a|2b";
            mNewRegularLeft = "a";
        }

        protected void onClickNewRegular()
        {
            if (!string.IsNullOrWhiteSpace(mNewRegularLeft) && !(string.IsNullOrWhiteSpace(mNewRegularRight)))
            {
                string str = mNewRegularLeft + "->" + mNewRegularRight + "\r\n";
                var reg = ConvertStringToRegular(str);
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


        protected List<Regular> ConvertStringToRegular(string str)
        {
            List<Regular> list = new List<Regular>();
            while (str.Length > 1)
            {
                Regular regular = new Regular();
                regular.right = new List<List<string>>();
                var index = str.IndexOf("-");
                regular.left = str.Substring(0, index);

                str = str.Substring(index + 2);
                index = str.IndexOf("\n");
                if (index < 0) {
                    var tmp1 = ConvertStringToStringList(str.Substring(0), "|");
                    foreach (var tmp in tmp1) {
                        regular.right.Add(ConvertStringToStringList(tmp));
                    }
                    list.Add(regular);
                    break;
                }

                var tmp2 = ConvertStringToStringList(str.Substring(0, index), "|");
                foreach (var tmp in tmp2) {

                    regular.right.Add(ConvertStringToStringList(tmp));
                }
                str = str.Substring(index + 1);
                list.Add(regular);
            }

            return list;
        }

        protected List<string> ConvertStringToStringList(string str)
        {
            List<string> list = new List<string>();
            //// str = aaT
            //int i = 0;
            //int start = 0;

            mDebug = "";
            //foreach (var iter in mGrammatic.VT) {
            //    mDebug += iter;
            //}
            int move = 0;
            for (int i = 0; i < str.Length; i++) {
                foreach (var gramVt in mGrammatic.VT) {
                    if (gramVt.Equals(str[i].ToString())) {
                        move++;
                    }
                }
            }
            if (move > 0) {
                list.Add(str.Substring(0, move));
            }
            str = str.Substring(move);

            move = 0;
            for (int i = 0; i < str.Length; i++) {
                foreach (var gramVt in mGrammatic.VN) {
                    if (gramVt.Equals(str[i].ToString())) {
                        move++;
                    }
                }
            }

            if (move > 0) {
                list.Add(str.Substring(0, 1));
            }

            //while (i < str.Length && mGrammatic.VT.FindIndex(t => t == str.Substring(i, 1)) > -1) {
            //    i++;
            //}
            //if (i > 0) {
            //    list.Add(str.Substring(start, i));
            //}
            //start = i;
            //int j = 0;
            //while (i < str.Length && mGrammatic.VN.FindIndex(t => t == str.Substring(i, 1)) > -1) {
            //    list.Add(str.Substring(start, 1));
            //    i++;
            //    start = i;
            //}

            //list = aa, T
            return list;
        }

        protected static List<string> ConvertStringToStringList(string str, string border)
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
