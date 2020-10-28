using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab2.Interface.Models
{
    public class Table
    {
        public List<Row> Rows { get; set; }
    }
    public class Row
    {
        public string NotTerm { get; set; }
        public List<Cell> Reg { get; set; }
    }
    public class Cell
    {
        public string Term { get; set; }
        public string NotTerm { get; set; }
    }
}
