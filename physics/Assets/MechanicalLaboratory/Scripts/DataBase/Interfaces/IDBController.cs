using System;
using System.Threading.Tasks;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;

namespace MechanicalLaboratory.Scripts.DataBase.Interfaces
{
    public interface IDBController<T>
    {
        public Task<ActionResult<string>> Add(T t);
        public Task<ActionResult<T>> Get(Guid id);
    }
}