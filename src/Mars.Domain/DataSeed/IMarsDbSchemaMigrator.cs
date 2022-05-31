namespace Mars.Domain.DataSeed;

public interface IMarsDbSchemaMigrator
{
    Task MigrateAsync();
}