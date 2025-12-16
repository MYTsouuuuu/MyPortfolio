using System.ComponentModel.DataAnnotations; // 用於設定必填、長度等

namespace MyPortfolioApi.Models;

public class PortfolioItem
{
    // [Key] 屬性通常可以省略，EF Core 預設會把名為 Id 的欄位當作主鍵 (Primary Key)
    public int Id { get; set; }

    [Required] // 設為必填
    [MaxLength(100)] // 限制最大長度 100
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    // 實用的欄位：記錄建立時間
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}