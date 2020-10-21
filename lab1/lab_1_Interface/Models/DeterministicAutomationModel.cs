using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_1_Interface.Models
{
    public class DeterministicAutomationModel
    {
        public enum AllStates { Recognized = 0, Good = 1, BadSymbol = 2, EmptyCellRecognized = 3, EmptyCellGood = 4 };
        public string[] statusString { get; set; }
        public Dictionary<string, Dictionary<string, string>> lang { get; set; }
        public List<string> states { get; set; }
        public List<string> terminal { get; set; }
        public List<string> endStates { get; set; }
    }
}
