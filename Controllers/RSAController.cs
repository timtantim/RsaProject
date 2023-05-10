using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RsaProject.Model;
using RsaProject.RsaService;
using Syncfusion.XlsIO;
using System;
using System.IO;
namespace RsaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : ControllerBase
    {
        private RsaEncryption rsa;
        public RSAController()
        {
            rsa = RsaEncryption.Instance();
        }


        // POST api/<RSAController>
        [HttpPost]
        public string Post(string value)
        {
            string jsonData = string.Empty;
            string cypher = string.Empty;
            switch (value) {
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


        // POST api/<RSAController>
        [HttpPost("GenerateExcel")]
        public bool GenerateExcel(string value)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                worksheet.Range["A1"].Value = "Hello World";
                FileStream stream = new FileStream("LearnExcel.xlsx", FileMode.Create, FileAccess.ReadWrite);
                workbook.SaveAs(stream);
                stream.Dispose();
            }
            return true;
        }
    }
}
