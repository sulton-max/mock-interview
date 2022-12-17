﻿using MockInterview.BLL.Services.EntityServices.Interfaces;
using MockInterview.Core.Models.Entities;
using MockInterview.Core.Models.Enums;
using MockInterview.DAL.Repositories.interfaces;

namespace MockInterview.BLL.Services.EntityServices;

/// <summary>
/// Provides methods for SelectionItem item Business Logic
/// </summary>
public class SelectionItemService : EntityServiceBase<SelectionItem, IRepositoryBase<SelectionItem>>, ISelectionItemService
{
    public SelectionItemService(IRepositoryBase<SelectionItem> entityRepository) : base(entityRepository)
    {
    }

    public async Task<IEnumerable<SelectionItem>> GetByCategoryAsync(SelectionItemTypes types)
    {
        return await Task.Run(() =>
        {
            return EntityRepository.Get(x => x.Type == types.ToString()).ToList();
        });
    }
}
