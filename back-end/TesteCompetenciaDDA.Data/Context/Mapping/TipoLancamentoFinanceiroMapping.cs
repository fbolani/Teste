using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.Data.Context.Mapping
{
    internal class TipoLancamentoFinanceiroMapping
    {
        public static void Map(ModelBuilder builder) => MapTable(builder.Entity<TipoLancamentoFinanceiro>());

        private static void MapTable(EntityTypeBuilder<TipoLancamentoFinanceiro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn(); ;
            builder.Property(x => x.Descricao).HasColumnType("varchar(50)").IsRequired();
            builder.HasMany(c => c.Lancamentos).WithOne(e => e.Tipo);

            builder.ToTable("TipoLancamentoFinanceiro");
        }
    }
}