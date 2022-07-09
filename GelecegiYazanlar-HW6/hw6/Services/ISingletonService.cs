using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw6.Services
{
    public interface ISingletonService
    {
        public Guid GetOperationID();
    }
}
