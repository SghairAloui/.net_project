using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mapharmacyy.model
{
    class IFactureTbl
    {
        private SqlConnection connection;

        public IFactureTbl(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<IFactureTbl> GetAllAgents()
        {
            List<IFactureTbl> agents = new List<IFactureTbl>();
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

