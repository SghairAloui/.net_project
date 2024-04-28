using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Mapharmacyy.model
{
    class IAgentTbl
    {
        private SqlConnection connection;

        public IAgentTbl(SqlConnection connection)
        {
            this.connection = connection;
        }

        public List<IAgentTbl> GetAllAgents()
        {
            List<IAgentTbl> agents = new List<IAgentTbl>();
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
