using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Domain.Exeptions
{
    public enum ExceptionLevel
    {
        Domain,
        Repository,
        Persistance,
        Presentation,
        Service,
        Web
    }
}
