using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BankProductId { get; set; }
        public BankProduct BankProduct { get; set; }
    }
}
