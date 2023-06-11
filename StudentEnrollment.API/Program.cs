using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Configure the DbContext. Connection string must be added to appsettings.json
var conn = builder.Configuration.GetConnectionString("StudentEnrollmentDbConnection");
builder.Services.AddDbContext<StudentEnrollmentDbContext>(options =>
{
    options.UseSqlServer(conn);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding CORS for EnrollmentApp, very permissive. We can secure our API in other ways.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Using CORS policy (Cross Origin Resource Sharing) configured above
app.UseCors("AllowAll");

app.MapCourseEndpoints();

app.MapStudentEndpoints();

app.MapEnrollmentEndpoints();

app.Run();