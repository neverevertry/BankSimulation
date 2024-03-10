namespace Domain.Entities
{
    public class Operation
    {
        public int id {  get; set; }

        public DateTime data { get; set; }

        public double? sum { get; set; }

        public int cardId { get; set; }

        public Card card { get; set; }

        public int descriptionId { get; set; }
    }
}
