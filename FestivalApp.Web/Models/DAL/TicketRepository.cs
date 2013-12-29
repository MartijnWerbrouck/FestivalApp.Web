using DBHelper;
using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalApp.Web.Models.DAL
{
    public class TicketRepository
    {
        public static List<Ticket> GetTickets() {
            List<Ticket> lijst = new List<Ticket>();
            string sSQL = "SELECT * FROM [Ticket]";

            DbDataReader reader = Database.GetData(sSQL, null);

            if (reader != null && reader.HasRows) {
                while (reader.Read()) {
                    Ticket t = new Ticket();
                    t.ID = reader["TicketID"].ToString();
                    t.Ticketholder = reader["Ticketholder"].ToString();
                    t.TicketholderEmail = reader["TicketholderEmail"].ToString();
                    String TicketID = reader["TicketTypeID"].ToString();
                    t.TicketType = TicketTypeRepository.FindTicketTypeByID(TicketID);
                    t.Amount = Convert.ToInt32(reader["Amount"].ToString());
                    lijst.Add(t);
                }
            }
            return (lijst);
        }

        public static void InsertTickets(Ticket t) {
            String sSQL = "INSERT INTO Ticket (Ticketholder, TicketholderEmail, TicketTypeID, Amount) VALUES (@Ticketholder, @TicketholderEmail, @TicketTypeID, @Amount)";
           
            DbParameter par1 = Database.AddParameter("@Ticketholder", t.Ticketholder);
            DbParameter par2 = Database.AddParameter("@TicketholderEmail", t.TicketholderEmail);
            DbParameter par3 = Database.AddParameter("@TicketTypeID", Convert.ToInt32(t.TicketType.ID));
            DbParameter par4 = Database.AddParameter("@Amount", Convert.ToInt32(t.Amount));

            Database.ModifyData(sSQL, par1, par2, par3, par4);
        }
    }
}