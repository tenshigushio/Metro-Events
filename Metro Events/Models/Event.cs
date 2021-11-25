using System;
using System.Collections.Generic;
using System.Text;

namespace Metro_Events.Models
{
    public class Event
    {
        public Event() { }

        public string EventId { get; set; }
        public string EventName { get; set; }
        public string ImageUrl { get; set; }
        public string[] Attendees { get; set; }
        public string Category { get; set; }
        public DateTime Created_at { get; set; }
        public string Description { get; set; }
        public string Event_date { get; set; }
        public string Event_status { get; set; }
        public bool IsOnlineEvent { get; set; }
        public string OrganizerId { get; set; }
        public int Upvotes { get; set; }
        public string Venue { get; set; }

        public override string ToString()
        {
            return EventName;
        }
    }
}
