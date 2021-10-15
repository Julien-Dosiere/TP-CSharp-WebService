using SOAP_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace SOAP_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private VoituresDBEntities db = new VoituresDBEntities();
        public bool AddVoiture(Voiture voiture)
        {
            try
            {
                db.Voitures.Add(voiture);
                return db.SaveChanges() > 0;
            } catch
            {
                return false;
            }

            

        }

        public bool DelVoiture(int Id)
        {
            try
            {
                Voiture voitureToDelete = db.Voitures.FirstOrDefault(voiture => voiture.Id == Id);
                db.Voitures.Remove(voitureToDelete);
                db.SaveChanges();
                return true;
            } catch
            {
                return false;
            }

        }

        public Voiture FindVoitureByID(int Id)
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
    }
}
