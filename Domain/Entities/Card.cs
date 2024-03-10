namespace Domain.Entities
{
    public class Card
    {
        public int id {  get; set; }

        public string number { get; set; }

        public int password { get; set; }

        public double balance { get; set; }

        public bool blocking { get; set; }
    }
}
