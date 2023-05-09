using Serilog.Events;
using Serilog.Formatting;
using System.Text.RegularExpressions;

namespace $safeprojectname$.LogFormatters
{
    public class FileFormatter : ITextFormatter
    {
        private string StripEscapes(string message)
        {
            foreach (Match match in Regex.Matches(message, @"\x1b\[((\d.+?)?\d)m"))
            {
                message = message.Replace(match.Value, "");
            }

            return message.Replace("\"", "");
        }

        public void Format(LogEvent logEvent, TextWriter output)
        {
            string newLine = Environment.NewLine;

            string timestamp = logEvent.Timestamp.ToString("HH:mm:ss");
            string logLevel = logEvent.Level.ToString().ToUpper().Substring(0, 4);
            string context = logEvent.Properties.FirstOrDefault(x => x.Key == "Context").Value.ToString();
            string message = logEvent.RenderMessage();
            string exception = logEvent.Exception != null ? $"{newLine}{logEvent.Exception}{newLine}{logEvent.Exception.StackTrace}" : "";

            string logMessage = StripEscapes($"[{timestamp} {logLevel}] [{context}] {message}{exception}");

            output.WriteLine(logMessage);
        }
    }
}
