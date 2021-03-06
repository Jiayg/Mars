namespace Mars.Domain.DataSeed;

/* This is used if database provider does't define
 * IMarsDbSchemaMigrator implementation.
 */

public class NullMarsDbSchemaMigrator : IMarsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}