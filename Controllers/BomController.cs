using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RsaProject.Model;
using RsaProject.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BomController(IRepositoryWrapper repositoryWrapper) {
            _repositoryWrapper= repositoryWrapper;
        }


        // GET: api/<BomController>
        [HttpGet]
        public IEnumerable<Bom> Get()
        {
            var boms= _repositoryWrapper.Bom.FindAll();
            return boms;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<BomController>/5
        [HttpGet("{id}")]
        public IEnumerable<Bom> Get(int id)
        {
            var boms = _repositoryWrapper.Bom.FindByCondition(x => x.Id.Equals(id));
            return boms;
        }

        // POST api/<BomController>
        [HttpPost]
        public Bom Post(Bom bom)
        {
            var bom_result = _repositoryWrapper.Bom.Create(bom);
            _repositoryWrapper.save();
            return bom_result;
        }


        // PUT api/<BomController>/5
        [HttpPut("{id}")]
        public void Put(int id, Bom bom)
        {
            var boms = _repositoryWrapper.Bom.FindByCondition(x => x.Id.Equals(id)).ToList();
        
            if (boms.Any())
            {
                _repositoryWrapper.Bom.Update(bom); 
            }
            else {
                var bom_result = _repositoryWrapper.Bom.Create(bom);
            }
            _repositoryWrapper.save();
        }

        // DELETE api/<BomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, Bom bom)
        {
            var boms = _repositoryWrapper.Bom.FindByCondition(x => x.Id.Equals(id)).ToList();

            if (boms.Any())
            {
                _repositoryWrapper.Bom.Delete(bom);
            }
            _repositoryWrapper.save();
        }
    }
}
