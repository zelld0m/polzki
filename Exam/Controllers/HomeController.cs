using Exam.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        string key = "01cb716174f94156bd7d28c7faafedec"; // GET KEY FROM SITE  https://api.polzki.com/home/eventsapidocs click get your key Here
        public IActionResult Event()
        {

            var str = ApiService.Get("https://api.polzki.com/api/events?key="+key);

           // FOR POST
           // var jsonStr = "";
           // var strPost = ApiService.Post("https://api.polzki.com/api/events?key=01cb716174f94156bd7d28c7faafedec", jsonStr);

            EventsResponse eventsResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<EventsResponse>(str == null ? "" : str);

            return View(eventsResponse);
        }

        public IActionResult Attendee()
        {

            var str = ApiService.Get("https://api.polzki.com/api/attendees?key="+key);

            AttendeeResponse attendeeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(str == null ? "" : str);

            return View(attendeeResponse);
        }
        //public IActionResult UpdateAttendee()
        //{
        //     var jsonStr = "";
        //     var strPost = ApiService.Post("https://api.polzki.com/api/updateattendee?key="+key+"&AttendeeID=[ATTENDEEID]&Name=[ATTENDEE_NAME]&EventID=[EVENTID]", jsonStr);

        //    AttendeeResponse attendeeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(strPost == null ? "" : strPost);

        //    return View(attendeeResponse);
        //}

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
