using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCensus.Dotnet.Dal.Abstract
{
    public interface IEntity
    {
        Guid UniqueKey { get; set; }
    }
}
