using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using QualificationCourses;
using QualificationCourses.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("CourseDb"));
builder.Services.AddSingleton<UserStore>();
builder.Services.AddDirectoryBrowser();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();

// Авторизаційний Middleware
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/index.html") ||
       context.Request.Path.StartsWithSegments("/css") ||
       context.Request.Path.StartsWithSegments("/js") ||
       context.Request.Path.StartsWithSegments("/swagger"))
    {
        await next.Invoke();
        return;
    }

    var userStore = context.RequestServices.GetRequiredService<UserStore>();
    var role = context.Request.Headers["Role"].ToString();
    if (!string.IsNullOrEmpty(role) && userStore.ValidRoles.Contains(role))
    {
        context.Items["Role"] = role;
        await next.Invoke();
    }
    else
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized: specify valid Role header");
    }
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();