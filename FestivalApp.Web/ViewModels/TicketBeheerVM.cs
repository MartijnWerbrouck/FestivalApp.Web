using FestivalApp.Model;
using FestivalApp.Web.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalApp.Web.ViewModels
{
    public class TicketBeheerVM
    {
        public List<Ticket> Tickets = TicketRepository.GetTickets();
        public List<int> aTickets { get; set; }

        public TicketBeheerVM(List<Ticket> tickets, List<int> atickets) {
            tickets = Tickets;
            aTickets = CheckAvailableTickets();
        }

        public TicketBeheerVM() { }

        public List<int> CheckAvailableTickets() {
            List<int> lijst = new List<int>();
            List<Ticket> tlijst = TicketRepository.GetTickets();
            int aantal1 = TicketTypeRepository.FindTicketTypeByName("Combi").AvailableTickets;
            int aantal2 = TicketTypeRepository.FindTicketTypeByName("Vrijdag").AvailableTickets;
            int aantal3 = TicketTypeRepository.FindTicketTypeByName("Zaterdag").AvailableTickets;
            int aantal4 = TicketTypeRepository.FindTicketTypeByName("Zondag").AvailableTickets;
            foreach (Ticket t in tlijst) {
                if (t.TicketType.Name == "Combi") {
                    aantal1 = aantal1 - t.Amount;
                }
                if (t.TicketType.Name == "Vrijdag") {
                    aantal2 = aantal2 - t.Amount;
                }
                if (t.TicketType.Name == "Zaterdag") {
                    aantal3 = aantal3 - t.Amount;
                }
                if (t.TicketType.Name == "Zondag") {
                    aantal4 = aantal4 - t.Amount;
                }              
            }
            lijst.Add(aantal1);
            lijst.Add(aantal2);
            lijst.Add(aantal3);
            lijst.Add(aantal4);

            return lijst;
        }
    }
}