
using Azure.Storage.Blobs;
using ClotheProjectSystem.Mapper;
using Repo.Interface;
using Repo.Repository;
using Service.Interface;
using Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Mapper
builder.Services.AddAutoMapper(typeof(ApplicationMapper));
//Add Scoped
builder.Services.AddScoped<IClotheRepo, ClotheRepo>();
builder.Services.AddScoped<IClotheService, ClotheService>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IJWTTokenService, JWTTokenService>();
//Azure Blob Storage
builder.Services.AddScoped(_ => new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage")));

//Add Storage
builder.Services.AddMemoryCache();

//builder.Services.AddAutoMapper
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            //you can configure your custom policy
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });

});
var app = builder.Build();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clothes System API V1");
    c.RoutePrefix = string.Empty; // Set the root path for Swagger UI
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
