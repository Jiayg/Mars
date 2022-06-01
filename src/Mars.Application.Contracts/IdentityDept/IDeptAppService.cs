namespace Mars.Application.Contracts.Services.IdentityDept;

public interface IDeptAppService : IApplicationService
{
    /// <summary>
    /// 新增部门
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<Guid> CreateAsync(DeptCreationDto input);

    /// <summary>
    /// 修改部门
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [UnitOfWork]
    Task<bool> UpdateAsync(long id, DeptUpdationDto input);

    /// <summary>
    /// 删除部门
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(long Id);

    /// <summary>
    /// 部门树结构
    /// </summary>
    /// <returns></returns>
    Task<List<DeptTreeDto>> GetTreeListAsync();
}