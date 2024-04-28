using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapharmacyy.entitie
{
    class MedicamentTbl
    {
        public int MedNum { get; set; }
        public string MedNom { get; set; }
        public decimal MedPrix { get; set; }
        public int MedQte { get; set; }
        public FabricantTbl MedFab { get; set; }
        public DateTime MedExp { get; set; }

        public MedicamentTbl(int medNum, string medNom, decimal medPrix, int medQte, FabricantTbl medFab, DateTime medExp)
        {
            MedNum = medNum;
            MedNom = medNom;
            MedPrix = medPrix;
            MedQte = medQte;
            MedFab = medFab;
            MedExp = medExp;
        }
    }
}
