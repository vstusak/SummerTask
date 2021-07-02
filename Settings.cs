using System.Collections.Generic;

namespace SummerTask
{
    public class Settings
    {
        public string InputSource { get; set; }
        public IEnumerable<string> Targets { get; set; }

        public InputType InputType { get; set; }
    }
}