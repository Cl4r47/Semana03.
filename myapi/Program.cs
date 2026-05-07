using myapi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:8000");

var app = builder.Build();

Funcionario[] funcionarios = new Funcionario[100];
int contador = 0;

app.MapGet("/", () => {
    return  new { mensagem= "API em execução"};
});

app.MapGet("/for", () => {
    for (int i = 0; i < 5; i++) {
        Console.WriteLine(i);
    }
});

app.MapGet("/while", () => {

int i = 0;

while(i < 5) {
    Console.WriteLine(i);
    i++;
    }
});

app.MapGet("/objeto", () => {
    
    Funcionario funcionario = new Funcionario();

    funcionario.Nome = "Arthur";

    Console.WriteLine("Nome: " + funcionario.Nome);

    return Results.Ok(new {
       nome = funcionario.Nome
    });
});

app.MapGet("/vetor", () => {
    
    int[] numeros = new int[100];

    numeros[0] = 15;
    numeros[1] = 53;
    numeros[2] = 34;

    Console.WriteLine("Valor: " + numeros[0]);
    Console.WriteLine("Valor: " + numeros[1]);
    Console.WriteLine("Valor: " + numeros[2]);

    return Results.Ok(new {
        numeros
    });
});

app.MapGet("/funcionario/cadastrar/{nome}", (string nome) => {
    
    Funcionario funcionario = new Funcionario();
    
    funcionario.Nome = nome;

    funcionarios[contador] = funcionario;
    contador++;

    //MODIFICAR NA PRÓXIMA AULA
    return Results.Ok(new {
        funcionario
    });
});


app.MapGet("/funcionario/listar/", () => {
    Funcionario[] funcionariosCadastrados = new Funcionario[contador];

    for(int i = 0; i < contador; i++) {
        funcionariosCadastrados[i] = funcionarios[i];
    }

    return Results.Ok( new {
        funcionariosCadastrados
    });

});

app.Run();
