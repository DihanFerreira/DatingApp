using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration); 
builder.Services.AddIdentityServices(builder.Configuration);



var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication(); // do you have a valid token
app.UseAuthorization(); // what are you allowed to do when you have the token


// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
