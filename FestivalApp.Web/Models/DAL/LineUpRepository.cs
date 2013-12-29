using DBHelper;
using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalApp.Web.Models.DAL
{
    public class LineUpRepository
    {
        public static List<LineUp> GetLineUps() {
            List<LineUp> lijst = new List<LineUp>();
            string sSQL = "SELECT * FROM [LineUp] ORDER BY Date ASC";

            DbDataReader reader = Database.GetData(sSQL, null);

            if (reader != null && reader.HasRows) {
                while (reader.Read()) {
                    LineUp lu = new LineUp();
                    lu.ID = reader["LineUpID"].ToString();

                    DateTime date = Convert.ToDateTime(reader["Date"].ToString());
                    lu.Date = date.ToShortDateString();
                   
                    lu.From = reader["From"].ToString();
                    lu.Until = reader["Until"].ToString();

                    string StageID = reader["StageID"].ToString();
                    lu.Stage = StageRepository.FindStageByID(StageID);

                    string BandID = reader["BandID"].ToString();
                    lu.Band = BandRepository.FindBandById(BandID);

                    lijst.Add(lu);
                }
            }
            return (lijst);
        }
        public static LineUp FindLineUpById(String id) {
            List<LineUp> lijst = GetLineUps();
            return lijst.Where(lineup => lineup.ID == id).SingleOrDefault();
        }
    }
}