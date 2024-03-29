﻿using ArtifyZone.Minesweeper.Game;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ArtifyZone.Minesweeper.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class MinesweeperDbContext :
    AbpDbContext<MinesweeperDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    public MinesweeperDbContext(DbContextOptions<MinesweeperDbContext> options)
        : base(options)
    {
    }

    public DbSet<Game.Game> Games { get; set; }

    public DbSet<MinePosition> MinePositions { get; set; }

    public DbSet<RevealedPosition> RevealedPositions { get; set; }

    public DbSet<FlaggedPosition> FlaggedMines { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        builder.Entity<Game.Game>(b =>
        {
            b.ToTable(MinesweeperConsts.DbTablePrefix + "Games", MinesweeperConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasMany(g => g.Mines).WithOne();
            b.HasMany(g => g.Revealed).WithOne();
            b.HasMany(g => g.FlaggedMines).WithOne();
            b.Navigation(g => g.Mines).AutoInclude();
            b.Navigation(g => g.Revealed).AutoInclude();
            b.Navigation(g => g.FlaggedMines).AutoInclude();
        });

        builder.Entity<MinePosition>(b =>
        {
            b.ToTable(MinesweeperConsts.DbTablePrefix + "MinePositions", MinesweeperConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<RevealedPosition>(b =>
        {
            b.ToTable(MinesweeperConsts.DbTablePrefix + "RevealedPositions", MinesweeperConsts.DbSchema);
            b.ConfigureByConvention();
        });

        builder.Entity<FlaggedPosition>(b =>
        {
            b.ToTable(MinesweeperConsts.DbTablePrefix + "FlaggedPositions", MinesweeperConsts.DbSchema);
            b.ConfigureByConvention();
        });
    }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
}