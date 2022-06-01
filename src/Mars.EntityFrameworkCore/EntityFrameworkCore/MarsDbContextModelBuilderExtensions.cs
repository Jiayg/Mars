namespace Mars.EntityFrameworkCore;

public static class MarsDbContextModelBuilderExtensions
{
    public static void ConfigureMars([NotNull] this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<IdentityDept>(b =>
        {
            b.Property(x => x.FullName).IsRequired().HasMaxLength(IdentityDeptConsts.FullName_MaxLength);
            b.Property(x => x.SimpleName).IsRequired().HasMaxLength(IdentityDeptConsts.SimpleName_MaxLength);
            b.Property(x => x.Tips).HasMaxLength(IdentityDeptConsts.Tips_MaxLength);
            b.Property(x => x.Pids).HasMaxLength(IdentityDeptConsts.Pids_MaxLength);
            b.ConfigureSoftDelete();
        });

        builder.TryConfigureObjectExtensions<MarsDbContext>();
    }
}