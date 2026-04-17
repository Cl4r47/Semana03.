using myapi.Models;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.MapGet("/", () => new {
    mensagem = "API funcionando.."
});

app.MapGet("/for", () => {
    for(int i = 0; i < 5; i++) {
        Console.WriteLine(i);
    }
});

app.MapGet("/while", () => {
  int i = 0;

    while(i < 5)
    {
        Console.WriteLine(i);
        i++;
    }
});

app.MapGet("/objeto", () => {
   
   Funcionario funcionario = new Funcionario();

   funcionario.Nome = "Fulano";

   Console.WriteLine("Nome: " + funcionario.Nome);

   return Results.Ok(new {
       nome = funcionario.Nome
   });

});

app.Run();