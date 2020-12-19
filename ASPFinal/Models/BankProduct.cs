using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPFinal.Models
{
    public class BankProduct
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Description { get; set; }
        [ForeignKey("FK_ProductTypeId")]
        public ProductType ProductType { get; set; }
    }
}
