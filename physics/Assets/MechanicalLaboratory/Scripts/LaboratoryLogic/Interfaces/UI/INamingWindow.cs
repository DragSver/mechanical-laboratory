using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI
{
    public interface INamingWindow
    {
        public void SetName(string name);
        public bool isActiveAndEnabled();
        public void SetActive(bool active);
        public void SetTransform(Vector3 position,  Quaternion rotation);
    }
}
