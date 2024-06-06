using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI;
using TMPro;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows.InformationWindow
{
    public class InformationWindow : MonoBehaviour, IInformationWindow
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;

        protected virtual void Awake()
        {
            ClearInfo();
        }

        public void CallInfo(EquipmentData equipment)
        {
            _name.text = equipment.Name;
            _description.text = equipment.Description;
        }
        public void ClearInfo()
        {
            _name.text = "";
            _description.text = "";
        }


        public bool IsActiveAndEnabled() => isActiveAndEnabled;

        public void SetActive(bool active) => gameObject.SetActive(active);
    }
}
