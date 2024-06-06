using System.Collections.Generic;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects.Level
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Level Config", order = 1)]
    public class LevelConfig : ScriptableObject
    { 
        public List<LaboratoryLevel> Levels;
    }
}
