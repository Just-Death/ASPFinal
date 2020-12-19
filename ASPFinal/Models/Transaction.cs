using ASPFinal.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [ForeignKey("FK_SenderProductId")]
        public int? SenderProductId { get; set; }
        public BankProduct SenderProduct { get; set; }
        [ForeignKey("FK_RecieverProductId")]
        public int? RecieverProductId { get; set; }
        public BankProduct RecieverProduct { get; set; }

        public User User { get; set; }
    }
}
