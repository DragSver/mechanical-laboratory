namespace MechanicalLaboratory.Scripts.LaboratoryLogic.Data
{
    public class ActionResult<T>
    {
        public bool Success { get; set; }
        public T Message { get; set; }

        public ActionResult(bool success, T message) 
        {
            Success = success;
            Message = message;
        }
        
        public static ActionResult<string> SuccessResult(string methodName, string objectName) => new (
            true, 
            $"{methodName} {objectName}");
        public static ActionResult<string> FailureAlreadyInHand(string objectName) => new (
            false, 
            $"Объект {objectName} уже находится в руках.");
        public static ActionResult<string> FailureObjectNotInHand(string objectName) => new (
            false, 
            $"Объект {objectName} не находится в руках.");
        public static ActionResult<string> FailureUnsuitableObject() => new(
            false,
            "Неподходящий объект для сборки.");
    }
}
