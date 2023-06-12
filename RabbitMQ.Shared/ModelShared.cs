namespace RabbitMQ.Shared
{
    public class ModelShared
    {
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}