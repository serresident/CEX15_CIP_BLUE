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
    public class LogicService
    {
        private const string connStr = "server=localhost ;user=sysdba;password=masterkey;database=asutp;default command timeout=20;";

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly ProcessDataTcp _processDataTcp;
        private readonly LogicData ld;

        Dictionary<string, string> _journal;
        Dictionary<string, string> values;
        int state_bel_ocd_480A;
        bool firstInit;


        public LogicService(ProcessDataTcp processDataTcp, LogicData logicData)
        {
            _processDataTcp = processDataTcp;
            ld = logicData;
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
            


         }


        }
    }


