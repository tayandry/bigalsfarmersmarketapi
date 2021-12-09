using System;
using api.Interfaces;
using api.Data;

namespace api.Models
{
    public class Event
    {
        public string Date {get; set;}

        public int EventID {get; set;}

        public string Time { get; set; }

        public IEventData eventDataHandler {get; set;}

        public Event()
        {
            eventDataHandler = new EventDataHandler();
        }


    }
}