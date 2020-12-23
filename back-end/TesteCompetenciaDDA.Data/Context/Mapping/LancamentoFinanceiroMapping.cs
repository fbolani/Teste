using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.Data.Context.Mapping
{
    internal class LancamentoFinanceiroMapping
    {
        public static void Map(ModelBuilder builder) => MapTable(builder.Entity<LancamentoFinanceiro>());

        private static void MapTable(EntityTypeBuilder<LancamentoFinanceiro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.DataHora).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("money").IsRequired();
            builder.HasOne(c => c.Tipo).WithMany(e => e.Lancamentos).IsRequired();
            builder.Property(x => x.Status).HasColumnType("bit").IsRequired();

            builder.ToTable("LancamentoFinanceiro");
        }
    }
}