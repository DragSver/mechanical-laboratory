using System.Collections.Generic;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects.InitialEquipmentData
{
    [CreateAssetMenu(fileName = "InitialEquipmentConfig", menuName = "Initial Equipment Config", order = 1)]
    public class InitialEquipmentsConfig : ScriptableObject
    {
        public List<LaboratoryLogic.ScriptableObjects.InitialEquipmentData.InitialEquipmentData> Config;
    }
}
