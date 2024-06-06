using MechanicalLaboratory.Scripts.LaboratoryLogic.Data;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects.InitialEquipmentData
{
    [CreateAssetMenu(fileName = "InitialEquipmentData", menuName = "Initial Equipment Data", order = 1)]
    public class InitialEquipmentData : ScriptableObject
    {
        public EquipmentData EquipmentData;
    }
}
