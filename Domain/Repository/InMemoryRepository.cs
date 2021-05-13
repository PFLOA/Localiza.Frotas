using System;
using System.Collections.Generic;
using System.Linq;
using Localiza.Frotas.Domain.Model;
using Localiza.Frotas.Domain.Repository;

namespace Localiza.Frotas.Domain.Repository
{
    public class InMemoryRepository : IVeiculoRepository
    {
        private List<Veiculo> entities = new List<Veiculo>();

        public InMemoryRepository()
        {
            entities.Add(new Veiculo{
                id = Guid.NewGuid()
            });
            entities.Add(new Veiculo{
                id = Guid.NewGuid()
            });
            entities.Add(new Veiculo{
                id = Guid.NewGuid()
            });
            entities.Add(new Veiculo{
                id = Guid.NewGuid()
            });
            entities.Add(new Veiculo{
                id = Guid.NewGuid()
            });
        }
        public void Add(Veiculo veiculo) => entities.Add(veiculo);

        public void Delete(Veiculo veiculo) => entities.Remove(GetVeiculoById(veiculo.id));

        public IEnumerable<Veiculo> GetAll() => entities.ToList();

        public Veiculo GetVeiculoById(Guid id) => entities.SingleOrDefault(p => p.id == id);

        public Veiculo Update(Veiculo veiculo)
        {
            var index = entities.FindIndex(p => p.id == veiculo.id);
            entities[index] = veiculo;

            return veiculo;
        }
    }
}