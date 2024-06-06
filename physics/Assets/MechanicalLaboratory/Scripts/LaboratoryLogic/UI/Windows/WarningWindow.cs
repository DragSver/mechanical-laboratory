using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI;
using TMPro;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows
{
    public class WarningWindow : MonoBehaviour, IWarningWindow
    {
        [SerializeField] private TextMeshProUGUI _warningText;

        private readonly float _timeInvoke = 3;


        public void CallWarning(string warningText)
        {
            _warningText.text = warningText;
            Invoke("ClearText", _timeInvoke);
        }

        private void ClearText()
        {
            _warningText.text = "";
        }


        public bool IsActiveAndEnabled() => isActiveAndEnabled;

        public void SetActive(bool active) => gameObject.SetActive(active);
    }
}
