using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Models;

namespace MyPortfolioApi.Data;

// 繼承自 DbContext
public class AppDbContext : DbContext
{
    // 建構子：接收設定選項 (例如連線字串)，並傳給父類別 #
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSet<T> 代表資料庫中的一張資料表 (Table)
    // 這裡表示資料庫會有一張表叫做 "PortfolioItems"
    public DbSet<Project> Projects { get; set; }
}