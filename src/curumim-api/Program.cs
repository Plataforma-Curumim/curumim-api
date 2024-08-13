using curumim_api.Infra.Configuration;
using curumim_api.Infra.Middleware;
using System.Reflection;
using System.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddUseCaseConfiguration();
builder.Services.AddRepositoryConfiguration();
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
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
//app.UseMiddleware<TraceMiddleware>();
//app.UseAuthentication();
//app.UseAuthorization();

app.Run();