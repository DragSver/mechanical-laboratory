using System;
using System.Collections.Generic;
using MechanicalLaboratory.Scripts.StepHandler.Data;
using UnityEngine;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects.Level
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
    public class LaboratoryLevel : ScriptableObject
    { 
        public byte LevelId;
        public string LevelName;
        public string LevelDescription;
        
        public bool ResetProgress;
        
        public TimeSpan ExecutionTime;

        public List<Step> CurrentExecutionSteps;
        [SerializeField] private List<Step> _initExecutionSteps;

        public void OnEnable()
        {
            if (ResetProgress || CurrentExecutionSteps.Count == 0)
            {
                ResetProgress = false;
                CurrentExecutionSteps = new List<Step>();
                foreach (var step in _initExecutionSteps)
                {
                    var newStep = step;
                    CurrentExecutionSteps.Add(newStep);
                }
            }
        }
    }
}
