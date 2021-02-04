using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreditCalculator.Models;

namespace CreditCalculator.Service
{
    public class Calc
    {
        //Аннуитетный платеж
        public double Annuitet(int sum, int time, int term)
        {
            double A;
            double K;
            int n = time;
            double i = (double)(term * 0.01) / 12;

            K = (Math.Pow(1 + i, n) * i) / (Math.Pow(1 + i, n) - 1);
            A = K * sum;

            return Math.Round(A, 2);
        }

        // переплата
        public double OverPayments(int sum, int time, double annuitet)
        {
            return Math.Round(time * annuitet - sum, 2);
        }

        //итоговая сумма
        public double Total(int sum, int time, double annuitet)
        {
            return Math.Round(sum + (time * annuitet - sum), 2);
        }

        //график платежей по месяцам
        public List<PaymentModel> GetItemsByMonth(int sum, int time, double A, int term)
        {
            List<PaymentModel> items = new List<PaymentModel>();
            DateTime date = DateTime.Now.Date;
            double i = (double)(term * 0.01) / 12;
 
            double DebtCalc = sum;
            double TermCalc;
            double TermPersentCalc;
            for ( int j = 0; j < time; j++)
            {
                TermCalc = Math.Round((DebtCalc * i), 2); //платеж по процентам
                TermPersentCalc = Math.Round((A - TermCalc), 2); // платеж по основному долгу
                items.Add(new PaymentModel() { Id = j + 1, Date = date, Term = TermCalc, TermPersent = TermPersentCalc, Debt = Math.Round((DebtCalc - TermPersentCalc), 2) });
                date = date.Date.AddMonths(1);
                DebtCalc -= TermPersentCalc;
            }
            return items;
        }
    }
}