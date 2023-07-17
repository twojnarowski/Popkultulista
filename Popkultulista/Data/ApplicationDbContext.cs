﻿//<auto-generated />
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Popkultulista.Domain.Models.Identity;

namespace Popkultulista.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}