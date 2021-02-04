using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class PaymentModel
    {
        [DisplayName("Номер платежа")]
        public int Id { get; set; }

        [DisplayName("Дата платежа")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Размер платежа по основному долгу")]
        public double Term { get; set; }

        [DisplayName("Размер платежа по процентам")]
        public double TermPersent { get; set; }

        [DisplayName("Остаток долга")]
        public double Debt { get; set; }
    }
}