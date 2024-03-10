using DataAccess.AppDbContext;
using Domain.Entities;

namespace DataAccess.Repository
{
    public class DataSeed
    {
        private readonly ApplicationDbContext _context;

        public DataSeed(ApplicationDbContext context)
        {
            _context = context;
        }
        public void seed()
        {
            var card = new Card
            {
                balance = 100,
                blocking = false,
                number = 1111111111,
                password = 1111
            };

            var option = new List<DescriptionOperation>
            {
                new DescriptionOperation
                {
                    code = 1,
                    name = "balance"
                },

                new DescriptionOperation
                {
                    code = 2,
                    name = "withdraw"
                },

                new DescriptionOperation
                {
                    code = 3,
                    name = "add"
                }
            };
            _context.AddRange(option);
            _context.Add(card);
            _context.SaveChanges();
        }
    }
}
