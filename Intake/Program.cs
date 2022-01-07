var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var claims = new[]
{
    "AB123456789", "AC123456789", "AD123456789", "AE123456789", "AF123456789", "AG123456789", "AH123456789", "AI123456789", "AJ123456789", "AK123456789"
};

app.MapGet("/IntakeRecord", () =>
{
    var intakeRecord = Enumerable.Range(1, 9).Select(index =>
       new IntakeRecord
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(1, 20),
           claims[Random.Shared.Next(claims.Length)]
       ))
        .ToArray();
    return intakeRecord;
})
.WithName("GetIntakeRecord");

app.Run();

internal record IntakeRecord(DateTime RecordDate, int IntakeEntryID, string? ClaimNumber)
{

}