namespace Mission08_Team38v2.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;
        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        public List<Task> Tasks => _context.Tasks.ToList();
        public List<Category> Categories => _context.Categories.ToList();

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void EditTask(Task task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
