using ETicaretAP�.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
//policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));//at�lan b�t�n ba�l�k methot ve originleri kabul eder.
policy.WithOrigins("http://localhost:4200", "https://localhost:4200/").AllowAnyHeader().AllowAnyMethod()//b�t�n header ve methodlara cevap verir.
//bu yerden gelen istekleri al 
));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();//yukarda belirlenen addcors methodunu �a��rmaya yarar.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
