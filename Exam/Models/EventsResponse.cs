using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class EventsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Event> Data { get; set; }
    }
}
