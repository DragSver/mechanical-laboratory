using MechanicalLaboratory.Scripts.StepHandler.Interfaces.UI;
using MechanicalLaboratory.Scripts.StepHandler.UI;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Installers.UI
{
    public class StepWindowInstaller : MonoInstaller
    {
        [SerializeField] private StepWindow _stepWindow;

        public override void InstallBindings()
        {
            Container
                .Bind<IStepWindow>()
                .To<StepWindow>()
                .FromInstance(_stepWindow)
                .AsSingle();
        }
    }
}
