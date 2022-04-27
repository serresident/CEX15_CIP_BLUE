using MySqlConnector;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using cip_blue.Services;

namespace cip_blue.Repositories
{
    public class ArchivRepository
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public DateTime[] GetMinMaxDateForMeasurements()
        {

            DateTime[] res = { DateTime.MinValue, DateTime.MinValue };

            try
            {
                using (var conn = new MySqlConnection(ArchivService.ConnStr))
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandTimeout = 60;
                        command.CommandText = "SELECT MIN(DTS) AS MINDTS, MAX(DTS) AS MAXDTS FROM measurements";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                res[0] = reader.GetDateTime(0);
                                res[1] = reader.GetDateTime(1);
                            }

                            reader.Close();
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                res = null;
                logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
            }
            return res;
        }
        public Dictionary<DateTime, Dictionary<string, string>> GetMeasurements(DateTime startDate, DateTime endDate)
        {

            var result = new Dictionary<DateTime, Dictionary<string, string>>();

            try
            {
                using (var conn = new MySqlConnection(ArchivService.ConnStr))
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandTimeout = 60;
                        command.CommandText = "SELECT * FROM measurements WHERE dts >= @startDate AND dts <= @endDate ORDER BY DTS ASC";
                        command.Parameters.AddWithValue("@startDate", startDate);
                        command.Parameters.AddWithValue("@endDate", endDate);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    result.Add(reader.GetDateTime(0).ToLocalTime(), JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.GetString(1)));
                                }
                                catch { }
                            }

                            reader.Close();
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                result = null;
                logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
            }
            

            return result;
        }
    }
}
