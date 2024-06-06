using MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects.Level;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LaboratoryContext", menuName = "Laboratory Context", order = 1)]
    public class LaboratoryContext : ScriptableObject
    { 
        public LaboratoryLevel CurrentLevel;
        public LaboratorySettings LaboratorySettings;
    }
}
