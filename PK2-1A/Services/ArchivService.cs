using MySqlConnector;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using cip_blue.Attributes;
using cip_blue.Models;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using System.Threading;

namespace cip_blue.Services
{
    public class ArchivService
    {
        public const string ConnStr = "server=localhost;user=sysdba;password=masterkey;database=asutp;default command timeout=20;";

        private Logger logger = LogManager.GetCurrentClassLogger();
        Dictionary<string, string> values;
        Dictionary<string, string> journal;

        private readonly ProcessDataTcp _processDataTcp;
        Dictionary<string, string> _archive;
        bool firstInit;

        public ArchivService(ProcessDataTcp processDataTcp)
        {
            _processDataTcp = processDataTcp;
            _archive = new Dictionary<string, string>();
            values = new Dictionary<string, string>();
            journal = new Dictionary<string, string>();
            foreach (PropertyInfo prop in processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive))
            {

                _archive.Add(prop.Name, String.Empty);

            }
        }


        public void Worker()
        {
            if (!_processDataTcp.testOn)
            {
                if (_processDataTcp.JOURNAL == 13 && !firstInit)
                {
                    foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive))
                    {
                        _archive[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                    }

                    firstInit = true;
                }


                if (_processDataTcp.JOURNAL == 13 && firstInit)
                {

                    foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && p.PropertyType != typeof(bool) && !p.CanWrite && Attribute.IsDefined(p, typeof(ArchivAttribute))))
                    {
                        //if (_archive[prop.Name] != prop.GetValue(_processDataTcp).ToString())
                        //{
                        // var t =prop.GetValue(_processDataTcp).ToString();
                        //if ( prop.GetValue(_processDataTcp).ToString()=="False")
                        // values.Add(prop.Name, "0");
                        //else if(prop.GetValue(_processDataTcp).ToString() == "True")
                        //     values.Add(prop.Name, "1");
                        // else values.Add(prop.Name, float.Parse(prop.GetValue(_processDataTcp).ToString()).ToString(CultureInfo.InvariantCulture));

                        values.Add(prop.Name, float.Parse(prop.GetValue(_processDataTcp).ToString()).ToString(CultureInfo.InvariantCulture));
                        _archive[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                        //    }
                    }

                    if (values.Count > 0)
                    {


                        using (var conn = new MySqlConnection(ConnStr))
                        {
                            try
                            {
                                conn.Open();

                                using (var command = conn.CreateCommand())
                                {

                                    command.CommandText = @"INSERT INTO measurements (DTS, `values`) VALUES (@DTS, @values); DELETE FROM measurements WHERE DTS < @minDTS";
                                    command.Parameters.AddWithValue("@DTS", DateTime.Now);
                                    command.Parameters.AddWithValue("@values", JsonConvert.SerializeObject(values));
                                    command.Parameters.AddWithValue("@minDTS", DateTime.Now.AddMonths(-2));

                                    command.ExecuteNonQuery();

                                }
                            }

                            catch (Exception ex)
                            {
                                logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
                            }
                            finally
                            {
                                conn.Close();
                            }
                            // You can generate a Token from the "Tokens Tab" in the UI
                            const string token = "mHucveNRwLyyPprDcHlGTjtXAE3B6aV3hRGW61Q3UfvT0_G6plFQvpJwS62jFrNK2g4fGEEDNU1HCAJzKoajlQ==";
                            const string bucket_journal = "belofor_detail";
                            const string bucket_serias = "belofor";
                            const string org = "belofor";

                            var client = InfluxDBClientFactory.Create("http://192.168.120.143:8086", token.ToCharArray());
                            string data_journal = "Log_Action,title=belofor_hmi log_mnemonic=" + "\"" + JsonConvert.SerializeObject(values) + "\"";
                            string replace = JsonConvert.SerializeObject(values).Replace("{", "")
                                 .Replace("\"", "")
                                 .Replace(":", "=")
                                 .Replace("}", "");
                            string data_serias = "belofor,title=mnemonic_seria_10s ";
                            var writeApi = client.GetWriteApiAsync();

                            // writeApi.WriteRecord(bucket_journal, org, WritePrecision.Ns, data_journal);

                            foreach (var item in values)
                            {
                                string send = data_serias + item.Key + "=" + item.Value;

                                writeApi.WriteRecordAsync(bucket_serias, org, WritePrecision.Ns, send);

                            }




                            values.Clear();
                        }
                    }

                }
            }

        }
    }
}



