using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class CsvStreamWriter : StreamWriter
    {
        private readonly string ValueSeparator;

        public CsvStreamWriter(Stream stream, bool autoFlush) : base(stream)
        {
            AutoFlush = autoFlush;
            ValueSeparator = Helpers.SeparatorSemicolon;
        }

        public void WriteLine(IEnumerable<string> values)
        {
            if (!values.Any()) return;

            var line = string.Join(ValueSeparator, values);
            base.WriteLine(line);
        }

        public void WriteLine(params string[] values)
        {
            if (!values.Any()) return;

            var line = string.Join(ValueSeparator, values);
            base.WriteLine(line);
        }
    }
}
