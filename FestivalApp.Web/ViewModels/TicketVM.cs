using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalApp.Web.ViewModels
{
    public class TicketVM
    {
        public Ticket NewTicket { get; set; }
        public int SelectedType { get; set; }
        public SelectList lstTicketTypes { get; set; }

        public TicketVM(List<TicketType> lstTypes, Ticket ticket) {
            lstTicketTypes = new SelectList(lstTypes, "ID", "Name");
            NewTicket = ticket;
            ticket.Amount = 1;
        }

        public TicketVM() { 
        
        }
    }
}