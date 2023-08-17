namespace BSATask.UI.Models
{
    public class StateTask
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public string? Name { get; set; }
        public OperationsWthTasks Operation { get; set; }
        public StateTask()
        { 
            Random random = new Random();
            var index = random.Next(0, (int)Enum.GetNames(typeof(OperationsWthTasks)).Length -1);
            Operation = (OperationsWthTasks)Enum.GetValues(typeof(OperationsWthTasks)).GetValue(index);
        }
    }
}
