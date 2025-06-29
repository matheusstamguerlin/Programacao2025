using CorretorImoveis.Models;
using System.Collections.Generic;
using System.Linq;

namespace CorretorImoveis.Data
{
    public class Repositorio
    {
        private static List<Imovel> _imoveis = new List<Imovel>();
        private static int _proximoId = 1;

        public void AdicionarImovel(Imovel imovel)
        {
            imovel.Id = _proximoId++;
            _imoveis.Add(imovel);
        }

        public List<Imovel> ObterTodosImoveis() => _imoveis;

        public Imovel ObterPorId(int id) => _imoveis.FirstOrDefault(i => i.Id == id);

        public void AtualizarImovel(Imovel imovel)
        {
            var index = _imoveis.FindIndex(i => i.Id == imovel.Id);
            if (index >= 0)
                _imoveis[index] = imovel;
        }

        public void RemoverImovel(int id) => _imoveis.RemoveAll(i => i.Id == id);
    }
}