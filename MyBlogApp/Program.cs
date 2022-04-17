using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MyBlogApp.Data;
using MyBlogApp.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMasaBlazor();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//内置容器配置依赖关系，作用域单例，解决DbContext创建的问题
builder.Services.AddScoped<DbContext, myblogsContext>();
//配置文档获取连接字符串注入DbContext
builder.Services.AddDbContext<myblogsContext>(
    options => options.UseMySql("name=ConnectionStrings:MySqlConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"))
);

//注入服务类
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<BlogsInfoService>();
builder.Services.AddSingleton<ClassifyInfoService>();
builder.Services.AddSingleton<LabelInfoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
