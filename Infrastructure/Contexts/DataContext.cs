using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<UserEntity>(options)
{
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
    public DbSet<SliderEntity> Slider { get; set; }
    public DbSet<SavedCoursesEntity> SavedCourses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserEntity>()
            .HasMany(u => u.Addresses)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<SavedCoursesEntity>().HasKey(sc => new { sc.UserId, sc.CourseId });
    }
}
