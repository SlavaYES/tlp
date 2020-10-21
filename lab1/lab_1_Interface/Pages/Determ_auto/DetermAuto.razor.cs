using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab_1_Interface.Models;

namespace lab_1_Interface.Pages.Determ_auto
{
    public partial class DetermAuto
    {
        DeterministicAutomationModel DeterAuto= new DeterministicAutomationModel();
        string ErrorMessage;
        protected override void OnInitialized()
        {
            DeterAuto.lang = new Dictionary<string, Dictionary<string, string>>();
            DeterAuto.states = new List<string>();
            DeterAuto.terminal = new List<string>();
            DeterAuto.endStates = new List<string>();
            DeterAuto.statusString = new string[5] {
                "Цепочка принадлежит",
                "Цепочка не пренадлежит",
                "Неверный Символ",
                "Нет перехода, цепочка принадлежит",
                "Нет перехода, цепочка не принадлежит"
            };
        }

        public void ShowError(string error)
        {
            ErrorMessage = error;
        }

        public void addRowClick(object s, EventArgs e)
        {
            //if () {
            //    ShowError("Сначала добавьте как минимум один столбец!");
            //    return;
            //}
        }
    }
}
