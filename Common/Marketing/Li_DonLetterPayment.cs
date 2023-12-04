using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Marketing
{
   public class Li_DonLetterPayment
    {
        public int PSId { get; set; }
        public string LetterNo { get; set; }
        public string PaymentMethod { get; set; }
        public string ChallanValue { get; set; }
        public string PaymentDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
