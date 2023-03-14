using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAP�.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
//policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));//at�lan b�t�n ba�l�k methot ve originleri kabul eder.
policy.WithOrigins("http://localhost:4200", "https://localhost:4200/").AllowAnyHeader().AllowAnyMethod()//b�t�n header ve methodlara cevap verir.
//bu yerden gelen istekleri al 
));
builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())//infrastructure de olu�turdu�umuz filtremeleme mesa�lar�na ula�mas� i�in
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())//Burada validasyonlar� kontrol edece�i yeri g�stermek i�in createproductvalidators class verildi fluenvalidation i�in
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);//mevcut olan do�rulama filtrelerini bast�r. api tetiklenecek

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
