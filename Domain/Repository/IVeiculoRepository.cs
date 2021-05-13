using System;
using System.Collections.Generic;
using Localiza.Frotas.Domain.Model;

namespace Localiza.Frotas.Domain.Repository
{
    public interface IVeiculoRepository
    {
        /// <summary>
        /// Retorna o Veículo baseado no Id passado.
        /// </summary>
        Veiculo GetVeiculoById(Guid id);

        /// <summary>
        /// Lista todos os Veículos cadastrados.
        /// </summary>
        IEnumerable<Veiculo> GetAll();

        /// <summary>
        /// Adiciona um Veículo
        /// </summary>
        void Add(Veiculo veiculo);

        Veiculo Update(Veiculo veiculo);

        /// <summary>
        /// Remove um Veículo baseado no Id.
        /// </summary>
        void Delete(Veiculo veiculo);
    }
}