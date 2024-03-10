using Application.Interface;
using Application.Services;
using Bank.Models;
using Bank.Security;
using DataAccess.AppDbContext;
using DataAccess.Repository;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var constring = @"Data Source = SPEED; Integrated Security = True; Initial Catalog = Bank2; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(constring));
builder.Services.AddTransient<ICardRepository, EFCardRepository>();
builder.Services.AddTransient<IOperationRepository, EFOperationRepository>();
builder.Services.AddTransient<ICardService, CardService>();
builder.Services.AddTransient<IOperationService, OperationService>();
builder.Services.AddAuthentication("CardCookie").AddCookie("CardCookie", options => options.Cookie.Name = "CardCookie");
builder.Services.AddAuthorization(opts => opts.AddPolicy("PartiallyAuthorized", policy => policy.RequireClaim("User")));
builder.Services.AddAuthorization(opts => opts.AddPolicy("Fulluser", policy => policy.RequireClaim("FullUser")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISecurityRetriver, SecurityRetriever>();

builder.Services.AddSession();
builder.Services.AddMvc();
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
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Card}/{action=Index}/{id?}");

app.Run();

