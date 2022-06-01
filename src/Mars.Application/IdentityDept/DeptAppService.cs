using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mars.Application.Contracts.IdentityDept.Dtos;
using Mars.Application.Contracts.Services.IdentityDept;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;

namespace Mars.Application.Services;

internal class DeptAppService : MarsAppService, IDeptAppService
{
    private readonly IRepository<IdentityDept> _deptRepository;

    public DeptAppService(IRepository<IdentityDept> deptRepository)
    {
        _deptRepository = deptRepository;
    }

    public async Task<Guid> CreateAsync(DeptCreationDto input)
    {
        var isExists = await _deptRepository.AnyAsync(x => x.FullName.Equals(input.FullName));
        if (isExists)
            throw new UserFriendlyException("该部门全称已经存在");

        var dept = ObjectMapper.Map<DeptCreationDto, IdentityDept>(input);
        await _deptRepository.InsertAsync(dept);

        return dept.Id;
    }

    public async Task<bool> DeleteAsync(long Id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<List<DeptTreeDto>> GetTreeListAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<bool> UpdateAsync(long id, DeptUpdationDto input)
    {
        throw new System.NotImplementedException();
    }
}