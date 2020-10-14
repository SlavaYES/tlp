using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_1_Interface.Models
{
    public class DocumentModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
