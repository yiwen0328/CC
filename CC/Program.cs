using CC.Data;
using CC.Repositories;
using CC.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �[�J DbContext �P Repository �̿�`�J�]�w
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("YourConnectionString"));
builder.Services.AddScoped(typeof(CC.Interface.IRecordRepository), typeof(RecordRepository));


// ��L�A�ȳ]�w
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
