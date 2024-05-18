using P.Interfaces;
using ServiceCall;
using System.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependencias
builder.Services.AddHttpClient<IApiAccountController, ApiAccountController>(service =>
{
    service.BaseAddress = new Uri(builder.Configuration.GetSection("ApiProject").Value);
}); 

builder.Services.AddHttpClient<IApiUserController, ApiUserController>(service =>
{
    //var httpContextAccessor = builder.Services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>();

    //var token = string.Empty;
    //if (httpContextAccessor.HttpContext.Session.TryGetValue("token", out var tokenBytes))
    //{
    //    token = Encoding.UTF8.GetString(tokenBytes);
    //}

    service.BaseAddress = new Uri(builder.Configuration.GetSection("ApiProject").Value);
    //service.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    //service.DefaultRequestHeaders.Accept.Clear();
    //service.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
