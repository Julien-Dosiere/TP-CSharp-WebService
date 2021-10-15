using REST_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST_Framework.Controllers
{
    public class VoitureController : ApiController
    {
        private VoituresDBEntities1 db = new VoituresDBEntities1();
        
        [HttpGet]
        [Route("Voitures/{id}")]
        public Voiture VoitureById(int Id)
        {
            try
            {
                return db.Voitures.FirstOrDefault(voiture => voiture.Id == Id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost] 
        [Route("Voitures")] 
        public HttpStatusCode AjoutVoiture(Voiture voiture) { 
            if (ModelState.IsValid) { 
                db.Voitures.Add(voiture); 
                int i = db.SaveChanges(); 
                if (i > 0) { 
                    return HttpStatusCode.OK; 
                } 
                return HttpStatusCode.InternalServerError; 
            } 
            return HttpStatusCode.BadRequest; 
        }

        [HttpDelete] 
        [Route("Voitures/{id}")] 
        public HttpStatusCode DelVoiture(int id) { 
            try { Voiture voitureADel = db.Voitures.FirstOrDefault(x => x.Id == id); 
            if (voitureADel == null) 
                    return HttpStatusCode.NotFound; 
                db.Voitures.Remove(voitureADel); 
                db.SaveChanges(); 
                return HttpStatusCode.OK; 
            } catch (Exception) { 
                return HttpStatusCode.InternalServerError; 
            } 
        }

    }
}
