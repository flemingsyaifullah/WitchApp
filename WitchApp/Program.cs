using WitchApp.Interfaces.Impl;
using WitchApp.Interfaces;
using WitchApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Register services for dependency injection
builder.Services.AddScoped<IKillCalculatorService, KillCalculatorService>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IKillRuleService, FibonacciKillRuleService>();

// Register Facade
builder.Services.AddScoped<WitchFacade>();

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
