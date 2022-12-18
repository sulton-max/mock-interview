﻿using MockInterview.Core.Models.Common;

namespace MockInterview.DAL.Models.Query;

public class IncludeOptions<TEntity> where TEntity : class, IEntity
{
    public IncludeOptions()
    {
        IncludeModels = new List<string>();
    }

    public IEnumerable<string> IncludeModels { get; set; }
}