using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dal.Entity;

namespace DigitalCensus.Dotnet.Dal
{
    public class DbInitializer : CreateDatabaseIfNotExists<DigitalCensusDbContext>
    {
        
        protected override void Seed(DigitalCensusDbContext context)
        {
            base.Seed(context);
        }
    }
}
