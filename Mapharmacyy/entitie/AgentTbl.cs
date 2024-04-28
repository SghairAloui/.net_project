using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapharmacyy.entitie
{
    class AgentTbl
    {
        public int AgNum { get; set; }
        public string AgNom { get; set; }
        public DateTime AdDDn { get; set; }
        public string AgTel { get; set; }
        public char AgSex { get; set; }
        public string AgPass { get; set; }

        public AgentTbl(int agNum, string agNom, DateTime adDDn, string agTel, char agSex, string agPass)
        {
            AgNum = agNum;
            AgNom = agNom;
            AdDDn = adDDn;
            AgTel = agTel;
            AgSex = agSex;
            AgPass = agPass;
        }
    }
}
