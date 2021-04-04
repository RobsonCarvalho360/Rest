using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.DAO;
using Teste.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroTesteController : ControllerBase
    {
        // GET: api/<CadastroTesteController>
        [HttpGet]
        public IEnumerable<CadastroTeste> Get()
        {
            var repository = new CadastroTesteDAO();
            return repository.SelectAllClients();
        }

        // GET api/<CadastroTesteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CadastroTesteController>
        [HttpPost]
        public void Post(string Descricao)
        {
            var repository = new CadastroTesteDAO();
            repository.InsertDataCadastroTeste(Descricao);
        }

        // PUT api/<CadastroTesteController>/5
        [HttpPut]
        public void Put(CadastroTeste cadastroTeste)
        {
            var repository = new CadastroTesteDAO();
            repository.UpdateDataCadastroTeste(cadastroTeste);
        }

        // DELETE api/<CadastroTesteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }        
}
