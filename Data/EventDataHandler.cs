using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;


namespace api.Data
{
    public class EventDataHandler : IEventData
    {
        private Database db;

        public EventDataHandler()
        {
            db = new Database();
        }

        public List<Event> Select()
        {
            List<Event> myEvents = new List<Event>();
            string sql = "SELECT * from events";
            db.Open();
            List<ExpandoObject> results = db.Select(sql);

            foreach(dynamic item in results)
            {
                Event temp = new Event(){Date = item.Date, 
                EventID = item.eventid,
                Time = item.time};

                myEvents.Add(temp);

            }

            db.Close();
            return myEvents;
        }

        public Dictionary<string,object> GetValues(Event events)
         {
             var values = new Dictionary<string,object>(){
                 {"@Date", events.Date},
                 {"@eventid", events.EventID},
                 {"@time", events.Time}

             }; 

             return values;
         } 



        
    }


}