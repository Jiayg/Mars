namespace Mars.EntityFrameworkCore;

public static class MarsDbContextModelBuilderExtensions
{
    public static void ConfigureMars([NotNull] this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(MarsConsts.DbTablePrefix + "YourEntities", MarsConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.TryConfigureObjectExtensions<MarsDbContext>();
    }
}