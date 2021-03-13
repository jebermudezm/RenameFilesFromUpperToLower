using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RenombrarArchivosFromUpperToLower
{
    class Program
    {
        static void Main(string[] args)
        {
            string functionName = "zebulans_nightmare";
            TextInfo txtInfo = new CultureInfo("en-us", false).TextInfo;
            functionName = txtInfo.ToTitleCase(functionName);
            Console.Out.WriteLine(functionName);
            //Console.ReadLine();

            var rutaArchivos = @"D:\DirTrab\AES\MVM\ConsolaOperaciones\ConsolaOperaciones\ConsolaOperaciones.Modelo\EntidadesOpera";
            DirectoryInfo info = new DirectoryInfo(rutaArchivos);
            var files = info.GetFiles().OrderByDescending(p => p.CreationTime).ToList();
            foreach (var item in files)
            {
                var nombreArchivoOriginal = item.Name;
                var nombreArchivoNuevo = CamelCase(nombreArchivoOriginal); // txtInfo.ToTitleCase(nombreArchivoOriginal).Replace(".Cs", ".cs");

                var fullNameNuevo = item.FullName.Replace(nombreArchivoOriginal, nombreArchivoNuevo);
                File.Move(item.FullName, fullNameNuevo);
                Console.WriteLine(fullNameNuevo);
            }
            Console.Out.WriteLine("Press <Enter> to exit...");
            Console.ReadLine();
        }
        static string CamelCase(string s)
        {
            var x = s; //.Replace("_", "");
            if (x.Length == 0) return "Null";
            x = Regex.Replace(x, "([A-Z])([A-Z]+)($|[A-Z])",
                m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
            return char.ToUpper(x[0]) + x.Substring(1);
        }
    }
}
