namespace Mars.Domain;

public class IdentityDept : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public string FullName { get; set; }

    public int Ordinal { get; set; }

    public long? Pid { get; set; }

    public string Pids { get; set; }

    public string SimpleName { get; set; }

    public string Tips { get; set; }

    public int? Version { get; set; }

    public virtual ICollection<IdentityUser> Users { get; set; }
}