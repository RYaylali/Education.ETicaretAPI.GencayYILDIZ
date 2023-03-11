using ETicaretAPÝ.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
//policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));//atýlan bütün baþlýk methot ve originleri kabul eder.
policy.WithOrigins("http://localhost:4200", "https://localhost:4200/").AllowAnyHeader().AllowAnyMethod()//bütün header ve methodlara cevap verir.
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

app.UseCors();//yukarda belirlenen addcors methodunu çaðýrmaya yarar.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
