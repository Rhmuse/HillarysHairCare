using HillarysHairCareCoreAPI;
using HillarysHairCareCoreAPI.Models;
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
    return Results.Ok(db.Stylists.OrderBy(s => s.Id).ToList());
});

app.MapGet("/stylists/active", (HillarysHairCareDbContext db) =>
{
    return Results.Ok(db.Stylists.Where(s => s.IsActive).OrderBy(s => s.Id).ToList());
});


app.MapPost("/stylists/{stylistId}/toggleActivity", (HillarysHairCareDbContext db, int stylistId) =>
{
    Stylist foundStylist = db.Stylists.SingleOrDefault(s => s.Id == stylistId);
    if (foundStylist == null)
    {
        return Results.NotFound();
    }

    foundStylist.IsActive = !foundStylist.IsActive;
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPost("/stylists", (HillarysHairCareDbContext db, Stylist stylist) =>
{
    db.Add(stylist);
    db.SaveChanges();
    return Results.NoContent;
});

#endregion

#region Appointment

app.MapGet("/appointments", (HillarysHairCareDbContext db) =>
{
    var appointments = db.Appointments
        .Where(a => a.IsCanceled == false)
        .Include(a => a.Stylist)
        .Include(a => a.Customer)
        .Include(a => a.AppointmentServices)
        .ThenInclude(a => a.Service)
        .OrderBy(a => a.Id)
        .ToList();

    return Results.Ok(appointments);
});

app.MapPut("/appointments/{id}", (HillarysHairCareDbContext db, int id, Appointment appointment) =>
{
    var foundAppointment = db.Appointments.SingleOrDefault(a => a.Id == id);

    if (foundAppointment == null)
    {
        return Results.NotFound();
    }

    var foundAppointmentServices = db.AppointmentServices.Where(a => id == a.AppointmentId).ToList();

    foundAppointment.StylistId = appointment.StylistId;
    foundAppointment.Date = appointment.Date;

    db.SaveChanges();
    return Results.NoContent();
});

app.MapPost("/appointments/{appointmentId}/cancel", (HillarysHairCareDbContext db, int appointmentId) =>
{
    Appointment? foundAppointment = db.Appointments.SingleOrDefault(a => a.Id == appointmentId);
    if (foundAppointment == null) { return Results.NotFound(); }
    foundAppointment.IsCanceled = true;
    List<AppointmentService> foundAppointmentServices = db.AppointmentServices.Where(a => a.AppointmentId == appointmentId).ToList();
    if (foundAppointmentServices.Count > 0)
    {
        foundAppointmentServices.ForEach(a =>
        {
            a.IsCanceled = true;
        });
    }

    db.SaveChanges();
    return Results.NoContent();
});

app.MapPost("/appointments", (HillarysHairCareDbContext db, Appointment appointment) =>
{
    db.Appointments.Add(appointment);
    db.SaveChanges();
    return Results.Created($"/appointments/{appointment.Id}", appointment);
});

#endregion

#region Customer

app.MapGet("/customers", (HillarysHairCareDbContext db) =>
{
    return Results.Ok(db.Customers);
});

app.MapPost("/customers", (HillarysHairCareDbContext db, Customer customer) =>
{
    db.Customers.Add(customer);
    db.SaveChanges();
    return Results.NoContent();
});

#endregion

#region Service

app.MapGet("/services", (HillarysHairCareDbContext db) =>
{
    return Results.Ok(db.Services);
});

#endregion

#region AppointmentService

app.MapGet("/appointmentservices/{appointmentId}", (HillarysHairCareDbContext db, int appointmentId) =>
{
    List<AppointmentService> foundAppointmentServices = db.AppointmentServices.Where(a => a.AppointmentId == appointmentId).ToList();

    if (foundAppointmentServices.Count <= 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(foundAppointmentServices);
});

app.MapPost("/appointmentservices", (HillarysHairCareDbContext db, List<AppointmentService> appointmentServices) =>
{
    foreach (AppointmentService appointmentService in appointmentServices)
    {
        db.AppointmentServices.Add(appointmentService);
    }
    db.SaveChanges();
    return Results.NoContent();
});

app.MapPut("/appointmentservices/{appointmentId}", (HillarysHairCareDbContext db, int appointmentId, List<AppointmentService> appointmentServices) =>
{
    List<AppointmentService> foundAppointmentServices = db.AppointmentServices.Where(a => a.AppointmentId == appointmentId).ToList();
    if (foundAppointmentServices.Count <= 0) { return Results.NotFound(); };

    db.AppointmentServices.RemoveRange(foundAppointmentServices);
    foreach (AppointmentService appointmentService in appointmentServices)
    {
        db.AppointmentServices.Add(appointmentService);
    }
    db.SaveChanges();

    return Results.NoContent();
});

#endregion
app.Run();

