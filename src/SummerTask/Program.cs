﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Castle.Windsor;
using FormatConverter;
using FormatConverter.Parsers;

namespace SummerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //var fileUtils = new FileUtils();
            //var parsingStrategies = new List<IParsingStrategy>();
            //parsingStrategies.Add(new JsonParsingStrategy());
            //parsingStrategies.Add(new XmlParsingStrategy());
            //var parsingStrategyFactory = new ParsingStrategyFactory(parsingStrategies);
            //var parser = new Parser();
            //var converter = new FileConverter(fileUtils, parser, parsingStrategyFactory);

            var container = new WindsorContainer();
            container.Install(new SummerTaskDependencyInstaller());
            var converter = container.Resolve<IFileConverter>();
            // Output for user could be shown
            // Single responsibility is not met - logic should be extracted to the separate methods
            var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"); //hard coded paths - should be passed with parameter
            var targetFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json");

            converter.Execute(sourceFileName, targetFileName);
            // resolve file source to load file (web server/local drive/network drive..)
            // verify that file exists, validate its format
        }
    }


}
