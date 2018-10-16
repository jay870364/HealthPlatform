using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;

namespace Bossinfo.HealthPlatform.DBService
{
    public class SQLService
    {

        public DataTable SqlQuery(string esqlQuery)
        {
            using (var context = new HealthPaltformContext())
            {
                // Create a query that takes two parameters.
                esqlQuery =
                    @"SELECT TOP (1000) [UID]
      ,[MemberIDNo]
      ,[MIData]
      ,[MIDate]
  FROM [HealthPlatform].[dbo].[MeasureInfo]";

                context.Database.ExecuteSqlCommand(esqlQuery);
            }
        }
    }
}
