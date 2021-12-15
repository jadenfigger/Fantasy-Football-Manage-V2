using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectController
{
    public class ProjectControllerData
    {
        public static LeagueModel cLeague = null;
        public static int cTeam;
        public static int cWeek = 1;
        public static int cPos;

        public static string scheduleFilePath = "schedule.xml";

        public static string[] FindAllLeagues()
        {
            return Directory.GetFiles("./", "*.sqlite");
        } 

        public static void SaveSchedule<T>()
        {
            TextWriter writer = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(scheduleFilePath, false);
                serializer.Serialize(writer, cLeague.Schedule);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static void ReadSavedSchedule<T>()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                reader = new StreamReader(scheduleFilePath);
                cLeague.Schedule = (ScheduleModel)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }

}
