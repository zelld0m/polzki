using System;
using System.Collections.Generic;

namespace Exam.Models
{
    public class Attendee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public Events Event { get; set; }
    }

    public class Events
    {
        public string ID { get; set; }
        public string EventName { get; set; }
    }

    public class Root
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Attendee> Data { get; set; }
    }

    
}
