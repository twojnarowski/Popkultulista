// <copyright file="FomoList.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

using Popkultulista.Domain.Models.Common;

namespace Popkultulista.Domain.Models;

/// <summary>
///
/// </summary>
public class FomoList : NamedEntity
{
    public ICollection<FomoItem> FomoItems { get; set; }

}