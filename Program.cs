using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Presentation;
using Persistence;
using Services;
using Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
        .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
builder.Services.AddSwaggerGen(c =>
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" }));
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddDbContextPool<RepositoryDbContext>(builder =>
{
    var connectionString = Configuration.GetConnectionString("Database");
    builder.UseNpgsql(connectionString);
});
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");



app.Run();
