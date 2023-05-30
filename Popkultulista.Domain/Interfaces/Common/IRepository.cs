// <copyright file="IRepository.cs" company="tymonello">
// Copyright (c) tymonello. All rights reserved.
// </copyright>

namespace Popkultulista.Domain.Interfaces.Common;

/// <summary>
/// A base repository interface with methods commons for all repository interfaces.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Checking if the repository is empty.
    /// </summary>
    /// <param name="cancellationToken">Token for cancelling long tasks.</param>
    /// <returns>A value indicating whether the repository is empty.</returns>
    public Task<bool> IsEmptyAsync(CancellationToken cancellationToken);
}