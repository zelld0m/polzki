using Exam.Service;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Exam.Models;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Event()
        {

            var str = ApiService.Get("https://api.polzki.com/api/events?key=01cb716174f94156bd7d28c7faafedec");

           // var jsonStr = "";
           // var strPost = ApiService.Post("https://api.polzki.com/api/events?key=01cb716174f94156bd7d28c7faafedec", jsonStr);

            EventsResponse eventsResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<EventsResponse>(str == null ? "" : str);

            return View(eventsResponse);
        }

        public IActionResult Attendee()
        {

            var str = ApiService.Get("https://api.polzki.com/api/attendees?key=01cb716174f94156bd7d28c7faafedec");

            // var jsonStr = "";
            // var strPost = ApiService.Post("https://api.polzki.com/api/attendees?key=01cb716174f94156bd7d28c7faafedec", jsonStr);

            AttendeeResponse attendeeResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AttendeeResponse>(str == null ? "" : str);

            return View(attendeeResponse);
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
