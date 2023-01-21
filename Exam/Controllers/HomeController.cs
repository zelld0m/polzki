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
using System.Net;
using System.Collections.Generic;
using System.Threading;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        
        public string key = "f0ca0204016a40d8af03ce06ff38e0f4"; // GET KEY FROM SITE  https://api.polzki.com/home/eventsapidocs click get your key Here
        

        public IActionResult Event()
        {

            #region Event Working
            var str = ApiService.Get("https://api.polzki.com/api/events?key=" + key);

            // FOR POST
            // var jsonStr = "";
            // var strPost = ApiService.Post("https://api.polzki.com/api/events?key=01cb716174f94156bd7d28c7faafedec", jsonStr);

            EventsResponse eventsResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<EventsResponse>(str == null ? "" : str); //if status fails NEW KEY IS NEEDED
            return View(eventsResponse);
            #endregion


            #region IRest SAMPLE
            //var client = new RestClient("https://api.myorg.com");

            //var options = new RestClientOptions("https://api.myorg.com")
            //{
            //    ThrowOnAnyError = true,
            //    Timeout = 1000
            //};

            //var client2 = new RestClient(options);
            //return View(client2);
            #endregion
            #region IRest Test 1 
            //var client = new RestClient("https://api.polzki.com/api/events?key=56685b0714de429f87d319ddcda8005b");        
            //var request = new RestRequest("api.polzki.com/api",Method.Get);
            ////EventsResponse response =
            //EventsResponse response = client.ExecuteGet<List<Event>>(request).Data;
            ////Console.WriteLine(response.Content);
            //return View(response);
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
        public IActionResult Attendees2()
        {
            ViewBag.key = key;
            var str = ApiService.Get("https://api.polzki.com/api/attendees?key=" + key);

            AttendeeResponse attendeeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(str == null ? "" : str);
            // error on getting Attendee Event array value  FIXED!!
            return View(attendeeResponse);
        }
        public IActionResult UpdateAttendee()
        {
            //var str = ApiService.Get("https://api.polzki.com/api/updateattendees?key=" + key + "&AttendeeID="+ AttendeeId + "& Name="+ AttendeeName + "&EventID="+ EventID + "");

            //AttendeeResponse attendeesResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(str == null ? "" : str);

            //return View(attendeesResponse);

            #region for POST ONLY
            //var jsonStr = "";
            //var strPost = ApiService.Post("https://api.polzki.com/api/updateattendees?key=" + key + "&AttendeeID=[ATTENDEEID]&Name=[ATTENDEE_NAME]&EventID=[EVENTID]", jsonStr);

            //AttendeeResponse attendeesResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(strPost == null ? "" : strPost);

            //return View(attendeesResponse);
            #endregion
            return View();
        
        }

        public IActionResult SingleAttendee(String attendeeID)
        {
            //https://api.polzki.com/api/attendee?key={{Key}}&attendeeid=63cbe9312437a73b71357db4
            ViewBag.key = key;
            var str = ApiService.Get("https://api.polzki.com/api/attendee?key=f0ca0204016a40d8af03ce06ff38e0f4&attendeeid=63cbe9312437a73b71357db4");

            Models.SingleAttendee SingleAttendeeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.SingleAttendee>(str == null ? "" : str);
            //AttendeeResponse attendeeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(str == null ? "" : str);

            return PartialView(SingleAttendeeResponse);
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
