using System.Threading.Channels;

/*
Thread thread = Thread.CurrentThread;

Console.WriteLine($"Name: {thread.Name}");
thread.Name = "Test";
Console.WriteLine($"Name: {thread.Name}");
Console.WriteLine($"Id: {thread.ManagedThreadId}");
Console.WriteLine($"Priority: {thread.Priority}");
Console.WriteLine($"State: {thread.ThreadState}");
Console.WriteLine($"Back: {thread.IsBackground}");
Console.WriteLine($"Alive: {thread.IsAlive}");

var domain = Thread.GetDomain();
Console.WriteLine($"Domain: {domain.FriendlyName}");

Thread thread1 = new Thread(Hello);
Thread thread2 = new Thread(new ThreadStart(Hello));
Thread thread3 = new Thread(() => Console.
            WriteLine($"{Thread.CurrentThread.ManagedThreadId} Hello world"));

Thread thread4 = new Thread(Counter);
Thread thread5 = new Thread(new ParameterizedThreadStart(Counter));
Thread thread6 = new Thread(new MyClass().PrintCount);


thread1.Start();
thread2.Start();
thread3.Start();

thread4.Start(50);
thread5.Start(70);
thread6.Start(65);

for (int i = 0; i < 60; i++)
{
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {i}");
}
*/

/*
int count = 0;
object locker = new();
AutoResetEvent autoResetEvent = new AutoResetEvent(true);
Mutex mutex = new();

Thread th1 = new(Counter);
Thread th2 = new(Counter);
Thread th3 = new(Counter);

th1.Start();
th2.Start();
th3.Start();


th2.Join();
th1.Join();
th3.Join();


Console.WriteLine(count);
*/

for (int i = 0; i < 6; i++)
{
    Student student = new(i + 1);
}
    


/*
void Counter()
{
    //count = 1;
    //bool asqueredLock = false;

    for(int i = 0; i < 10000; ++i)
    {
        //Console.WriteLine($"{Thread.CurrentThread.Name} - {count++}");

        // locker sync
        //lock(locker)

        // Monitor sync
        //try
        //{
        //    Monitor.Enter(locker, ref asqueredLock);
        //    {
        //        count++;
        //    }
        //}
        //finally
        //{
        //    if(asqueredLock)
        //        Monitor.Exit(locker);
        //}

        // AutoResetEvent sync
        //autoResetEvent.WaitOne();
        //count++;
        //autoResetEvent.Set();

        // Mutex sync
        mutex.WaitOne();
        count++;
        mutex.ReleaseMutex();

        //Thread.Sleep(10);
    }
        
}
*/

/*
void Hello() 
{
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Hello world");
};

void Counter(object? obj)
{
    if(obj is int count)
        for(int i = 0; i < count; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {i}");
        }
}

class MyClass
{
    public void PrintCount(object? obj)
    {
        if (obj is int count)
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"class {Thread.CurrentThread.ManagedThreadId} - {i}");
            }
    }
}
*/

class Student
{
    static Semaphore semaphore = new Semaphore(3, 3);
    Thread thread;
    int count = 5;

    public Student(int id)
    {
        thread = new(Study);
        thread.Name = $"Student {id}";
        thread.Start();
    }

    public void Study()
    {
        while (count > 0)
        {
            semaphore.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} start study {count}");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.Name} finish study {count}");
            semaphore.Release();
            count--;
            Thread.Sleep(500);
        }
    }
}