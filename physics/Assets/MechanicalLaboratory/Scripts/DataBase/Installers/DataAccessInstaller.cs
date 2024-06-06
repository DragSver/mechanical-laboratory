using MechanicalLaboratory.Scripts.DataBase.Interfaces;
using Zenject;

namespace MechanicalLaboratory.Scripts.DataBase.Installers
{
    public class DataAccessInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDataAccess>()
                .To<SqliteDataAccess>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}