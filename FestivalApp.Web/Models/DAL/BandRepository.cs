using DBHelper;
using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalApp.Web.Models.DAL
{
    public class BandRepository
    {
        public static List<Band> GetBands() {
            List<Band> lijst = new List<Band>();
            string sSQL = "SELECT * FROM [Band]";

            DbDataReader reader = Database.GetData(sSQL, null);

            if (reader != null && reader.HasRows) {
                while (reader.Read()) {
                    Band b = new Band();
                    b.ID = reader["BandID"].ToString();
                    b.Name = reader["Name"].ToString();

                    String p = reader["Picture"].ToString();
                    b.Picture = reader["Picture"].ToString();
                    b.PictureURL = "~/Images/Bands/" + p;

                    b.Description = reader["Description"].ToString();
                    b.Twitter = reader["Twitter"].ToString();
                    b.Facebook = reader["Facebook"].ToString();
                    lijst.Add(b);
                }
                reader.Close();
            }
            return (lijst);
        }
        public static Band FindBandById(String id) {
            List<Band> lijst = GetBands();
            return lijst.Where(band => band.ID == id).SingleOrDefault();
        }
    }
}