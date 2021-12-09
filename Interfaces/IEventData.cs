using api.Models;
using api.Data;
using System.Collections.Generic;

namespace api.Interfaces
{
    public interface IEventData
    {
         public List<Event> Select();
    }
}