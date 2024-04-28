using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapharmacyy.model
{
    class IFabricantTbl
    {
        private SqlConnection connection;

        public IFabricantTbl(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<IFabricantTbl> GetAllFabricants()
        {
            List<IFabricantTbl> fabricants = new List<IFabricantTbl>();
            string query = "SELECT * FROM FabricantTbl";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

            }
            reader.Close();
            return fabricants;
        }


    }
}
