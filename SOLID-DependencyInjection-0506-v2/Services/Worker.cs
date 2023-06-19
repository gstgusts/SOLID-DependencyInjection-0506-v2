namespace SOLID_DependencyInjection_0506_v2.Services
{
    public class Worker : IWorker
    {
        private readonly IMessageWriter _messageWriter;
        
        public Worker(IMessageWriter messageWriter) {
            _messageWriter = messageWriter;
        }

        public void DoWork()
        {
            _messageWriter.Write("Do work 1");
            Console.WriteLine("Do work 2");
        }
    }
}
