using MechanicalLaboratory.Scripts.LaboratoryLogic.ScriptableObjects;
using MechanicalLaboratory.Scripts.StepHandler;
using MechanicalLaboratory.Scripts.StepHandler.Interfaces;
using MechanicalLaboratory.Scripts.StepHandler.UI;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Installers
{
    public class StepControllerInstaller : MonoInstaller
    {
        [SerializeField] private LaboratoryContext _laboratoryContext;
        [SerializeField] private StepWindow _stepWindow;

        public override void InstallBindings()
        {
            var stepController = new StepController(_laboratoryContext.CurrentLevel.CurrentExecutionSteps, _stepWindow);
            
            Container
                .Bind<IStepController>()
                .To<StepController>()
                .FromInstance(stepController)
                .AsSingle();
        }
    }
}