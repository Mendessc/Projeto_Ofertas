using OfetasWebAPI.Domains;
using System.Collections.Generic;

namespace OfetasWebAPI.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(int idTipoUsuario);
        void Cadastrar(TipoUsuario novoTipoUsuario);
        void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado);
        void Deletar(int idTipoUsuario);
    }
}
