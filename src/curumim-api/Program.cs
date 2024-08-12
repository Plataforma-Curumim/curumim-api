using curumim_api.Infra.Configuration;
using curumim_api.Infra.Middleware;
using System.Reflection;
using System.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddUseCaseConfiguration();
//builder.Services.AddRepositoryConfiguration();
//builder.Services.AddJwtExtensions();
//builder.Services.AddOpenTelemetry(builder.Configuration);
builder.Services.AddFlatValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseStatusCodePages(async statusCodeContext
    => await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
                 .ExecuteAsync(statusCodeContext.HttpContext));

app.UseEndpointConfiguration();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
//app.UseMiddleware<TraceMiddleware>();

app.Run();