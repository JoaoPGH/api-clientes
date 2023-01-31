using Clientes.Data.Context;
using Clientes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Data.Reposirories
{
    public class ClienteRepository
    {
        public void Create(Cliente cliente)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(cliente).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Cliente cliente)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(cliente).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Cliente cliente)
        {
            using (var context = new SqlServerContext())
            {
                context.Entry(cliente).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Cliente> GetAll()
        {
            using (var context = new SqlServerContext())
            {
                return context.Cliente.OrderBy(c => c.Nome).ToList();
            }
        }

        public Cliente? GetById(Guid idCliente)
        {
            using (var context = new SqlServerContext())
            {
                return context.Cliente.Find(idCliente);
            }
        }

        public Cliente? GetByEmail(string email)
        {
            using (var context = new SqlServerContext())
            {
                return context.Cliente.FirstOrDefault(c => c.Email.Equals(email));
            }

        }
    }
}
