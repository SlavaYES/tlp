using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Linq;

namespace lab1
{
    class Program
    {
        private static List<String> mTerminalList;
        private static List<String> mNotTerminalList;
        private static String mS;
        private static int mMin, mMax;
        private static List<Regulations> mRegulations;
        private const string lamb = "lamb";

        public static Regulations NULL { get; private set; }

        static void Main(string[] args)
        {
            Menu();
            PrintGrammatic();

            //foreach (var iteri in mRegulations) {
            //    foreach (var iterj in iteri.right) {
            //        foreach (var iterk in iterj) {
            //            Console.WriteLine(iterk);
            //        }
            //    }
            //}

            var output = CompRec(mS, 0);
            //for (int i = 0; i < output.Count; i++) {
            //    if (output[i].Length < mMin) {
            //        output.Remove(output[i]);
            //        i--;
            //    }
            //}

            //output = output.Distinct().ToList();
            foreach (string iter in output) {
                Console.WriteLine(iter);
            }
        }

        static void PrintGrammatic()
        {
            foreach (string iter in mTerminalList) {
                Console.Write(iter);
            }
            Console.WriteLine();
            foreach (string iter in mNotTerminalList) {
                Console.Write(iter);
            }
            Console.WriteLine();
            Console.WriteLine(mS);
            Console.Write(mMin + " ");
            Console.WriteLine(mMax);
            foreach (Regulations iterReg in mRegulations) {
                Console.Write(iterReg.left);
                Console.Write(" -> ");
                foreach (List<string> iterRight in iterReg.right) {
                    foreach (string iterString in iterRight) {
                        Console.Write(iterString);
                    }
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }


        // Зайти в функцию с левым значением
        // Проверить насколько велико уже слово
        // пока что не слова, как проверять?
        // Запоминать длину слова

        static List<string> CompRec(string S, int stringCount)
        {
            if (stringCount >= mMax) {
                return null;
            }

            List<string> list_result = new List<string>();
            Regulations regular = new Regulations();
            var tmp = mRegulations.Find(t => t.left == S);
            regular = tmp;

            if (regular.right == null) {
                list_result.Add(S);
                stringCount += S.Length;
                return list_result;
            }
            foreach (var regIter in regular.right) {
                foreach (var element in regIter) {
                    if (mRegulations.FindIndex(t => t.left == element) > -1) {
                        S = element;
                        var sub_list = CompRec(S, stringCount + list_result.Last().Length);
                        if (sub_list == null) {
                            continue;
                        }
                        var tmpList = new List<string>();


                        if (list_result.Count == 0) {
                            foreach (var iter in sub_list) {
                                tmpList.Add(iter);
                            }
                        } else {
                            foreach (var iter in sub_list) {
                                tmpList.Add(list_result.Last() + iter);
                            }
                            list_result.Remove(list_result.Last());
                        }

                        foreach (var iter in tmpList) {
                            list_result.Add(iter);
                        }
                    //} else if (element.Equals(lamb)) {
                    //    Console.WriteLine("Попал на лямбду");

                    } else {
                        list_result.Add(element);
                    }
                }
            }

            for (int i = 0; i < list_result.Count; i++) {

                if (list_result[i].Length > mMax) {
                    list_result.Remove(list_result[i]);
                    i--;
                }
            }

            return list_result;
        }
        
        static void Menu()
        {
            //Console.Write("Из файла? (1/0): ");
            //var isFile = Console.Read();
            var isFile = '1';
            switch (isFile) {
                case '1':
                    try {
                        var path = "file.txt";
                        var fstream = File.OpenRead(path);

                        // преобразуем строку в байты
                        byte[] array = new byte[fstream.Length];

                        // считываем данные
                        fstream.Read(array, 0, array.Length);

                        // декодируем байты в строку
                        string textFromFile = System.Text.Encoding.Default.GetString(array);
                        Console.WriteLine($"Текст из файла: {textFromFile}");
                        textFromFile = textFromFile.Replace(" ", "");

                        // Terminal
                        var index1 = textFromFile.IndexOf("\n");
                        var term = textFromFile.Substring(0, index1);
                        mTerminalList = ConvertStringToStringList(term, ",");

                        // NoTerminal
                        textFromFile = textFromFile.Substring(index1 + 1);
                        index1 = textFromFile.IndexOf("\n");
                        var nterm = textFromFile.Substring(0, index1);
                        mNotTerminalList = ConvertStringToStringList(nterm, ",");

                        // Begin NoTerminal
                        textFromFile = textFromFile.Substring(index1 + 1);
                        index1 = textFromFile.IndexOf("\n");
                        mS = textFromFile.Substring(0, index1 - 1);

                        // Count symbols
                        textFromFile = textFromFile.Substring(index1 + 1);
                        index1 = textFromFile.IndexOf("\n");
                        var temp = textFromFile.Substring(0, index1);
                        var tempSub = ConvertStringToStringList(temp, ",");
                        mMin = Convert.ToInt32(tempSub.First());
                        mMax = Convert.ToInt32(tempSub.Last());

                        // Regular
                        textFromFile = textFromFile.Substring(index1 + 1);
                        mRegulations = ConvertStringToRegulations(textFromFile);

                    }
                    catch {
                        Console.WriteLine("Не удалось считать из файла. Проверьте его наличие и правильность.");
                    }
                    break;

            }
            Console.WriteLine("Введите терминальные символы!");
        }

        private static List<Regulations> ConvertStringToRegulations(string str)
        {
            List<Regulations> list = new List<Regulations>();
            while (str.Length > 1) {
                Regulations regulations = new Regulations();
                regulations.right = new List<List<string>>();
                var index = str.IndexOf("-");
                regulations.left = str.Substring(0, index);

                str = str.Substring(index + 2);
                index = str.IndexOf("\n");
                if (index < 0) {
                    var tmp1 = ConvertStringToStringList(str.Substring(0), "|");
                    foreach (var tmp in tmp1) {
                        regulations.right.Add(ConvertStringToStringList(tmp));
                    }
                    list.Add(regulations);
                    break;
                }

                var tmp2 = ConvertStringToStringList(str.Substring(0, index), "|");
                foreach (var tmp in tmp2) {
                    regulations.right.Add(ConvertStringToStringList(tmp));
                }
                str = str.Substring(index + 1);
                list.Add(regulations);
            }

            return list;
        }
        private static List<string> ConvertStringToStringList(string str)
        {
            List<string> list = new List<string>();
            // str = aaT | lamd
            int i = 0;
            int start = 0;

            if (str == lamb) {
                list.Add(lamb);
                return list;
            }

            while (i < str.Length && mTerminalList.FindIndex(t => t == str.Substring(i, 1)) > -1) {
                i++;
            }
            if (i > 0) {
                list.Add(str.Substring(start, i));
            }
            start = i;
            int j = 0;
            while (i < str.Length && mNotTerminalList.FindIndex(t => t == str.Substring(i, 1)) > -1) {
                list.Add(str.Substring(start, 1));
                i++;
                start = i;
            }
            if (i > start) {
                list.Add(str.Substring(start, j));
            }
            start = i;
            j = 0;
            while (i < str.Length && mTerminalList.FindIndex(t => t == str.Substring(i, 1)) > -1) {
                i++;
                j++;
            }

            if (i > start) {
                list.Add(str.Substring(start, j));
            }


            // list = aa, T

            return list;
        }

        private static List<string> ConvertStringToStringList(string str, string border)
        {
            List<string> list = new List<string>();
            while (str.Length > 0) {
                var index = str.IndexOf(border);
                if (index == -1) {
                    break;
                }
                list.Add(str.Substring(0, index));
                str = str.Substring(index + 1);
            }

            var index1 = str.IndexOf("\r");
            if (index1 < 0) {
                list.Add(str.Substring(0));
            } else {
                list.Add(str.Substring(0, index1));
            }
            return list;
        }
    }
}
