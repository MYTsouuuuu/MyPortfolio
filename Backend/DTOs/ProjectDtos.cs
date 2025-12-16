using System.ComponentModel.DataAnnotations;

namespace MyPortfolioApi.DTOs;

// 1. 用於回傳給前端顯示 (包含 ID)
public record ProjectDto(
    int Id,
    string Name,
    string Description,
    string Category
);

// 2. 用於前端傳入建立 (不包含 ID，因為 ID 是資料庫產生的)
public record CreateProjectDto(
    [Required] string Name,
    [MaxLength(200)] string Description,
    string Category
);