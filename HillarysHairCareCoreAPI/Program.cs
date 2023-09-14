using HillarysHairCareCoreAPI;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHairCareDbContext>(builder.Configuration["HillarysHairCareDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Stylist

app.MapGet("/stylists", (HillarysHairCareDbContext db) =>
{
    return Results.Ok(db.Stylists);
});

#endregion

#region Appointment

app.MapGet("/appointments", (HillarysHairCareDbContext db) =>
{
    var appointments = db.Appointments
        .Include(a => a.Stylist)
        .Include(a => a.Customer)
        .Include(a => a.AppointmentServices)
        .ThenInclude(a => a.Service)
        .OrderBy(a => a.Id)
        .ToList();

    return Results.Ok(appointments);
});

#endregion

#region Customer

app.MapGet("/customers", (HillarysHairCareDbContext db) =>
{
    return Results.Ok(db.Customers);
});

#endregion


app.Run();

