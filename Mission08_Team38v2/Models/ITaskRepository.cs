namespace Mission08_Team38v2.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        List<Category> Categories { get; }

        public void AddTask(Task task);

        public void EditTask(Task task);

        public void DeleteTask(Task task);
    }
}
