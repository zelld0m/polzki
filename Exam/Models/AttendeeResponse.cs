using System.Collections.Generic;

namespace Exam.Models
{
    public class AttendeeResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Attendee> Data { get; set; }
    }
}
