using Api_backend_university.ContextDB;
using Api_backend_university.Repository;
using Api_backend_university.Repository.Imp;
using Api_backend_university.SecurityJWT;
using Api_backend_university.Services;
using Api_backend_university.Services.Imp;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//CONECTION DATABASE
const string connectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(connectionName);
builder.Services.AddDbContext<UniversityDb2Context>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//configuration swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "APIUniversity", Version = "v1" });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //define security for authorization
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using bearer scheme"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
               new OpenApiSecurityScheme
               {
                      Reference = new OpenApiReference
                      {
                          Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                      }
               },
               new string[]{}
        }

    });
});

//ROLES
builder.Services.AddJwtServices(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("studentOnlyPolicy", policy => policy.RequireClaim("StudentOnly", "Student"));
    options.AddPolicy("AdministratorOrUser", policy =>
         policy.RequireRole("Administrator", "User"));
});

builder.Services.AddTransient<IUserRepository, ImpUserRepository>();
builder.Services.AddTransient<IUser, ImpUser>();
builder.Services.AddTransient<ICareerRepository, ImpCareerRepository>();
builder.Services.AddTransient<ICareer, ImpCareer>();
builder.Services.AddTransient<IRolesRepository, ImpRolesRepository>();
builder.Services.AddTransient<IRoles, ImpRoles>();
builder.Services.AddTransient<IStudentRepository, ImpStudentRepository>();
builder.Services.AddTransient<IStudent, ImpStudent>();
builder.Services.AddTransient<IEventRepository, ImpEventRepository>();
builder.Services.AddTransient<ICourseRepository, ImpCourseRepository>();
builder.Services.AddTransient<ICourse, ImpCourse>();
builder.Services.AddTransient<IInscriptionRepository, ImpInscriptionRepository>();
builder.Services.AddTransient<IInscription, ImpInscription>();
builder.Services.AddTransient<IClassRepository, ImpClassRepository>();
builder.Services.AddTransient<IClass, ImpClass>();
builder.Services.AddTransient<ITeacherRepository, ImpTeacherRepository>();
builder.Services.AddTransient<ITeacher, ImpTeacher>();


//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Cors", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDeveloperExceptionPage();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors("Cors");

app.MapControllers();

app.Run();
