using DBHelper;
using FestivalApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace FestivalApp.Web.Models.DAL
{
    public class StageRepository
    {
        public static List<Stage> GetStages() {
            List<Stage> lijst = new List<Stage>();
            string sSQL = "SELECT * FROM [Stage]";

            DbDataReader reader = Database.GetData(sSQL, null);

            if (reader != null && reader.HasRows) {
                while (reader.Read()) {
                    Stage s = new Stage();
                    s.ID = reader["StageID"].ToString();
                    s.Name = reader["Name"].ToString();
                    lijst.Add(s);
                }
            }
            return (lijst);
        }
        public static Stage FindStageByID(String id) {
            List<Stage> lijst = GetStages();
            return lijst.Where(stage => stage.ID == id).SingleOrDefault();
        }
    }
}