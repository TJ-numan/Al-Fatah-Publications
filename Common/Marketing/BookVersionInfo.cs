using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Marketing
{
    public class BookVersionInfo
    {
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public string ClassName { get; set; }
        public string BookType { get; set; }
        public string Edition { get; set; }
        public decimal Price { get; set; }
        public decimal StockQuantity { get; set; }
        public int SerialNo { get; set; }
    }
}
