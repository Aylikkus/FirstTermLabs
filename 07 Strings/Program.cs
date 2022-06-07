using System;

namespace Strings
{
    public class Program
    {

        // Метод для выделения имени файла с расширением 
        public static string FileNameExt(string fileFullName) {
            string fileNameExt;

            // Если полное имя файла начинается со слеша
            // значит задана файловая система формата Unix
            if (fileFullName.IndexOf('/') == 0) {
                fileNameExt = fileFullName.Substring(fileFullName.LastIndexOf('/') + 1);
                return fileNameExt;
            }

            fileNameExt = fileFullName.Substring(fileFullName.LastIndexOf('\\') + 1);
            return fileNameExt;
        }

        // Метод для выделения пути к файлу
        public static string FileNamePath(string fileFullName) {
            string fileNamePath;

            if (fileFullName.IndexOf('/') == 0) {
                fileNamePath = fileFullName.Remove(fileFullName.LastIndexOf('/'));
                return fileNamePath;
            }

            fileNamePath = fileFullName.Remove(fileFullName.LastIndexOf('\\'));
            return fileNamePath;
        }
        public static void Main(string[] args)
        {
            // Строки, содержащие полное имя файла
            string myVideo = "C:\\Users\\alikku\\Videos\\2021-10-25_13-05-12.mkv";
            string myDotnetFile = "/usr/share/dotnet/dotnet";

            // Вывод имени файла с расширением
            Console.WriteLine($"\rWindows format\t\t Unix format\n\n{FileNameExt(myVideo)}\t {FileNameExt(myDotnetFile)}");

            // Вывод пути к файлу
            Console.WriteLine($"{FileNamePath(myVideo)}\t {FileNamePath(myDotnetFile)}");
        }

    }
}