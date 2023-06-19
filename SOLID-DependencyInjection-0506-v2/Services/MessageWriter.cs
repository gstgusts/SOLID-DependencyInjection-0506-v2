namespace SOLID_DependencyInjection_0506_v2.Services
{
    public class MessageWriter : IMessageWriter
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
