using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aula03parte2.Models;

namespace Aula03parte2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public string GetIF(int x)
    {
        /*
           Estrutura sintática do IF
           if(expressão booleana)
        {
            Sentença de código a ser executada, caso a condição seja verdadeira
        }

        Caso o if tenha apenas uma linha de comando a ser executada na condicional,
        não há necessidade do uso das chaves

        if(expressao booelana)
            Apenas um comando
        */
        string retorno = string.Empty;
        //int x = 10;

        if (x < 9)
            retorno = "x é maior que 9";

        //x = 8;
        if (x > 9)
            retorno = "x é maior que 9";
        else
            retorno = "x é menor que 9";

        //x = 11;
        if (x == 10)
        {
            retorno = "Ora ora ";
            retorno += "X é igual a 10";
        }
        else if (x == 9)
        {
            retorno = "Hmmmmmmm";
            retorno += "x é igual a 9";
        }
        else if (x == 8)
        {
            retorno = "Bahhhhh";
            retorno += "x é igual a 8 tchê.";
        }
        else
        {
            retorno = "Sei lá que número é x";
        }
            return retorno;

        
    }

    [HttpGet]
    public string GetSwitch(int x)
    {
        string retorno = string.Empty;
        switch(x)
        {
            case 0:
                retorno = "x é zero";
                break;
            case 1:
                retorno = "x é um";
                break;
            case 2:
                retorno = "x é dois";
                break;
            case 3:
                retorno = "x é três";
                break;
            default:
                retorno = "x é algum número não previsto";
                break;
        }

            return retorno;
    }

    [HttpGet]
    public string GetFor()
    {
        /*
            O comando de repetição for posui a seguinte sintaxe:
            for( <inicializador>; <expressão condicional>; <expressão repetição> )
        {
            Comando a serem executados
        }
        Inicializador: elemento contador. Tradicionalmente utilizado o i = indice
        Expressão condicional: Especifica o teste a ser verificado quando o loop
        estiver executado o número definido de interações (flag);
        Expressão de repetição: Específica a ação a ser executada com a variável contadora.
        Geralmente um acúmulo ou decréscimo (acumulador);
        */

        string retorno = string.Empty;

        for(int i = 0; i < 10; i++)
        {
            retorno += $"{i}; ";
        }

        return retorno;
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
