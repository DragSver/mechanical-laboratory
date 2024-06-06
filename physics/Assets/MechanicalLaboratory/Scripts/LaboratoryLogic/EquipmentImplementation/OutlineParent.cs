using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using QuickOutline.Scripts;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation
{
    [RequireComponent(typeof(Outline))]
    public abstract class OutlineParent : MonoBehaviour, IOutline
    { 
        private Outline _outline;
        private const float _widthOfActiveOutline = 3;

        protected virtual void Awake()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineColor = Color.white;
            OffOutline();
        }

        public void OnOutline()
        {
            SetOutlineWidth(_widthOfActiveOutline);
        }
        public void OffOutline()
        {
            SetOutlineWidth(0);
        }
        
        private void SetOutlineWidth(float value)
        {
            _outline.OutlineWidth = value;
        }
    }
}
