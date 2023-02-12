using EfCoreHello.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreHello.ModelConfigurations
{
    public abstract class BaseModelConfig<TModel> : IEntityTypeConfiguration<TModel>
        where TModel : BaseDbItem
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
