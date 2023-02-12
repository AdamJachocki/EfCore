using EfCoreHello.Models.Db;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreHello.ModelConfigurations
{
    public class TodoItemConfig : BaseModelConfig<ToDoItem>
    {
        public override void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                .HasMaxLength(30);

            builder.Property(x => x.Status)
                .HasConversion(new EnumToStringConverter<ToDoItemStatus>());

            builder.Property(x => x.OwnerId)
                .IsRequired();

            builder.HasOne(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId);
        }
    }
}
