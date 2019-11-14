using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Repository.Hierarchy;
using Trx2Excel.ExcelUtils;
using Trx2Excel.TrxReaderUtil;

namespace Trx2Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length < 2)
            {
               Console.WriteLine("usage: Trx2Excel <trxfile> <excelfile> -a:--allinonesheet");
               return;
            }
            Console.WriteLine(args.Length);
            var reader = new TrxReader(args[0]);
            Console.WriteLine("[INFO] : Reading the Trx file : {0}", args[0]);
            var resultList = reader.GetTestResults();
            Console.WriteLine("[INFO] : Getting TestResult from Trx file : {0}", args[0]);
            var excelWriter = new ExcelWriter(args[1],args.Length == 3 && (
                   new string[] { "-a","--allinonesheet" }.Contains(args[2])));
            excelWriter.WriteToExcel(resultList);
            Console.WriteLine("[INFO] : Writing to Excel File : {0}", args[1]);
            excelWriter.AddChart(reader.PassCount,reader.FailCount,reader.SkipCount);
            Console.WriteLine("[INFO] : Generating charts : {0}", args[1]);
            Console.WriteLine("[INFO] : Output File : {0}", args[1]);
        }
    }
}
