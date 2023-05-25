using Api.Customers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string allowedOriginsPolicy = "allowedOriginsPolicy";
var allowedOrigins = builder.Configuration["AllowedOrigins"]?.Split(',') ?? Array.Empty<string>();

builder.Services.AddCors(opts => {
    opts.AddPolicy(allowedOriginsPolicy, policy => policy.WithOrigins(allowedOrigins));
});

builder.Services.AddControllers();
builder.Services.AddCustomerControllerDependencies();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedOriginsPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
