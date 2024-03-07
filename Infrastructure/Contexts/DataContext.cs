using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<FeatureEntity> Features { get; set; }
    public DbSet<FeatureItemEntity> FeatureItems { get; set; }
    public DbSet<ShowcaseEntity> Showcase { get; set; }
    public DbSet<BrandEntity> Brands { get; set; }
    public DbSet<ManageWorkEntity> Manage { get; set; }
    public DbSet<TextIconEntity> TextAndIcon { get; set; }
    public DbSet<DownloadAppEntity> DownloadApp { get; set; }
    public DbSet<AppEntity> App { get; set; }
    public DbSet<TopToolEntity> TopTool { get; set; }
    public DbSet<ToolEntity> Tool { get; set; }
}
