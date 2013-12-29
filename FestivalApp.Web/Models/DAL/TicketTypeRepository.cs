using DBHelper;
using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalApp.Web.Models.DAL
{
    public class TicketTypeRepository
    {
        public static List<TicketType> GetTypes() {
            List<TicketType> lijst = new List<TicketType>();
            string sSQL = "SELECT * FROM [TicketType]";

            DbDataReader reader = Database.GetData(sSQL, null);

            if (reader != null && reader.HasRows) {
                while (reader.Read()) {
                    TicketType tt = new TicketType();
                    tt.ID = reader["TicketTypeID"].ToString();
                    tt.Name = reader["Name"].ToString();
                    tt.Price = Convert.ToDouble(reader["Price"].ToString());
                    tt.AvailableTickets = Convert.ToInt32(reader["AvailableTickets"].ToString());
                    lijst.Add(tt);
                }
            }
            return (lijst);
        }
        public static TicketType FindTicketTypeByID(String id) {
            List<TicketType> lijst = GetTypes();
            return lijst.Where(tt => tt.ID == id).SingleOrDefault();
        }
        public static TicketType FindTicketTypeByName(String name) {
            List<TicketType> lijst = GetTypes();
            return lijst.Where(tt => tt.Name == name).SingleOrDefault();
        }
    }
}