using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DataStructure.TaskProblem
{
    public class TaskManager
    {
        private  SemaphoreSlim _pool;
        private List<Func<Task>> _tasks = new();

        public TaskManager()
        {
            _pool = new SemaphoreSlim(initialCount: 4,4);

        }

        public void AddTask(Func<Task> task)
        {
            _tasks.Add(task);
        }
        public async Task Run()
        {
            var runningTasks = new List<Task>();
            foreach (var taskFunc in _tasks)
            {
                await _pool.WaitAsync();

                var task = Task.Run(async () =>
                {
                    try
                    {
                        await taskFunc();
                    }
                    finally

                    {
                        _pool.Release();
                    }
                });

                runningTasks.Add(task);
            }
            await Task.WhenAll(runningTasks);
            

         
        }
    }

    public interface ITaskCreate
    {
        Task TaskAsync();
    }

    public class TaskCreate1 : ITaskCreate
    {
        public async Task TaskAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine($"taskCreate1");
        }
    }

    public class TaskCreate2 : ITaskCreate
    {
        public async Task TaskAsync()
        {
            await Task.Delay(1000);
            Console.WriteLine($"taskCreate2");
        }
    }

    public class ClientTask
    {
        private readonly ITaskCreate _taskCreate;

        public ClientTask(ITaskCreate taskCreate)
        {
            _taskCreate = taskCreate;
        }
        public ClientTask(){}
        public  async Task Run()
        {
            // var task1 = _taskCreate.TaskAsync();
            // var task2 = _taskCreate.TaskAsync();
            // var task3 = _taskCreate.TaskAsync();
            // var task4 = _taskCreate.TaskAsync();
            // var task5 = _taskCreate.TaskAsync();

            // await Task.WhenAll(task1, task2, task3, task4, task5);


            var taskManager = new TaskManager();

            taskManager.AddTask(() => new TaskCreate1().TaskAsync());
            taskManager.AddTask(() => new TaskCreate2().TaskAsync());
            taskManager.AddTask(() => new TaskCreate1().TaskAsync());
            taskManager.AddTask(() => new TaskCreate1().TaskAsync());
            taskManager.AddTask(() => new TaskCreate2().TaskAsync());
            taskManager.AddTask(() => new TaskCreate2().TaskAsync());

            await taskManager.Run();
        }
    }
}