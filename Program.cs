// QE@Home distance learning mini-site
// Queen Elizabeth's School, Dubai Sports City
//
// A standalone ASP.NET Core MVC application. The controller, model and views
// are self-contained so they can be lifted into the main school website
// (see README.md for integration notes).

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Section pages live at /qe-at-home/{slug}, for example /qe-at-home/pre-prep.
app.MapControllerRoute(
    name: "qeathome",
    pattern: "qe-at-home/{slug?}",
    defaults: new { controller = "QEatHome", action = "Section" });

// When run on its own, send the site root to the guide's welcome page.
app.MapGet("/", () => Results.Redirect("/qe-at-home"));

app.Run();
