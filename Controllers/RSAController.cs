﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RsaProject.Model;
using RsaProject.RsaService;

namespace RsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : ControllerBase
    {
        public RsaEncryption rsa=new RsaEncryption();


        // POST api/<RSAController>
        [HttpPost]
        public string Post(string filetype)
        {
            string jsonData = string.Empty;
            string cypher = string.Empty;
            switch (filetype) {
                case "ExcelFile01":
                    jsonData = "asfasfasflsdjfkldsjgklsd";
                    break;
                case "ExcelFile02":
                    jsonData = "asfasfasflsdjfkldsjgkls123123123d";
                    break;
            }
            cypher = rsa.Encrypt(jsonData);
            return cypher;
        }
    }
}
