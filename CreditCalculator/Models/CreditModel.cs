using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class CreditModel
    {
        
        public int Id { get; set; }

        [DisplayName("Сумма кредита")]
        [Range(0, 1000000)]
        [Required(ErrorMessage = "Не введена сумма кредита")]
        public int Amount { get; set; }

        [DisplayName("Срок кредита")]
        [Range(0, 36)]
        [Required(ErrorMessage ="Не введен срок кредита")]
        public int Time { get; set; }

        [DisplayName("Процент по кредиту")]
        [Range(0,100)]
        [Required(ErrorMessage = "Не введена ставка по кредиту")]
        public int Term { get; set; }
    }
}