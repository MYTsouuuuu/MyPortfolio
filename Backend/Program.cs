using Microsoft.EntityFrameworkCore;
using MyPortfolioApi.Data; // 引用 Data namespace

var builder = WebApplication.CreateBuilder(args);

// 1. 【加入這段】 定義 CORS 策略名稱
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// 2. 【加入這段】 加入 CORS 服務
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // 設定允許前端的網址 (Vue 預設是 http://localhost:5173)
                          // 如果您的 Vue port 不一樣，請改成您的 port
                          policy.WithOrigins("http://localhost:5173")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// [變更 1] 加入 Controller 服務
// 以前 Minimal API 不需要這行，但現在需要
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// [新增] 註冊 DbContext 並設定使用 SQLite
// 從 appsettings.json 讀取連線字串
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 3. 【加入這段】 啟用 CORS 中介軟體
// 注意！！這行必須放在 UseAuthorization 之前，MapControllers 之前
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

// [變更 2] 對應 Controller 的路由
// 這行指令會自動掃描所有的 Controller 類別並建立路由表
app.MapControllers();

// 注意：原本寫在這裡的 app.MapGet(...) 等 Minimal API 程式碼可以刪除了

app.Run();