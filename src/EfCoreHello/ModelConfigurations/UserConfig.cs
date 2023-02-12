using EfCoreHello.Models.Db;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreHello.ModelConfigurations
{
    public class UserConfig : BaseModelConfig<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
