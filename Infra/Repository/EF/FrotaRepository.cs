using System.Data.Common;
using Localiza.Frotas.Domain.Model;
using Localiza.Frotas.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Localiza.Frotas.Infra.Repository.EF
{
    public class FrotaRepository : IVeiculoRepository
    {
        private readonly FrotaContext dbContext;

        public FrotaRepository(FrotaContext context) => this.dbContext = context;

        public void Add(Veiculo veiculo){
            dbContext.Veiculos.Add(veiculo);
            dbContext.SaveChanges();            
        }

        public void Delete(Veiculo veiculo){
            dbContext.Veiculos.Remove(veiculo);
            dbContext.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll() => dbContext.Veiculos.ToListAsync().Result;

        public Veiculo GetVeiculoById(Guid id) => dbContext.Veiculos.SingleOrDefaultAsync(p => p.id == id).Result;

        public Veiculo Update(Veiculo veiculo)
        {
            dbContext.Entry(veiculo).State = EntityState.Modified;
            dbContext.SaveChanges();

            return veiculo;
        }
    }
}