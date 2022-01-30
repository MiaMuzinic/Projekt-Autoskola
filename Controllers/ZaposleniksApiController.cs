using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autoskola_Mia.DtoMappers;
using Autoskola_Mia.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Autoskola_Mia.Controllers
{
    [Route("api/zaposlenik")]
    [ApiController]
    public class ZaposleniksApiController : ControllerBase
    {
        private List<Zaposlenik> _zaposlenici;

        public ZaposleniksApiController()
        {

            _zaposlenici = new List<Zaposlenik>();
            /*
            _zaposlenici.Add(
                new Zaposlenik(
                    Id= 0,
                    Ime= "Ante",
                    Prezime= "Anić",
                    Spol= "M",
                    Email= "aanic@gmail.com",
                    Placa=  6500,
                    Pozicija="Predavač" 
                )
            );*/

        }

        [HttpGet]
        public ActionResult<List<Zaposlenik>> Get()
        {
            return _zaposlenici;
        }
        [HttpGet("{id}")] // api/zaposlenik/0
        public ActionResult<Zaposlenik> Get(int id)
        {
            return _zaposlenici.Find(x => x.Id == id);
        }
        
        
        [HttpPost("savezaposlenika")]
        public ActionResult Save(Zaposlenik zaposlenik)
        {
            _zaposlenici.Add(zaposlenik);
            return Ok();
        }

        /*
        [HttpPost("savezaposlenika2")]
        public ActionResult Save([FromBody] JObject json)
        {
            var soba = ZaposlenikDto.FromJson(json);
            _zaposlenici.Add(soba);
            return Ok();
        }
        */

    }
}
