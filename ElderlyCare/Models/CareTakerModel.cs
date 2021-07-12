using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ElderlyCare.Data;

namespace ElderlyCare.Models
{
    public class CareTakerModel
    {
        public int CareTakerId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Contactno { get; set; }
        public string Address { get; set; }
        public string PatientRelation { get; set; }
        public string SaveRegistration(CareTakerModel model)
        {
            string message = "";
            ElderlyCareEntities1 db = new ElderlyCareEntities1();
            var saveRegistration = new tblCareTaker()
            {
                Name = model.Name,
                Age = model.Age,
                Contactno = model.Contactno,
                Address = model.Address,
                PatientRelation=model.PatientRelation,
               
            };
            db.tblCareTakers.Add(saveRegistration);
            db.SaveChanges();
            return message;
        }

        public List<CareTakerModel> GetRegistrationList()
        {
            ElderlyCareEntities1 db = new ElderlyCareEntities1();
            List<CareTakerModel> str = new List<CareTakerModel>();
            var RegistrationList = db.tblCareTakers.ToList();
            if (RegistrationList != null)
            {
                foreach (var reg in RegistrationList)
                {
                    str.Add(new CareTakerModel()
                    {
                        CareTakerId = reg.CareTakerId,
                        Name = reg.Name,
                        Age = reg.Age,
                        Contactno = reg.Contactno,
                        Address = reg.Address,
                        PatientRelation = reg.PatientRelation,
                     
                    });
                }
            }
            return str;
        }
    }
}