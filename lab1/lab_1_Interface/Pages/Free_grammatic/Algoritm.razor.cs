using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;
using lab_1_Interface.Models;
using MatBlazor;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.TeamFoundation.Common.Internal;

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

        protected List<string> FileErrorsList { get; set; }
        protected bool showProgressBar { get; set; } = false;
        protected double progressValue { get; set; }
        protected DocumentModel Document { get; set; }

        private List<Chain> listAnswer;
        protected override void OnInitialized()
        {
            mGrammatic.VT = new List<string>();
            mGrammatic.VN = new List<string>();
            mGrammatic.Regulation = new List<Regular>();
            mGrammatic.lamb = new string("lamb");

            //// 
            //mGrammatic.VT.Add("1");
            //mGrammatic.VT.Add("2");


            //mGrammatic.Min = 0;
            //mGrammatic.Max = 5;
            //mGrammatic.VN.Add("a");
            //mGrammatic.VN.Add("b");
            //mNewRegularRight = "1|2b";
            //mNewRegularLeft = "a";
        }

        protected void onClickNewRegular()
        {
            if (!string.IsNullOrWhiteSpace(mNewRegularLeft) && !(string.IsNullOrWhiteSpace(mNewRegularRight)))
            {
                string str = mNewRegularLeft + "->" + mNewRegularRight + "\n";
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
                if (index < 0)
                {
                    var tmp1 = ConvertStringToStringList(str.Substring(0), "|");
                    foreach (var tmp in tmp1)
                    {
                        regular.right.Add(ConvertStringToStringList(tmp));
                    }
                    list.Add(regular);
                    break;
                }

                var tmp2 = ConvertStringToStringList(str.Substring(0, index), "|");
                foreach (var tmp in tmp2)
                {

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

            mDebug = str;
            if (mGrammatic.lamb.Equals(str))
            {
                list.Add(mGrammatic.lamb);
                return list;
            }

            int move = 0;
            for (int i = 0; i < str.Length; i++)
            {
                foreach (var gramVt in mGrammatic.VT)
                {
                    if (gramVt.Equals(str[i].ToString()))
                    {
                        move++;
                    }
                }
            }
            if (move > 0)
            {
                list.Add(str.Substring(0, move));
            }
            str = str.Substring(move);

            move = 0;
            for (int i = 0; i < str.Length; i++)
            {
                foreach (var gramVt in mGrammatic.VN)
                {
                    if (gramVt.Equals(str[i].ToString()))
                    {
                        move++;
                    }
                }
            }

            if (move > 0)
            {
                list.Add(str.Substring(0, 1));
            }
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
        protected void CompRecSasha()
        {
            //Answer = CompRec(mGrammatic.Regulation[0].left, 0);
            var index = mGrammatic.Regulation.FindIndex(x => x.left == mGrammatic.S);
            var tmp = mGrammatic.Regulation[index];
            mGrammatic.Regulation.Remove(tmp);
            mGrammatic.Regulation.Insert(0, tmp);

            bool isOne = true;
            List<Chain> list = new List<Chain>();
            do
            {
                foreach (var regulars in mGrammatic.Regulation)
                {
                    if (isOne)
                    {
                        foreach (var reg in regulars.right)
                        {
                            list.Add(new Chain());
                            foreach (var r in reg)
                            {
                                if (mGrammatic.VN.FindIndex(x => IsRavnStr(x, r)) >= 0)
                                {
                                    list.LastOrDefault().End = r;
                                }
                                else if (IsRavnStr(mGrammatic.lamb, r))
                                {
                                    list.LastOrDefault().End = mGrammatic.lamb;
                                }
                                else
                                {
                                    list.LastOrDefault().Str =
                                        list.LastOrDefault().Str.Replace("\n", "").Replace("\t", "").Replace("r", "") +
                                        r;
                                    list.LastOrDefault().End = mGrammatic.lamb;
                                }
                            }
                        }

                        isOne = false;
                        continue;
                    }
                    //
                    for (var i = 0; i < list.Count; i++)
                    {
                        var listik = list[i];
                        if (!IsRavnStr(listik.End, regulars.left))
                        {
                            continue;
                        }

                        var isOne2 = true;
                        Chain listTmpOne = new Chain();
                        foreach (var reg in regulars.right)
                        {
                            Chain listTmp;
                            if (isOne2)
                            {
                                listTmp = list[i];
                                listTmpOne = (Chain)list[i].Clone();
                            }
                            else
                            {
                                list.Insert(i, new Chain());
                                listTmp = list[i];
                                listTmp.Str = listTmpOne.Str.ToString();
                                listTmp.End = listTmpOne.End.ToString();
                                i++;
                            }
                            foreach (var r in reg)
                            {
                                if (mGrammatic.VN.FindIndex(x => IsRavnStr(x, r)) >= 0)
                                {
                                    listTmp.End = r;
                                }
                                else if (IsRavnStr(mGrammatic.lamb, r))
                                {
                                    listTmp.End = mGrammatic.lamb;
                                }
                                else
                                {
                                    listTmp.Str = listTmp.Str.Replace("\n", "").Replace("\t", "").Replace("r", "") + r;
                                    listTmp.End = mGrammatic.lamb;
                                }
                            }

                            isOne2 = false;
                        }
                    }

                }

                for (var i = 0; i < list.Count; i++)
                {
                    var model = list[i];
                    if (model.Count < mGrammatic.Min && model.End == mGrammatic.lamb)
                    {
                        list.Remove(model);
                        i--;
                        continue;
                    }

                    if (model.Count > mGrammatic.Max)
                    {
                        list.Remove(model);
                        i--;
                    }
                }
            } while (Check(list));//пока есть не законченные цепочки

            listAnswer = list.Distinct().ToList();
        }

        private bool Check(List<Chain> list)//пока есть не законченные цепочки
        {
            if (list == null || list?.Count == 0)
            {
                return false;
            }

            foreach (var model in list)
            {
                if (!IsRavnStr(model.End, mGrammatic.lamb))
                {
                    return true;
                }
            }

            return false;
        }
        //List<string> CompRec(string S, int stringCount)
        //{
        //    List<string> list = new List<string>();

        //    Dictionary<string, List<string>> keyValues = new Dictionary<string, List<string>>();

        //    return list;
        //}
        private bool IsRavnStr(string str1, string str2)
        {
            if (str1.Replace("\n", "").Replace("\t", "").Replace("r", "") ==
                str2.Replace("\n", "").Replace("\t", "").Replace("r", ""))
            {
                return true;
            }

            return false;
        }
        List<string> SubCompRec()
        {
            List<string> list = new List<string>();

            return list;
        }

        protected async void HandleFileSelected(IFileListEntry[] files)
        {
            FileErrorsList = new List<string>();
            progressValue = 0.0;
            showProgressBar = true;

            if (files != null && files.Count() > 0)
            {
                double step = (double)1 / files.Count();
                foreach (var file in files)
                {
                    try
                    {
                        var doc = await UploadFile(file);
                        if (doc != null)
                        {
                            Document = doc;
                        }
                    }
                    catch (Exception e)
                    {
                        FileErrorsList.Add($"File: {file.Name} don't uploaded, because {e.Message}");
                    }
                    finally
                    {
                        progressValue += step;
                        StateHasChanged();
                    }
                }
            }
            progressValue = 1.0;
            showProgressBar = false;
            GetDataFile();
            StateHasChanged();
        }
        private void GetDataFile()
        {
            string textFromFile = System.Text.Encoding.Default.GetString(Document.Data);
            Console.WriteLine($"Текст из файла: {textFromFile}");
            textFromFile = textFromFile.Replace(" ", "");

            // Terminal
            var index1 = textFromFile.IndexOf("\n");
            var term = textFromFile.Substring(0, index1);
            mGrammatic.VT = lab1.Program.ConvertStringToStringList(term, ",");

            // NoTerminal
            textFromFile = textFromFile.Substring(index1 + 1);
            index1 = textFromFile.IndexOf("\n");
            var nterm = textFromFile.Substring(0, index1);
            mGrammatic.VN = lab1.Program.ConvertStringToStringList(nterm, ",");

            // Begin NoTerminal
            textFromFile = textFromFile.Substring(index1 + 1);
            index1 = textFromFile.IndexOf("\n");
            mGrammatic.S = textFromFile.Substring(0, index1 - 1);

            // Count symbols
            textFromFile = textFromFile.Substring(index1 + 1);
            index1 = textFromFile.IndexOf("\n");
            var temp = textFromFile.Substring(0, index1);
            var tempSub = lab1.Program.ConvertStringToStringList(temp, ",");
            mGrammatic.Min = Convert.ToInt32(tempSub.First());
            mGrammatic.Max = Convert.ToInt32(tempSub.Last());

            // Regular
            textFromFile = textFromFile.Substring(index1 + 1);
            mGrammatic.Regulation = ConvertStringToRegulations(textFromFile);
        }

        public List<Regular> ConvertStringToRegulations(string str)
        {
            List<Regular> list = new List<Regular>();
            while (str.Length > 1)
            {
                Regular regulations = new Regular();
                regulations.right = new List<List<string>>();
                var index = str.IndexOf("-");
                regulations.left = str.Substring(0, index);

                str = str.Substring(index + 2);
                index = str.IndexOf("\n");
                if (index < 0)
                {
                    var tmp1 = ConvertStringToStringList(str.Substring(0), "|");
                    foreach (var tmp in tmp1)
                    {
                        regulations.right.Add(ConvertStringToStringListForFile(tmp));
                    }
                    list.Add(regulations);
                    break;
                }

                var tmp2 = ConvertStringToStringList(str.Substring(0, index), "|");
                foreach (var tmp in tmp2)
                {
                    regulations.right.Add(ConvertStringToStringListForFile(tmp));
                }
                str = str.Substring(index + 1);
                list.Add(regulations);
            }

            return list;
        }
        public List<string> ConvertStringToStringListForFile(string str)
        {
            List<string> list = new List<string>();
            // str = aaT | lamd
            int i = 0;
            int start = 0;

            if (str.Replace("\n", "").Replace("\t", "").Replace("\r", "") == mGrammatic.lamb.Replace("\n", "").Replace("\t", "").Replace("r", ""))
            {
                list.Add(mGrammatic.lamb);
                return list;
            }

            while (i < str.Length && mGrammatic.VT.FindIndex(t => t == str.Substring(i, 1)) > -1)
            {
                i++;
            }
            if (i > 0)
            {
                list.Add(str.Substring(start, i));
            }
            start = i;
            int j = 0;
            while (i < str.Length && mGrammatic.VN.FindIndex(t => t == str.Substring(i, 1)) > -1)
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
            while (i < str.Length && mGrammatic.VT.FindIndex(t => t == str.Substring(i, 1)) > -1)
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
        public async Task<DocumentModel> UploadFile(IFileListEntry file)
        {
            if (file != null)
            {
                byte[] result;
                MemoryStream SourceStream = await file.ReadAllAsync((int)file.Size);
                result = new byte[file.Data.Length];
                await SourceStream.ReadAsync(result, 0, (int)file.Data.Length);

                DocumentModel doc = new DocumentModel()
                {
                    FileName = file.Name,
                    Data = result,
                    ContentType = file.Type
                };
                return doc;
            }
            return null;
        }
    }
}
