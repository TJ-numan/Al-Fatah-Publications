using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Li_DonLetter
    {
        public string LetterNo { get; set; }
        public int PSId { get; set; }
        public decimal DonationAmnt { get; set; }
        public decimal PrevPayment { get; set; }
        public decimal DemandAmnt { get; set; }
        public decimal DueAmnt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
