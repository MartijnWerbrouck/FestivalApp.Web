using FestivalApp.Model;
using FestivalApp.Web.Models.DAL;
using FestivalApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalApp.Web.Controllers
{
    public class LineUpController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index() {
            return View(LineUpRepository.GetLineUps());
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

        [HttpPost]
        [Authorize]
        public ActionResult Reserveer(TicketVM ticketVM, long sType) {
            if (ModelState.IsValid) {
                Ticket t = new Ticket();
                t.Ticketholder = ticketVM.NewTicket.Ticketholder;
                t.TicketholderEmail = ticketVM.NewTicket.TicketholderEmail;

                t.TicketType = TicketTypeRepository.FindTicketTypeByID(sType.ToString());

                t.Amount = ticketVM.NewTicket.Amount;
                TicketRepository.InsertTickets(t);
                return RedirectToAction("Index", "LineUp");
            }
            else {
                return View(ticketVM);
            }
        }

        [Authorize]
        public ActionResult TicketBeheer() {
            List<Ticket> tickets = TicketRepository.GetTickets();
            List<int> lijst = new List<int>();
            var viewModel = new TicketBeheerVM(tickets, lijst);
            return View(viewModel);
        }
    }
}
