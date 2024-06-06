using MechanicalLaboratory.Scripts.LaboratoryLogic.Interfaces.UI;
using MechanicalLaboratory.Scripts.LaboratoryLogic.UI.Windows;
using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Installers.UI
{
    public class NamingWindowInstaller : MonoInstaller
    {
        [SerializeField] private NamingWindow _namingWindow;

        public override void InstallBindings()
        {
            Container
                .Bind<INamingWindow>()
                .To<NamingWindow>()
                .FromInstance(_namingWindow)
                .AsSingle();
        }
    }
}