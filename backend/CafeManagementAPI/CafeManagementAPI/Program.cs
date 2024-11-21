using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CafeManagementAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using CafeManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ cho DbContext với SQL Server
builder.Services.AddDbContext<CafeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thêm các dịch vụ cho controller và sử dụng NewtonsoftJson
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Thêm các dịch vụ khác như Swagger nếu cần thiết
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cafe Management API V1");
    });
}

app.Run();
