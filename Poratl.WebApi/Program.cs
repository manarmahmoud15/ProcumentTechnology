
using AutoMapper;
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.Repository;
using Library.Helpers.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models.ViewModel.Mapping;
using Domain.Abstracts.Administration;
using Domain.Services.Administration;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("MedianestaConnection");
builder.Services.AddDbContext<OECDDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                (path.StartsWithSegments("/hubs")))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };

    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Site"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Site"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])),
    };
});

builder.Services.AddSwaggerGen(options =>

{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Medianesta API V1", Version = "v1" });

    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });


});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
     builder =>
     {
         builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
     });
});
//builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
//builder =>
//{
//    builder.AllowAnyHeader()
//           .AllowAnyMethod()
//           .SetIsOriginAllowed((host) => true)
//           .AllowCredentials();
//}));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    // mc.Internal().MethodMappingEnabled = false;
    mc.ShouldMapMethod = (m => false);
    mc.AddProfile(new AutoMapperProfile());
});
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = int.MaxValue; //300 * 1024 * 1024;
    options.ValueLengthLimit = int.MaxValue;
    options.MemoryBufferThreshold = int.MaxValue;
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IRepositoryResult, RepositoryResult>();
builder.Services.AddScoped<DbContext, OECDDbContext>();
builder.Services.AddTransient(typeof(IBaseApiService<,,,,>), typeof(BaseApiService<,,,,>));
builder.Services.AddTransient<IActionResultResponseHandler, ActionResultResponseHandler>();
builder.Services.AddTransient<IRepositoryActionResult, RepositoryActionResult>();
//builder.Services.AddScoped<ISaveFiles, SaveFiles>();



builder.Services.AddTransient(typeof(IUnitOfWork<,>), typeof(UnitOfWork<,>));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IPriceService, PriceService>();
builder.Services.AddScoped<IProductsService, ProductService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddScoped<IFreelancerServiceService, FreelancerServiceService>();
builder.Services.AddScoped<IElectronicsService, ElectronicsService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<ICommunicationsService, CommunicationsService>();
builder.Services.AddScoped<IUsersJobCategoryService, UsersJobCategoryService>();
builder.Services.AddScoped<IUsersJobStatusService, UsersJobStatusService>();
builder.Services.AddScoped<IUsersJobsService, UsersJobsService>();
builder.Services.AddScoped<IUsersRolesService, UsersRolesService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();
