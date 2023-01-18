using Exam.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Http;
using System;
using RestSharp;
using RestSharp.Serializers;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        
        public string key = "56685b0714de429f87d319ddcda8005b"; // GET KEY FROM SITE  https://api.polzki.com/home/eventsapidocs click get your key Here
        

        public IActionResult Event()
        {
            {
                #region Event Working
                var str = ApiService.Get("https://api.polzki.com/api/events?key=" + key);

                // FOR POST
                // var jsonStr = "";
                // var strPost = ApiService.Post("https://api.polzki.com/api/events?key=01cb716174f94156bd7d28c7faafedec", jsonStr);

                EventsResponse eventsResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<EventsResponse>(str == null ? "" : str); //if status fails NEW KEY IS NEEDED
                return View(eventsResponse);
                #endregion
            }

            #region IRest
            //var client = new RestClient("https://api.polzki.com/api/events?key=33ac2ffc953b409aaee5381cb865d2d5");
            ////client.AcceptedContent = -1;
            //var request = new RestRequest(Method.GET);
            //EventsResponse response = client.(request);
            ////Console.WriteLine(response.Content);
            //return View(eventsResponse);
            #endregion
        }

        public IActionResult Attendees()
        {
            ViewBag.key = key;
            var str = ApiService.Get("https://api.polzki.com/api/attendees?key="+key);

            AttendeeResponse attendeeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(str == null ? "" : str);
            // error on getting Attendee Event array value  FIXED!!
            return View(attendeeResponse);
        }
        public IActionResult UpdateAttendee()
        {
            var jsonStr = "";
            var strPost = ApiService.Post("https://api.polzki.com/api/updateattendees?key=" + key + "&AttendeeID=[ATTENDEEID]&Name=[ATTENDEE_NAME]&EventID=[EVENTID]", jsonStr);

            AttendeeResponse attendeesResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(strPost == null ? "" : strPost);

            return View(attendeesResponse);
        }

        public IActionResult SingleAttendee()
        {
            ////From Postman Rest Sharp
            //var client = new Attendee("https://api.polzki.com/api/attendee?key=33ac2ffc953b409aaee5381cb865d2d5&attendeeid=63c40b89c921e241f5d420d2");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.GET);
            //var body = @"";
            //request.AddParameter("text/plain", body, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
