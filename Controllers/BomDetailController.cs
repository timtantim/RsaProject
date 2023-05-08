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
    public class BomDetailController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BomDetailController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        // GET: api/<BomDetailController>
        [HttpGet]
        public IEnumerable<BomDetail> Get()
        {
            var bomDetails = _repositoryWrapper.BomDetail.FindAll();
            return bomDetails;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<BomDetailController>/5
        [HttpGet("{id}")]
        public IEnumerable<BomDetail> Get(int id)
        {
            var bomDetails = _repositoryWrapper.BomDetail.FindByCondition(x => x.Id.Equals(id));
            return bomDetails;
        }

        // POST api/<BomDetailController>
        [HttpPost]
        public BomDetail Post(BomDetail bomDetail)
        {
            var bom_detail_result = _repositoryWrapper.BomDetail.Create(bomDetail);
            _repositoryWrapper.save();
            return bom_detail_result;
        }


        // PUT api/<BomDetailController>/5
        [HttpPut("{id}")]
        public void Put(int id, BomDetail bomDetail)
        {
            var bomDetails = _repositoryWrapper.BomDetail.FindByCondition(x => x.Id.Equals(id)).ToList();

            if (bomDetails.Any())
            {
                _repositoryWrapper.BomDetail.Update(bomDetail);
            }
            else
            {
                var bom_detail_result = _repositoryWrapper.BomDetail.Create(bomDetail);
            }
            _repositoryWrapper.save();
        }

        // DELETE api/<BomDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, BomDetail bomDetail)
        {
            var bomDetails = _repositoryWrapper.BomDetail.FindByCondition(x => x.Id.Equals(id)).ToList();

            if (bomDetails.Any())
            {
                _repositoryWrapper.BomDetail.Delete(bomDetail);
            }
            _repositoryWrapper.save();
        }
    }
}
