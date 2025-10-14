using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DataStructure.TaskProblem
{
    public class TaskManager
    {
        private SemaphoreSlim _pool;
        private List<Func<Task>> _tasks = new();

        public TaskManager()
        {
            _pool = new SemaphoreSlim(initialCount: 4, 4);

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
        public ClientTask() { }
        public async Task Run()
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

    public class ClientSemaphore
    {
        public async static Task Run()
        {
            var tasks = new List<Task>();

            for (int i = 1; i <= 5; i++)
            {
                int taskId = i;
                var task = Task.Run(async () =>
                {
                    Console.WriteLine($"task {taskId} started.");
                    await Task.Delay(1000);
                    Console.WriteLine($"Task {taskId} finished.");
                });

                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }

    public interface IConcreate
    {
        Task<object> Run();
    }
    public class APIExemple : IConcreate
    {
        public  Task<object> Run()
        {
           return  Task.FromResult<object>("API test");
        }
    }

    public class DataBaseExample : IConcreate
    {
        public  Task<object> Run()
        {
            return Task.FromResult<object>(new User{Name="Omid"});
        }
    }

    public class FileExample : IConcreate
    {
        public async Task<object> Run()
        {
            return Task.FromResult<object>(10);
        }
    }

    public class User
    {
        public string Name { get; set; }
    }

    public class ClientConCurrent
    {
        private List<IConcreate> _concreates;
        
        public ClientConCurrent(params IConcreate[] concreate)
        {
            _concreates = new List<IConcreate>(concreate);
            
        }
        public async Task<object> Run()
        {
            List<Task<Object>> allTasks = new List<Task<object>>();

            foreach (var concreate in _concreates)
            {
                Task<object> task = concreate.Run();
                allTasks.Add(task);
            }

            while (allTasks.Count > 0)
            {
                Task<object> completedTask = await Task.WhenAny(allTasks);

                if (completedTask.Status == TaskStatus.RanToCompletion)
                {
                    return completedTask.Result;
                }
                else
                {
                    allTasks.Remove(completedTask);
                }
            }
            
            throw new Exception("All tasks failed");
        }
    }

}
            