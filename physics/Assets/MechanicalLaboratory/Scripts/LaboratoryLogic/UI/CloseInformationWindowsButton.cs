using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI
{
    public class CloseInformationWindowsButton : MonoBehaviour
    {
        [Inject] private UIController _uiController;

        public void CloseInformationWindows()
        {
            _uiController.ClearInfo();
        }
        
    }
}