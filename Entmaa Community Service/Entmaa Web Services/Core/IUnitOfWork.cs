using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entmaa_Web_Services.Core
{
    public interface IUnitOfWork : IDisposable
    {


        int CompleteWork();
    }
}
