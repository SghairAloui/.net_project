using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapharmacyy.entitie
{
    class FactureTb1
    {
        public int FactNum { get; set; }
        public int AgNum { get; set; }
        public DateTime FactDate { get; set; }
        public decimal FactMontant { get; set; }

        public FactureTb1(int factNum, int agNum, DateTime factDate, decimal factMontant)
        {
            FactNum = factNum;
            AgNum = agNum;
            FactDate = factDate;
            FactMontant = factMontant;
        }
    }


}
