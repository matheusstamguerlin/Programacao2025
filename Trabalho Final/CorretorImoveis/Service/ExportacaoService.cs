using CorretorImoveis.Models;
using System.Text;

namespace CorretorImoveis.Services
{
    public class ExportacaoService
    {
        public string GerarArquivoTexto(List<Imovel> imoveis)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Nome|Endereço|Categoria|Quartos|Vagas|Banheiros|Descrição");

            foreach (var imovel in imoveis)
                sb.AppendLine($"{imovel.Nome}|{imovel.Endereco}|{imovel.Categoria}|{imovel.Quartos}|{imovel.VagasGaragem}|{imovel.Banheiros}|{imovel.Descricao}");

            return sb.ToString();
        }
    }
}