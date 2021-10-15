using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace REST_Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VoituresController : ControllerBase
    {
        private readonly VoitureDBContext _context;

        public VoituresController(VoitureDBContext context)
        {
            _context = context;
        }

        // GET: api/Voitures
        [HttpGet]
        public IEnumerable<Voiture> GetVoitures()
        {
            return _context.Voitures.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Voiture VoitureById(int Id)
        {
            try
            {
                return _context.Voitures.FirstOrDefault(voiture => voiture.Id == Id);
            }
            catch (Exception)
            {

                return null;
            }
        }


        [HttpPost]
        public HttpStatusCode AjoutVoiture(Voiture voiture)
        {
            try
            {
                _context.Voitures.Add(voiture);
                
                int i = _context.SaveChanges();

                if (i > 0)
                {
                    return HttpStatusCode.OK;
                }
                return HttpStatusCode.InternalServerError;
            }
            catch
            {
                return HttpStatusCode.BadRequest;
            }

        }

        [HttpDelete("{id}")]
        public HttpStatusCode DelVoiture(int id)
        {
            try
            {
                Voiture voitureADel = _context.Voitures.FirstOrDefault(x => x.Id == id);
                if (voitureADel == null)
                    return HttpStatusCode.NotFound;
                _context.Voitures.Remove(voitureADel);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
