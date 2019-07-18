using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
    {
    public class SalesRecord
        {

        public int ID { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double BaseSalary { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord ( )
            {
            }

        public SalesRecord ( int iD, DateTime date, double amount, double baseSalary, Seller seller )
            {
            ID = iD;
            Date = date;
            Amount = amount;
            BaseSalary = baseSalary;
            Seller = seller;
            }
        }
    }
