using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Habilita o Swagger apenas em desenvolvimento
    app.UseSwaggerUI(); // Habilita a interface do Swagger
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite que arquivos estáticos sejam servidos

app.UseRouting();

app.UseAuthorization();

// Mapeia os controladores
app.MapControllers();

// Mapeia um fallback para aplicações SPA
app.MapFallbackToFile("index.html");

app.Run(); // Inicia a aplicação