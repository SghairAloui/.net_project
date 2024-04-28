using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapharmacyy.entitie
{
    class FabricantTbl
    {
        public int FabNum { get; set; }
        public string FabNom { get; set; }
        public string FabAd { get; set; }
        public string FabTel { get; set; }
        public string FabDescr { get; set; }

        public FabricantTbl(int fabNum, string fabNom, string fabAd, string fabTel, string fabDescr)
        {
            FabNum = fabNum;
            FabNom = fabNom;
            FabAd = fabAd;
            FabTel = fabTel;
            FabDescr = fabDescr;
        }
    }
}
