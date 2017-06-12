using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task4;

namespace Task4_LastVersion_
{
    public class CsvReader
    {
        

        public IList<SaleData> ReadCsv(string path)
        {
            var fileName = Path.GetFileName(path);
            var dataList = new List<SaleData>();
            if (fileName == null) return dataList;
            var managerName = fileName.Split('_').First();
            try
            {
                
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        var readLine = sr.ReadLine();
                        if (readLine == null) continue;
                        var param = readLine.Split(',');
                        dataList.Add(new SaleData(managerName, param[0], param[1], param[2], param[3]));
                    }
                }
            }
            catch (Exception e)
            {
                throw new FileNotFoundException("The file could not be read:{0}", e.Message);
            }

            return dataList;
        }
    }
}
