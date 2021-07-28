using System.Collections.Generic;


namespace CadastroDeLivros.Interfaces
{
    interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);

        void Inserir(T cadastro);
        void Excluir(int id);
        void Atualizar(int id, T cadastro);
        int ProximoId();

    }
}
