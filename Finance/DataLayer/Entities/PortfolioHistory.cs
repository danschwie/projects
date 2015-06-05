using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    [Table("PortfolioHistory")]
    public class PortfolioHistory
    {
        [Key]
        [Column("market_date")]
        public string MarketDate { get; set; }

        [Column("employer_sponsored")]
        public decimal EmployerSponsored { get; set; }

        [Column("rollover_ira")]
        public decimal RolloverIRA { get; set; }

        [Column("traditional_ira")]
        public decimal TraditionalIRA { get; set; }

        [Column("roth_ira")]
        public decimal RothIRA { get; set; }

        [Column("sep_ira")]
        public decimal SepIRA { get; set; }

        [Column("hsa")]
        public decimal HSA { get; set; }
    }
}
