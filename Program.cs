var builder = WebApplication.CreateBuilder(args);
// adiciona controllers
builder.Services.AddControllers();

// libera acesso externo (IMPORTANTE pro seu HTML funcionar)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
var app = builder.Build();
// ativa CORS
app.UseCors("PermitirTudo");
app.MapControllers();
app.Run("http://localhost:5000");