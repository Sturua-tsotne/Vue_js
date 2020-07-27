using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NocaManegmentNew.Models;

namespace NocaManegmentNew.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private NOCAManagmentContext _nOCAManagmentContext;
        public HomeController(NOCAManagmentContext nOCAManagmentContext)
        {
            _nOCAManagmentContext = nOCAManagmentContext;
        }


        [HttpGet(nameof(Cabinets))]
        public IEnumerable<Cabinets> Cabinets()
        {

            var Cabinets = _nOCAManagmentContext.Cabinets.Select(x => new Cabinets()
            {
                Id = x.Id,
                Num = x.Num,
                //Shelfes = x.Shelfes.Where(a => a.CabinetId == x.Id).ToList(),

            }).ToList();
            return Cabinets;
        }
        
        [HttpGet(nameof(Shelfes))]
        [Route("Shelfes/{Id}")]

        public IEnumerable<Shelfes> Shelfes(int? id)
        {
            

            var shelf = _nOCAManagmentContext.Shelfes.Select(x=> new Shelfes() { 
                 Id=x.Id,
                 CabinetId=x.CabinetId,
                 ProductId=x.ProductId,
                 Num=x.Num,
                 Product= _nOCAManagmentContext.Products.FirstOrDefault(s=>s.Id==x.ProductId),
                
     
            }).Where(c=>c.CabinetId==id);
           
            return shelf;
        }
        [HttpGet(nameof(Product))]
     
        public IEnumerable<Products> Product()
        {

            return _nOCAManagmentContext.Products.Select(x=>x).ToList();

        }

        [HttpGet(nameof(Shelfeslist))]

        public IEnumerable<Shelfes> Shelfeslist()
        {

            return _nOCAManagmentContext.Shelfes.Select(x => x).ToList();

        }



    }
}
