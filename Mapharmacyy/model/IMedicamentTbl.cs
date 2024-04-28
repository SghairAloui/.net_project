using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapharmacyy.model
{
    class IMedicamentTbl
    {
        private SqlConnection connection;

        public IMedicamentTbl(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<IMedicamentTbl> GetAllAgents()
        {
            List<IMedicamentTbl> agents = new List<IMedicamentTbl>();
            string query = "SELECT * FROM AgentTbl";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

            }
            reader.Close();
            return agents;
        }

       
    }
}
