namespace Mars.Domain.Shared.Dtos;

[Serializable]
public abstract class OutputDto : IOutputDto
{
    public virtual long Id { get; set; }
}