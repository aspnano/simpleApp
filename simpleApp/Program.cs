using Microsoft.EntityFrameworkCore;
using simpleApp.Models;
using simpleApp.Services.Application.ProductService;
using simpleApp.Services.Infrastructure.Mailer;


var builder = WebApplication.CreateBuilder(args); // <--- 1. Create the Builder (ASP.NET convention)

// SERVICES 
// default services added to the service container when creating 'web api project' template
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// adding a database service with some configuration
// -- dynamically insert connection string from appsettings.json (named DefaultConnection)
// -- this is registered with a Scoped lifetime 
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// adding a CRUD style service
// -- these are almost always registered with transient lifetimes
builder.Services.AddTransient<IProductService, ProductService>();

// adding an infrustructure-style service
// -- these are usually transient but can sometimes be scoped or singleton, usually the 3rd-party docs will specify
builder.Services.AddTransient<IMailerService, MailChimpService>();


var app = builder.Build(); // <--- 2. Build the App (ASP.NET convention)



// MIDDLEWARE
// default middleware when choosing create 'web api project'
// Optional: add swagger when running in development mode 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 
app.UseAuthorization(); 
app.MapControllers();

app.Run(); // <--- 3. Run the App (ASP.NET convention)


