using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.Equipment;
using MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects.InitialEquipmentData;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.EquipmentImplementation
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Interactable : OutlineParent, IInteractable
    {
        public EquipmentData CurrentEquipmentData { get; private set; }
        [SerializeField] private InitialEquipmentData _initialEquipmentData;
        
        [SerializeField] private InformationWindow _informationWindow;
        
        [Inject] protected UIController _uiController;

        protected override void Awake()
        {
            base.Awake();
            CurrentEquipmentData = _initialEquipmentData.EquipmentData;
        }
        
        public void OnMouseEnter()
        {
            OnOutline();
            _uiController.CallName(CurrentEquipmentData.Name);
        }
        public void OnMouseExit()
        {
            OffOutline();
            _uiController.ClearName();
        }

        public void CallInfo()
        {
            if (_informationWindow is not null) 
                _uiController.CallInformationWindow(_informationWindow, CurrentEquipmentData);
            else 
                _uiController.CallDefaultInformationWindow(CurrentEquipmentData);
        }
    }
}
