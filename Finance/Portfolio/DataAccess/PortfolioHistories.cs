using DataLayer;
using DataLayer.Entities;
using System;
using System.Linq;

namespace Portfolio.DataAccess
{
    public partial class PortfolioHistories
    {
        private FinanceContext _FinanceContext = new FinanceContext();

        public PortfolioHistories()
        {
            
        }

        public IQueryable<PortfolioHistory> GetAll()
        {
            IQueryable<PortfolioHistory> query = null;

            try
            {
                query = from ph in _FinanceContext.PortfolioHistories select ph;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return query;
        }
    }
}