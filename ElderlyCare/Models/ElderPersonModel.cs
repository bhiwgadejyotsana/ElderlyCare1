using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ElderlyCare.Data;

namespace ElderlyCare.Models
{
    public class ElderPersonModel
    {
        public int ElderPersonId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }
        public string Contactno { get; set; }
        public string DoctorName { get; set; }
        public string DoctorContactno { get; set; }
        public string HospitalName { get; set; }
        public string HospitalContactno { get; set; }
        public string CareTaker { get; set; }

        public string SaveRegistration(ElderPersonModel model)
        {
            string message = "";
            ElderlyCareEntities1 db = new ElderlyCareEntities1();
            var saveRegistration = new tblElderPerson()
            {
                Name = model.Name,
                Age = model.Age,
                Address = model.Address,
                Contactno = model.Contactno,
                DoctorName = model.DoctorName,
                DoctorContactno = model.DoctorContactno,
                HospitalName = model.HospitalName,
                HospitalContactno=model.HospitalContactno,
                CareTaker=model.CareTaker,
            };
            db.tblElderPersons.Add(saveRegistration);
            db.SaveChanges();
            return message;
        }

        public List<ElderPersonModel> GetRegistrationList()
        {
            ElderlyCareEntities1 db = new ElderlyCareEntities1();
            List<ElderPersonModel> str = new List<ElderPersonModel>();
            var RegistrationList = db.tblElderPersons.ToList();
            if (RegistrationList != null)
            {
                foreach (var reg in RegistrationList)
                {
                    str.Add(new ElderPersonModel()
                    {
                        ElderPersonId = reg.ElderPersonId,
                        Name = reg.Name,
                        Age = reg.Age,
                        Address = reg.Address,
                        Contactno = reg.Contactno,
                        DoctorName= reg.DoctorName,
                        DoctorContactno = reg.DoctorContactno,
                       HospitalName = reg.HospitalName,
                       HospitalContactno=reg.HospitalContactno ,
                       CareTaker=reg.CareTaker ,
                    });
                }
            }
            return str;
        }
    }
}