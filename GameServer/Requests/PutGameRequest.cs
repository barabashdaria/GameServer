namespace GameServer.Requests
{
    public class PutGameRequest
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Ganre { get; set; }
        public float Score { get; set; }
    }
}
