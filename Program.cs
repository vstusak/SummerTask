using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SummerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output for user could be shown
            // Single responsibility is not met - logic should be extracted to the separate methods
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"); //hard coded paths - should be passed with parameter
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            string input;

            var fileUtils = new FileUtils();
            try
            {
                // priority no 1
                // using should be used while using FileStream - file is not being closed in the current implementation
                //resolve file source to load file (web server/local drive/network drive..)
                // verify that file exists, validate its format
                input = fileUtils.OpenFile(sourceFileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //Specify type of exception, specify debug message. Do not create a new exception, but use original exception which includes the call stack.
            }

            // TODO initialize XML parser and use it to get doc
            var serializedDoc = JsonConvert.SerializeObject(doc); // save file to the correct path. Save file according to its target format - priority no 2

            var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
            var sw = new StreamWriter(targetStream);
            sw.Write(serializedDoc);
        }
    }

    //interface should not be used in this case
    public interface IDocument
    {
        string Title { get; set; }
        string Text { get; set; }
    }

    public class Document : IDocument
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
