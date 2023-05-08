using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RsaProject.Model;
using RsaProject.RepositoryService;
using System.Collections.Generic;
using System.Linq;

namespace RsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomHeadController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BomHeadController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/<BomHeadController>
        [HttpGet]
        public IEnumerable<BomHead> Get()
        {
            var BomHeads = _repositoryWrapper.BomHead.FindAll();
            return BomHeads;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<BomHeadController>/5
        [HttpGet("{id}")]
        public IEnumerable<BomHead> Get(int id)
        {
            var BomHeads = _repositoryWrapper.BomHead.FindByCondition(x => x.Id.Equals(id));
            return BomHeads;
        }

        // POST api/<BomHeadController>
        [HttpPost]
        public BomHead Post(BomHead bomHead)
        {
            var bom_detail_result = _repositoryWrapper.BomHead.Create(bomHead);
            _repositoryWrapper.save();
            return bom_detail_result;
        }


        // PUT api/<BomHeadController>/5
        [HttpPut("{id}")]
        public void Put(int id, BomHead bomHead)
        {
            var BomHeads = _repositoryWrapper.BomHead.FindByCondition(x => x.Id.Equals(id)).ToList();

            if (BomHeads.Any())
            {
                _repositoryWrapper.BomHead.Update(bomHead);
            }
            else
            {
                var bom_detail_result = _repositoryWrapper.BomHead.Create(bomHead);
            }
            _repositoryWrapper.save();
        }

        // DELETE api/<BomHeadController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, BomHead bomHead)
        {
            var BomHeads = _repositoryWrapper.BomHead.FindByCondition(x => x.Id.Equals(id)).ToList();

            if (BomHeads.Any())
            {
                _repositoryWrapper.BomHead.Delete(bomHead);
            }
            _repositoryWrapper.save();
        }
    }
}
