using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // 記得引用這個，才能用 ToListAsync
using MyPortfolioApi.Data;
using MyPortfolioApi.DTOs;
using MyPortfolioApi.Models;

namespace MyPortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    // 1. 宣告 DbContext 欄位
    private readonly AppDbContext _context;

    // 2. 透過建構子注入 (Dependency Injection)
    public ProjectsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/projects
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
    {
        // 3. 使用 await 非同步讀取資料庫
        // 這是真實的 SQL 查詢：SELECT * FROM Projects
        var projects = await _context.Projects.ToListAsync();

        // 轉換為 DTO
        var dtos = projects.Select(p => new ProjectDto(
            p.Id,
            p.Name,
            p.Description,
            p.Category
        ));

        return Ok(dtos);
    }

    // POST: api/projects
    [HttpPost]
    public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectDto input)
    {
        // 1. DTO -> Entity
        var newProject = new Project
        {
            Name = input.Name,
            Description = input.Description,
            Category = input.Category,
            // CreatedAt = DateTime.Now // 如果您的 Model 有這個欄位
        };

        // 2. 加入到 DbContext (這時還沒寫入資料庫，只是標記為 Added)
        _context.Projects.Add(newProject);

        // 3. 儲存變更 (這時才會產生 SQL INSERT 指令並執行)
        // ID 會在這裡由資料庫自動產生並填回 newProject.Id
        await _context.SaveChangesAsync();

        // 4. Entity -> DTO (回傳給前端)
        var resultDto = new ProjectDto(
            newProject.Id,
            newProject.Name,
            newProject.Description,
            newProject.Category
        );

        return CreatedAtAction(nameof(GetProjects), new { id = resultDto.Id }, resultDto);
    }

    // DELETE: api/projects/{id} (加碼補上刪除功能)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}