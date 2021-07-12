using ElderlyCare.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.IO;
using System.Text;

namespace ElderlyCare.Models
{
    public class ReminderModel
    {
        public int ReminderId { get; set; }
        public string ReminderText { get; set; }
        public string Description { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<int> ElderPersonId { get; set; }

        public string SaveRegistration(ReminderModel model)
        {
            string message = "";
            ElderlyCareEntities1 db = new ElderlyCareEntities1();
            var saveRegistration = new tblReminder()
            {
                ReminderText = model.ReminderText,
                Description = model.Description,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                ElderPersonId = model.ElderPersonId,

            };
            db.tblReminders.Add(saveRegistration);
            db.SaveChanges();
            return message;
        }
        public string SendReminder( )
        {
            string message = "";
            ElderlyCareEntities1 db = new ElderlyCareEntities1();
            TimeSpan currettimt = DateTime.Now.TimeOfDay;
            TimeSpan endttimt = DateTime.Now.AddMinutes(20).TimeOfDay;
            var remider = db.tblReminders.Where(p=>p.StartTime <= currettimt && p.EndTime <= endttimt).ToList();
            foreach (var remindedet in remider)
            {
                if (remindedet != null)
                {


                    var model = db.tblElderPersons.Where(p => p.ElderPersonId == remindedet.ElderPersonId).FirstOrDefault();
                    string mobile = model.Contactno;
                    string sAPIKey = "fYMsEmpZQUewatTPf0TktQ";
                    string sNumber = mobile;
                    string sMessage = "Hi, " + model.Name + "     Reminder for    " + remindedet.ReminderText;
                    string sSenderId = "BSCAKE";
                    string sChannel = "trans";
                    string sRoute = "8";
                    // string sURL = "http://mysms.msg24.in/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderId + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "&route=" + sRoute + "";
                    string sURL = "http://mysms.msg24.in/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderId + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "&route=" + sRoute + "";

                    string sResponse = GetResponse(sURL);
                    //Response.Write(sResponse);
                    message = model.Name;
                }

            }
            return message;
        }
        public static string GetResponse(string sUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sUrl);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}