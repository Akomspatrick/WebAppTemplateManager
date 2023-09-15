using DocumentVersionManager.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Domain.Interfaces
{
    public interface IModelRepository<T>: IGenericRepository<T> where T : BaseEntity
    {
    }
}
