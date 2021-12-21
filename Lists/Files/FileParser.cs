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

        public static string Keyword { get; set; } = "Block";

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

        public static void Save(CustomList<GraphicBlock<string>> list, string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (GraphicBlock<string> elem in list)
                {
                    sw.WriteLine(Keyword + " (data={0},x={1},y={2},w={3},h={4})",
                        elem.Data,
                        elem.X,
                        elem.Y,
                        elem.Width,
                        elem.Height
                    );
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
                    if (line.StartsWith(Keyword))
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
                            GetParamValue(settings, "w") == "" ? GraphicBlock<string>.DefaultWidth : Int32.Parse(GetParamValue(settings, "w")),
                            GetParamValue(settings, "h") == "" ? GraphicBlock<string>.DefaultHeight : Int32.Parse(GetParamValue(settings, "h"))
                        );
                        res.Add(block);
                    }
                }
            }
            return res;
        }
    }
}
