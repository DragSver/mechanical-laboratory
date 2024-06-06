using MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Equipments
{
    public class Tripod : Pickable
    {
        [SerializeField] private UpperCrossbar _upperCrossbar;
        [SerializeField] private LowerCrossbar _lowerCrossbar;
        
        [SerializeField] private InformationWindowTripod _informationWindowTripod;
        
        public void SetHeightUpperCrossbar(float height)
        {
            if (height < _lowerCrossbar.Height + 0.03) 
                SetHeightLowerCrossbar(height - 0.03f);
            _upperCrossbar.SetHeight(height);
        }
        public void SetHeightLowerCrossbar(float height)
        {
            if (height > _upperCrossbar.Height - 0.03) 
                SetHeightUpperCrossbar(height + 0.03f);
            _lowerCrossbar.SetHeight(height);
        }

        public void SetRotateUpperCrossbar(float rotate)
        {
            _upperCrossbar.SetRotate(rotate);
        }
        public void SetRotateLowerCrossbar(float rotate)
        {
            _lowerCrossbar.SetRotate(rotate);
        }
    }
}