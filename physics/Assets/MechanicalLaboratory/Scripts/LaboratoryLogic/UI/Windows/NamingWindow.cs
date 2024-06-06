using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI;
using TMPro;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows
{
    public class NamingWindow : MonoBehaviour, INamingWindow
    {
        [SerializeField]
        private TextMeshProUGUI _namingText;


        public void SetName(string nameEquipment)
        {
            _namingText.text = nameEquipment;
        }


        public new bool isActiveAndEnabled() => ((MonoBehaviour)this).isActiveAndEnabled;

        public void SetActive(bool active) => gameObject.SetActive(active);

        public void SetTransform(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }
    }
}
