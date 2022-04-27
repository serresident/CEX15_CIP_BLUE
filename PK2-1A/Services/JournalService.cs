using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using cip_blue.Attributes;
using cip_blue.Models;
using System.Globalization;
using Newtonsoft.Json;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;

namespace cip_blue.Services
{
    public class JournalService
    {
        private const string connStr = "server=localhost ;user=sysdba;password=masterkey;database=asutp;default command timeout=20;";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly ProcessDataTcp _processDataTcp;

        Dictionary<string, string> _journal;
        Dictionary<string, string> values;

        bool firstInit;


        public JournalService(ProcessDataTcp processDataTcp)
        {
            _processDataTcp = processDataTcp;
            _journal = new Dictionary<string, string>();
            values = new Dictionary<string, string>();

            foreach (PropertyInfo prop in processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && Attribute.IsDefined(p, typeof(JournalAttribute))))
               // foreach (PropertyInfo prop in processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive ))
                {
                    
                _journal.Add(prop.Name, String.Empty);
            }
        }
        //Rr6qESotEniwmvQg7--eNjdQ6oHTzErVZbY1N67ndKX_orFsvTaRIyFVkKjnzuVsEoY4ckzvX1362MYe_au-dg==
        public void Worker()
        {
            if (_processDataTcp.JOURNAL == 13 && !firstInit)
            {
                foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && p.PropertyType == typeof(bool) && p.CanWrite  /*&& Attribute.IsDefined(p, typeof(JournalAttribute)*/))
                {
                    _journal[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                }

                firstInit = true;
            }

            if (_processDataTcp.JOURNAL == 13 && firstInit)
            {
                foreach (PropertyInfo prop in _processDataTcp.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && p.PropertyType == typeof(bool) && p.CanWrite /*&& Attribute.IsDefined(p, typeof(JournalAttribute)*/))
                {
                    if (_journal[prop.Name] != prop.GetValue(_processDataTcp).ToString())
                    {
                      var attr = prop.GetCustomAttribute<JournalAttribute>();

                        if (prop.GetValue(_processDataTcp).ToString() == "False")
                            values.Add(prop.Name, "0");
                        else if (prop.GetValue(_processDataTcp).ToString() == "True")
                            values.Add(prop.Name, "1");
                        else values.Add(prop.Name, float.Parse(prop.GetValue(_processDataTcp).ToString()).ToString(CultureInfo.InvariantCulture));
                      //  values.Add(prop.Name, float.Parse(prop.GetValue(_processDataTcp).ToString()).ToString(CultureInfo.InvariantCulture));
                        //using (var conn = new MySqlConnection(connStr))
                        //{
                        //    try
                        //    {
                        //        conn.Open();

                        //        using (var command = conn.CreateCommand())
                        //        {

                        //            command.CommandText = @"INSERT INTO journal (DTS, `message`) VALUES (@DTS, @message); DELETE FROM journal WHERE DTS < @minDTS";
                        //            command.Parameters.AddWithValue("@DTS", DateTime.Now);
                        //            command.Parameters.AddWithValue("@message", string.Format(attr.Message+ " "+prop.Name+ " >> [{0}] --> [{1}]", _journal[prop.Name], prop.GetValue(_processDataTcp)));
                        //            command.Parameters.AddWithValue("@minDTS", DateTime.Now.AddDays(-7));

                        //            command.ExecuteNonQuery();

                        //        }
                        //    }

                        //    catch (Exception ex)
                        //    {
                        //        _logger.Error(ex, "Insert new journal MySql");
                        //    }
                        //    finally
                        //    {
                        //        // always call Close when done reading.
                        //        conn.Close();
                        //    }


                    }

                        _journal[prop.Name] = prop.GetValue(_processDataTcp).ToString();
                    }

                if (values.Count > 0)
                {  // You can generate a Token from the "Tokens Tab" in the UI
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
                    {
                      writeApi.WriteRecordsAsync(bucket_journal, org, WritePrecision.Ns, data_journal);

                        //foreach (var item in values)
                        //{
                        //    string send = data_serias + item.Key + "=" + item.Value;
                        //    writeApi.WriteRecord(bucket_serias, org, WritePrecision.Ns, send);
                          
                        //}

                    }


                    values.Clear();
                }

                }
            }


        }
    }


