using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace SclBaseball.Data
{
    public class GameConfiguration : DbConfiguration
    {
        public GameConfiguration()
        {
#if !DEBUG
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
#endif
        }
    }
}