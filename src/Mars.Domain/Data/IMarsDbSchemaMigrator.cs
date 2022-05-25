namespace Mars.Domain.Data;

public interface IMarsDbSchemaMigrator
{
    Task MigrateAsync();
}
