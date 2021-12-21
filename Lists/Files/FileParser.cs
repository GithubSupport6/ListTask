using SimpleAlgorithmsApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Files
{
    class FileParser
    {

        private static string GetParamName(string line)
        {
            return line.Split('=')[0].Trim();
        }
        private static string GetParamValue(string[] lines, string param)
        {
            foreach (var line in lines)
            {
                string name = GetParamName(line);
                if (name == param)
                {
                    return line.Split('=')[1].Trim();
                }
            }
            return String.Empty;
        }

        public static void Save(CustomList<string> list, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (GraphicBlock<string> elem in list)
                {
                    
                }
            }
        }

        public static CustomList<GraphicBlock<string>> Parse(string filename) 
        {
            CustomList<GraphicBlock<string>> res = new CustomList<GraphicBlock<string>>();
            //можно, конечно, использовать сериализацию, но она в отдельном пакете
            //не знаю, можно ли так
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.StartsWith("block: "))
                    {
                        int startIndex = line.IndexOf('(');
                        int endIndex = line.IndexOf(')');
                        line = line.Substring(startIndex+1, endIndex - startIndex - 1);
                        var settings = line.Split(',');

                        int x = Int32.Parse(GetParamValue(settings, "x"));
                        int y = Int32.Parse(GetParamValue(settings, "y"));
                        GraphicBlock<string> block = new GraphicBlock<string>(
                            GetParamValue(settings, "data"),
                            x,
                            y,
                            GetParamValue(settings, "w") == "" ? default : Int32.Parse(GetParamValue(settings, "w")),
                            GetParamValue(settings, "h") == "" ? default : Int32.Parse(GetParamValue(settings, "h"))
                        );
                        res.Add(block);
                    }
                }
            }
            return res;
        }
    }
}
