using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw6.Services
{
    public class OperationService : ITransientService, IScopedService, ISingletonService
    {
        private Guid id;

        public OperationService()
        {
            id = Guid.NewGuid();
        }

        public Guid GetOperationID()
        {
            return id;
        }
    }
}
