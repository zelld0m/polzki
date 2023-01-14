using System.Collections.Generic;

namespace Exam.Models
{
    public class Attendee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegisterDate { get; set; }
        public List<Event> Events
        {
            get; set;
        } //ready

    }
}
