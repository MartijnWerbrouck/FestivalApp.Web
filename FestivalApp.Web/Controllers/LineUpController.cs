using FestivalApp.Model;
using FestivalApp.Web.Models.DAL;
using FestivalApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace FestivalApp.Web.Controllers
{
    public class LineUpController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index() {
            var LineUps = LineUpRepository.GetLineUps();
            return View(LineUps);
        }

        [AllowAnonymous]
        public ActionResult Details(int id) {
            var lu = LineUpRepository.FindLineUpById(Convert.ToString(id));
            if (lu == null) {
                return HttpNotFound();
            }
            return View(lu);
        }

        [Authorize]
        public ActionResult Reserveer() {
            List<TicketType> lijst = TicketTypeRepository.GetTypes();
            Ticket t = new Ticket {Ticketholder = User.Identity.Name};
            var viewModel = new TicketVM(lijst, t);
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult Search(string Artist, string Date, string Stage) {
            if (Artist != null) {
                var LineUps = LineUpRepository.GetLineUps().Where(lu => lu.Band.Name.Contains(Artist));
                return View(LineUps);
            }
            if (Date != null) {
                var LineUps = LineUpRepository.GetLineUps().Where(lu => lu.Date.Contains(Date));
                return View(LineUps);
            }
            if (Stage != null) {
                var LineUps = LineUpRepository.GetLineUps().Where(lu => lu.Stage.Name.Contains(Stage));
                return View(LineUps);
            }
            else {
                var LineUps = LineUpRepository.GetLineUps();
                return View(LineUps);
            } 
        }

        [HttpPost]
        [Authorize]
        public ActionResult Reserveer(TicketVM ticketVM, long sType) {
            if (ModelState.IsValid) {
                Ticket t = new Ticket();
                String name = ticketVM.NewTicket.Ticketholder;
                t.Ticketholder = ticketVM.NewTicket.Ticketholder;
                t.TicketholderEmail = ticketVM.NewTicket.TicketholderEmail;

                TicketType tt = TicketTypeRepository.FindTicketTypeByID(sType.ToString());
                t.TicketType = TicketTypeRepository.FindTicketTypeByID(sType.ToString());
                string ttName = tt.Name;

                t.Amount = ticketVM.NewTicket.Amount;
                if (tt.AvailableTickets - t.Amount < 0) {
                    return RedirectToAction("NoTickets", "LineUp");
                }
                TicketRepository.InsertTickets(t);
                return RedirectToAction("TicketsSucces", "LineUp");
            }
            else {
                return View(ticketVM);
            }
        }

        [Authorize]
        public ActionResult TicketBeheer() {
            if (User.IsInRole("Admin")) {
                List<Ticket> tickets = TicketRepository.GetTickets();
                List<int> lijst = new List<int>();
                var viewModel = new TicketBeheerVM(tickets, lijst);
                return View(viewModel);
            }
            else {
                return RedirectToAction("NoAdmin", "LineUp");
            }
        }

        [Authorize]
        public ActionResult TicketsSucces() {
            String name = User.Identity.Name;
            List<Ticket> lijst = TicketRepository.GetTicketsByName(name);
            return View(lijst);
        }

        [Authorize]
        public ActionResult NoAdmin() {
            return View();
        }

        [Authorize]
        public ActionResult NoTickets() {
            return View();
        }
    }
}
