using GestionLogisticaApiR.AccesoDatos;
using GestionLogisticaApiR.LogicaNegocio;
using GestionLogisticaApiR.LogicaNegocio.Validadores;
using GestionLogisticaApiR.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Inyección de dependencias para la capa de negocio LogisticaGeneral
builder.Services.AddScoped<IGenericoAD<Cliente>, ClienteAD>();
builder.Services.AddScoped<IGenericoAD<TipoProducto>, TipoProductoAD>();
// Inyección de dependencias para el Controlador LogisticaGeneral
builder.Services.AddScoped<ILogisticaGeneralLN, LogisticaGeneralLN>();

// Inyección de dependencias para el validador PlanEntrega
builder.Services.AddScoped<IConsultaEntidadAD<Bodega>, BodegaAD>();
builder.Services.AddScoped<IConsultaEntidadAD<Puerto>, PuertoAD>();
// Inyección de dependencias para la capa de negocio PlanEntrega
builder.Services.AddScoped<IValidadorPlanEntrega, ValidadorPlanEntrega>();
builder.Services.AddScoped<IGenericoAD<PlanEntrega>, PlanEntregaAD>();
builder.Services.AddScoped<IConsultaEntidadAD<Descuento>, DescuentoAD>();
builder.Services.AddScoped<IGuardarEntidadAD<PlanEntrega_Vehiculo>, PlanEntrega_VehiculoAD>();
builder.Services.AddScoped<IGuardarEntidadAD<PlanEntrega_Flota>, PlanEntrega_FlotaAD>();
builder.Services.AddScoped<IGuardarEntidadAD<PlanEntrega_Bodega>, PlanEntrega_BodegaAD>();
builder.Services.AddScoped<IGuardarEntidadAD<PlanEntrega_Puerto>, PlanEntrega_PuertoAD>();
// Inyección de dependencias para el Controlador de PlanEntrega
builder.Services.AddScoped<IPlanEntregaLN, PlanEntregaLN>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicyCors", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();
app.UseCors("NewPolicyCors");
app.Run();
