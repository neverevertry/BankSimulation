using DataAccess.AppDbContext;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess.Repository
{
    public class EFCardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<double> GetBalanceByNumberAsync(string number)
        {
            
            return await _context.card.Where(x => x.number == number).Select(x => x.balance).FirstOrDefaultAsync();
        }

        public async Task<Card> GetCardByNumberAsync(string number)
        {
            return await _context.card.FirstOrDefaultAsync(x => x.number == number);
        }


        public async Task<Card> UpdateAsync(Card card)
        {
            _context.card.Update(card);
            
            await _context.SaveChangesAsync();

            return card;
        }
    }

}