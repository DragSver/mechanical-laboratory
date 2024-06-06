using UnityEngine;
using Zenject;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private global::MechanicalLaboratory.Scripts.PlayerLogic.PlayerLogic _playerLogic;

        public override void InstallBindings()
        {
            Container.
                Bind<global::MechanicalLaboratory.Scripts.PlayerLogic.PlayerLogic>().
                FromInstance(_playerLogic).
                AsSingle();
        }
    }
}