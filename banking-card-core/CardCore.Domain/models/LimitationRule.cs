using CardCore.Domain.Models.BaseModels;

namespace CardCore.Domain.Models
{
    public class LimitationRule: Rule
    {
        public double DailyTransactionAmount { get; set; }
        public double MonthlyTransactionAmount { get; set; }
    }
}