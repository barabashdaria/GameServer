namespace GameServer.Responses
{
    public class PutGameResponse
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Ganre { get; set; }
        public float Score { get; set; }
        public Guid Id { get; set; }
    }
}
