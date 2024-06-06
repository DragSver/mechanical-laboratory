using UnityEngine;

namespace MechanicalLaboratory.Scripts.PlayerLogic.Interfaces
{
    public interface IMoveController
    {
        public void Init(Transform transform);
        public void Move();
        public void Rotation();
        public void UpdateLocation();
    }
}
