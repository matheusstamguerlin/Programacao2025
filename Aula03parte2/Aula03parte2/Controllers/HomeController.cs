using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aula03parte2.Models;
using System.Text;

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
           Estrutura sint�tica do IF
           if(express�o booleana)
        {
            Senten�a de c�digo a ser executada, caso a condi��o seja verdadeira
        }

        Caso o if tenha apenas uma linha de comando a ser executada na condicional,
        n�o h� necessidade do uso das chaves

        if(expressao booelana)
            Apenas um comando
        */
        string retorno = string.Empty;
        //int x = 10;

        if (x < 9)
            retorno = "x � maior que 9";

        //x = 8;
        if (x > 9)
            retorno = "x � maior que 9";
        else
            retorno = "x � menor que 9";

        //x = 11;
        if (x == 10)
        {
            retorno = "Ora ora ";
            retorno += "X � igual a 10";
        }
        else if (x == 9)
        {
            retorno = "Hmmmmmmm";
            retorno += "x � igual a 9";
        }
        else if (x == 8)
        {
            retorno = "Bahhhhh";
            retorno += "x � igual a 8 tch�.";
        }
        else
        {
            retorno = "Sei l� que n�mero � x";
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
                retorno = "x � zero";
                break;
            case 1:
                retorno = "x � um";
                break;
            case 2:
                retorno = "x � dois";
                break;
            case 3:
                retorno = "x � tr�s";
                break;
            default:
                retorno = "x � algum n�mero n�o previsto";
                break;
        }

            return retorno;
    }

    [HttpGet]
    public string GetFor()
    {
        /*
            O comando de repeti��o for posui a seguinte sintaxe:
            for( <inicializador>; <express�o condicional>; <express�o repeti��o> )
        {
            Comando a serem executados
        }
        Inicializador: elemento contador. Tradicionalmente utilizado o i = indice
        Express�o condicional: Especifica o teste a ser verificado quando o loop
        estiver executado o n�mero definido de intera��es (flag);
        Express�o de repeti��o: Espec�fica a a��o a ser executada com a vari�vel contadora.
        Geralmente um ac�mulo ou decr�scimo (acumulador);
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

public class Exemplo
{
    public string GetForeach(string color)
    {
        string[] colors = {
            "Vermelho", "Preto", "Azul", "Amarelo", "Verde",
            "Branco", "Azul-Marinho", "Rosa", "Roxo", "Cinza"
        };

        StringBuilder retorno = new StringBuilder();

        if (colors.Contains(color))
            retorno.AppendLine("A cor escolhida � v�lida.");
        else
            retorno.AppendLine("Cor escolhida inv�lida.");

        retorno.Append("Cores dispon�veis: ");
        foreach (string s in colors)
        {
            retorno.Append($"[{s}] ");
        }

        return retorno.ToString();
    }
}
