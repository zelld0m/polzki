using System;

namespace Exam.Models
{
    public class SingleAttendeeModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public Events Event { get; set; }
    }
}
