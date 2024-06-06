using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI
{
    public class UIController
    {
        private IInformationWindow _informationWindow;
        private INamingWindow _namingWindow;
        private IWarningWindow _warningWindow;

        private IInformationWindow _currentInformationWindows;

        [Inject]
        public UIController(
            INamingWindow namingWindow, 
            IWarningWindow warningWindow, 
            IInformationWindow informationWindow)
        {
            _namingWindow = namingWindow;
            _warningWindow = warningWindow;
            _informationWindow = informationWindow;
        }

        public void CallInformationWindow(IInformationWindow informationWindow, EquipmentData equipment)
        {
            ClearInfo();
            
            _currentInformationWindows = informationWindow;
            if (!informationWindow.IsActiveAndEnabled())
                informationWindow.SetActive(true);

            informationWindow.CallInfo(equipment);
        }
        
        public void CallDefaultInformationWindow(EquipmentData equipment)
        {
            ClearInfo();
            
            if (!_informationWindow.IsActiveAndEnabled())
                _informationWindow.SetActive(true);

            _informationWindow.CallInfo(equipment);
        }
        public void ClearInfo()
        {
            _currentInformationWindows?.ClearInfo();
            _currentInformationWindows?.SetActive(false);
            _currentInformationWindows = null;
        }

        public void CallName(string name)
        {
            _namingWindow.SetName(name);
        }
        public void ClearName()
        {
            _namingWindow.SetName("");
        }

        public void CallWarning(string warningText)
        {
            _warningWindow.CallWarning(warningText);
        }
    }
}
