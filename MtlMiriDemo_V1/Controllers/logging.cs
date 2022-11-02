using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtlMiriDemo_V1.Controllers
    {
    public static class logging
        {

        public static void WriteThis(dynamic obj)
            {
            StreamWriter sw;
            string date = DateTime.Now.ToString(" dd-MM-hh-mm");
            string path = @"C:\Logs\logs" + date + ".txt";
            sw = File.AppendText(path);



            //log the details of the exception and page state

            sw.WriteLine(" \n");
            sw.WriteLine("******************************************************************");
            sw.WriteLine(obj.ToString());

            sw.WriteLine("\n******************************************************************");
            sw.Close();

            }
        }
    }
