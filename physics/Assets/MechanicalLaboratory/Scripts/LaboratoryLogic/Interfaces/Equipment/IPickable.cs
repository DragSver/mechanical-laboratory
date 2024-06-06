using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment
{
    public interface IPickable : IInteractable
    {
        public bool InHand { get; set; }
        
        public ActionResult<string> PickUp(GameObject hand);
        public ActionResult<string> PickDown(GameObject parent, Vector3 hitPoint);

    }
}
