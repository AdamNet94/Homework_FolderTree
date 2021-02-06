using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> readables = new List<string>();
            List<string> writables = new List<string>();

            readables.Add("/BME");
            readables.Add("/BME/4felev");
            readables.Add("/BME/5felev");
            readables.Add("/BME/6felev");
            readables.Add("/BME/4felev/grafika");
            readables.Add("/BME/5felev/adatvez");
            readables.Add("/BME/6felev/onlab");
            readables.Add("/BME/5felev/adatvez/labor/lab1");
            readables.Add("/BME/6felev/onlab/project");
            readables.Add("/BME/6felev/onlab/project/bin");
            readables.Add("/BME/4felev/grafika/GPUprog");


            writables.Add("/BME/5felev");
            writables.Add("/BME/5felev/adatvez");
            writables.Add("/BME/6felev/onlab");
            writables.Add("/BME/5felev/adatvez/labor/lab1");
            writables.Add("/BME/6felev/onlab/project/bin");
            writables.Add("/BME/4felev/grafika/GPUprog");

            var test = new TreeItem();
            test = test.GetWritableFolderStructure(readables,writables);
         
            Console.WriteLine(test);

        }



    }
}
