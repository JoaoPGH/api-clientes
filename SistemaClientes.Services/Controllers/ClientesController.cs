using Clientes.Data.Entities;
using Clientes.Data.Reposirories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaClientes.Services.Model;
using System.Runtime.CompilerServices;

namespace SistemaClientes.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClientePostModel model)
        {
            try
            {
                var clienteRepository = new ClienteRepository();

                if (clienteRepository.GetByEmail(model.Email) != null)
                    return StatusCode(400, new { mensagem = "O email informado, já está cadastrado no sistema." });

                var cliente = new Cliente
                {
                    IdCliente = Guid.NewGuid(),
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Telefone = model.Telefone,
                    Email = model.Email,
                    DataNascimento = DateTime.Parse(model.DataNascimento)

                };

                clienteRepository.Create(cliente);

                return StatusCode(201, new { mensagem = "Cliente cadastrado com sucesso.", cliente });

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao cadastrar cliente {e.Message} " });

            }
        }

        [HttpPut]
        public IActionResult Put(ClientePutModel model)
        {
            try
            {
                var clienteRepository = new ClienteRepository();

                var cliente = clienteRepository.GetById(model.IdCliente);

                if (cliente == null)
                    return StatusCode(400, new { mensagem = "Cliente não encontrado, verifique o ID informado" });

                cliente.Email = model.Email;
                cliente.Telefone = model.Telefone;


                clienteRepository.Update(cliente);

                return StatusCode(200, new { mensagem = "Cliente atualizado com sucesso." });


            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao atualizar: {e.Message}" });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var clienteRepository = new ClienteRepository();

                var cliente = clienteRepository.GetById(id);

                if (cliente == null)
                    return StatusCode(400, new { mensagem = "Cliente não encontrado, verifique o ID" });

                clienteRepository.Delete(cliente);
                return StatusCode(200, new { mensagem = "Cliente excluido com sucesso.", cliente });


            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao excluir cliente: {e.Message}" });
            }
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ClienteGetModel>))]
        public IActionResult GetAll()
        {
            try
            {
                var clienteRepository = new ClienteRepository();

                var model = new List<ClienteGetModel>();

                foreach (var item in clienteRepository.GetAll())
                {
                    model.Add(new ClienteGetModel
                    {
                        IdCliente = item.IdCliente,
                        Nome = item.Nome,
                        Cpf = item.Cpf,
                        Telefone = item.Telefone,
                        Email = item.Email,
                        DataNascimento = item.DataNascimento.ToString("dd/MM/yyyy"),

                    });

                }

                return StatusCode(200, model);

            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao consultar clientes: {e.Message}" });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ClienteGetModel))]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var clienteRepository = new ClienteRepository();

                var cliente = clienteRepository.GetById(id);

                if (cliente == null)
                    return StatusCode(204);

                var model = new ClienteGetModel
                {
                    IdCliente = cliente.IdCliente,
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Telefone = cliente.Telefone,
                    Email = cliente.Email,
                    DataNascimento = cliente.DataNascimento.ToString("dd/MM/yyyy"),
                };

                return StatusCode(200, model);


            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = $"Falha ao obter cliente: {e.Message}" });
            }
        }
    }
}
