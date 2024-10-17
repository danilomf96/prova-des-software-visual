using Danilo.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// CADASTRAR
app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

// LISTAR
app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound();
});

// BUSCAR
app.MapGet("/api/tarefas/buscar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{

    Funcionario? funcionario = ctx.Funcionarios.Find(id);

    if (funcionario is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(funcionario);
});

// Deletar
app.MapDelete("/api/funcionario/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{

    Funcionario? funcionario = ctx.Funcionarios.Find(id);

    if (funcionario is null)
    {
        return Results.NotFound();
    }
    ctx.Funcionarios.Remove(funcionario);
    ctx.SaveChanges();
    return Results.Ok(funcionario);
});

// ********* Folha *************

// Cadastrar
app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>
{


    Funcionario? funcionario = ctx.Funcionarios.Find(folha.FuncionarioId);

    if (funcionario is null)
    {
        return Results.NotFound();
    }

    folha.Funcionario = funcionario;

    folha.Bruto = folha.Valor * folha.Quantidade;

    if (folha.Bruto <= 1903.98)
    {
        folha.Ir = 0;
    }
    else if (folha.Bruto <= 2826.65)
        folha.Ir = folha.Bruto * .075 - 142.8;
    else if (folha.Bruto <= 3751.05)
        folha.Ir = folha.Bruto * .15 - 354.8;
    else if (folha.Bruto <= 4664.68)
        folha.Ir = folha.Bruto * .225 - 636.13;
    else
    {
        folha.Ir = folha.Bruto * .275 - 869.36;
    }

    folha.Fgts = folha.Bruto * (100 / 8);


    if (folha.Bruto <= 1693.72)
    {
        folha.Inss = folha.Bruto * .08;
    }
    else if (folha.Bruto <= 2822.9)
        folha.Inss = folha.Bruto * .09;
    else if (folha.Bruto <= 5645.8)
        folha.Inss = folha.Bruto * .11;
    else
    {
        folha.Inss = 621.03;
    }
    folha.Liquido = folha.Bruto - folha.Ir - folha.Fgts - folha.Inss;

    ctx.Folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);

});

// Listar
app.MapGet("/api/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Folhas.Any())
    {
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound();
});


// Buscar por CPF, Mes e Ano
app.MapGet("/api/folha/buscar/{cpf}/{mes}/{ano}", ([FromRoute] string cpf, [FromRoute] int mes, [FromRoute] int ano, [FromServices] AppDataContext ctx) =>
{
    Folha? folha = ctx.Folhas.FirstOrDefault(f =>
        f.Funcionario.Cpf.Equals(cpf) && f.Mes == mes && f.Ano == ano);

    if (folha is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(folha);
});

// Deletar
app.MapDelete("/api/folha/deletar/{id}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{

    Folha? folha = ctx.Folhas.Find(id);

    if (folha is null)
    {
        return Results.NotFound();
    }
    ctx.Folhas.Remove(folha);
    ctx.SaveChanges();
    return Results.Ok(folha);
});

app.Run();
