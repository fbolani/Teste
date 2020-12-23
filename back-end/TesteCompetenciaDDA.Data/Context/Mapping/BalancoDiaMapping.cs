using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteCompetenciaDDA.Domain.Entities;

namespace TesteCompetenciaDDA.Data.Context.Mapping
{
    internal class BalancoDiaMapping
    {
        public static void Map(ModelBuilder builder) => MapTable(builder.Entity<BalancoDia>());

        private static void MapTable(EntityTypeBuilder<BalancoDia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Data).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ValorCredito).HasColumnType("money").IsRequired();
            builder.Property(x => x.ValorDebito).HasColumnType("money").IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnType("money").IsRequired();

            builder.ToTable("BalancoDia");
        }
    }
}