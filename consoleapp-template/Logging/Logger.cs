using $safeprojectname$.LogFormatters;
using Serilog;
using Serilog.Parsing;
using Serilog.Sinks.SystemConsole.Themes;
using System.Reflection;

namespace $safeprojectname$.Logging
{
    public static class ILoggerExtensions
    {
        public static ILogger WithContext(this ILogger logger, Type T, string contextTag)
        {
            string name = T.Name;
            contextTag = contextTag.Remove(0, name.Length).Insert(0, name);

            return logger.ForContext("Context", contextTag);
        }

        public static ILogger WithContext<T>(this ILogger logger, string contextTag)
        {
            string name = typeof(T).Name;

            contextTag = contextTag.Remove(0, name.Length).Insert(0, name);

            return logger.ForContext("Context", contextTag);
        }
    }

    public class Logger : $safeprojectname$.Interfaces.ILogger
    {
        private Serilog.ILogger _logger;

        private string _contextTag = "";

        private string logPath = Path.Join(Environment.CurrentDirectory, "Logs", "$safeprojectname$_.txt");

        private void SetContextTag()
        {
            var typeNames = Assembly.GetExecutingAssembly().GetTypes().Select(x => x.Name);

            int longestLength = typeNames.OrderByDescending(x => x.Length).First().Length;

            _contextTag = $"{new string(' ', longestLength)}";
        }

        public Logger()
        {
            SetContextTag();

#if DEBUG
            var template = new MessageTemplateParser().Parse(outputFormat);

            _logger = new LoggerConfiguration().MinimumLevel.Debug()
                                               .WriteTo.Console(outputTemplate: outputFormat, theme: _theme)
                                               .CreateLogger();
#else
            _logger = new LoggerConfiguration().MinimumLevel.Debug()
                                               .WriteTo.Console(outputTemplate: outputFormat, theme: _theme)
                                               .WriteTo.File(
                                                              formatter: new FileFormatter(),
                                                              path: logPath,
                                                              rollingInterval: RollingInterval.Day
                                                              )
                                               .CreateLogger();
#endif
        }

        private string outputFormat = "[{Timestamp:HH:mm:ss} {Level:u4}] [{Context}] {Message:lj}{NewLine}{Exception}";

        public AnsiConsoleTheme _theme { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\x1b[38;5;0253m",
                [ConsoleThemeStyle.SecondaryText] = "\x1b[38;5;0246m",
                [ConsoleThemeStyle.TertiaryText] = "\x1b[38;5;0242m",
                [ConsoleThemeStyle.Invalid] = "\x1b[33;1m",
                [ConsoleThemeStyle.Null] = "\x1b[38;5;0038m",
                [ConsoleThemeStyle.Name] = "\x1b[38;5;0081m",
                [ConsoleThemeStyle.String] = "\x1b[38;5;0216m",
                [ConsoleThemeStyle.Number] = "\x1b[38;5;151m",
                [ConsoleThemeStyle.Boolean] = "\x1b[38;5;0038m",
                [ConsoleThemeStyle.Scalar] = "\x1b[38;5;0079m",
                [ConsoleThemeStyle.LevelVerbose] = "\x1b[37m",
                [ConsoleThemeStyle.LevelDebug] = "\x1b[37m",
                [ConsoleThemeStyle.LevelInformation] = "\x1b[38;5;69m",
                [ConsoleThemeStyle.LevelWarning] = "\x1b[38;5;0229m",
                [ConsoleThemeStyle.LevelError] = "\x1b[38;5;0197m\x1b[48;5;0238m",
                [ConsoleThemeStyle.LevelFatal] = "\x1b[38;5;0197m\x1b[48;5;0238m",
            });

        #region Debug Wrappers
        // with Type
        public void Debug(Type type, string message)
        {
            _logger.WithContext(type, _contextTag).Debug(message);
        }

        public void Debug(Type type, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Debug(messageTemplate, propertyValues);
        }

        public void Debug(Type type, Exception ex, string messageTemplate)
        {
            _logger.WithContext(type, _contextTag).Debug(ex, messageTemplate);
        }

        public void Debug(Type type, Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Debug(ex, messageTemplate, propertyValues);
        }

        // with T
        public void Debug<T>(string message)
        {
            _logger.WithContext<T>(_contextTag).Debug(message);
        }

        public void Debug<T>(string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Debug(messageTemplate, propertyValues);
        }

        public void Debug<T>(Exception ex, string messageTemplate)
        {
            _logger.WithContext<T>(_contextTag).Debug(ex, messageTemplate);
        }

        public void Debug<T>(Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Debug(ex, messageTemplate, propertyValues);
        }
        #endregion

        #region Info Wrappers
        // with Type
        public void Info(Type type, string message)
        {
            _logger.WithContext(type, _contextTag).Information(message);
        }

        public void Info(Type type, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Information(messageTemplate, propertyValues);
        }

        public void Info(Type type, Exception ex, string messageTemplate)
        {
            _logger.WithContext(type, _contextTag).Information(ex, messageTemplate);
        }

        public void Info(Type type, Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Information(ex, messageTemplate, propertyValues);
        }

        // with T
        public void Info<T>(string message)
        {
            _logger.WithContext<T>(_contextTag).Information(message);
        }

        public void Info<T>(string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Information(messageTemplate, propertyValues);
        }

        public void Info<T>(Exception ex, string messageTemplate)
        {
            _logger.WithContext<T>(_contextTag).Information(ex, messageTemplate);
        }

        public void Info<T>(Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Information(ex, messageTemplate, propertyValues);
        }
        #endregion

        #region Warning Wrappers
        // with type
        public void Warn(Type type, string message)
        {
            _logger.WithContext(type, _contextTag).Warning(message);
        }

        public void Warn(Type type, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Warning(messageTemplate, propertyValues);
        }

        public void Warn(Type type, Exception ex, string messageTemplate)
        {
            _logger.WithContext(type, _contextTag).Warning(ex, messageTemplate);
        }

        public void Warn(Type type, Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Warning(ex, messageTemplate, propertyValues);
        }

        // with T
        public void Warn<T>(string message)
        {
            _logger.WithContext<T>(_contextTag).Warning(message);
        }

        public void Warn<T>(string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Warning(messageTemplate, propertyValues);
        }

        public void Warn<T>(Exception ex, string messageTemplate)
        {
            _logger.WithContext<T>(_contextTag).Warning(ex, messageTemplate);
        }

        public void Warn<T>(Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Warning(ex, messageTemplate, propertyValues);
        }
        #endregion

        #region Error Wrappers
        // with type
        public void Error(Type type, string message)
        {
            _logger.WithContext(type, _contextTag).Error(message);
        }

        public void Error(Type type, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Error(messageTemplate, propertyValues);
        }

        public void Error(Type type, Exception ex, string messageTemplate)
        {
            _logger.WithContext(type, _contextTag).Error(ex, messageTemplate);
        }

        public void Error(Type type, Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Error(ex, messageTemplate, propertyValues);
        }

        // with T
        public void Error<T>(string message)
        {
            _logger.WithContext<T>(_contextTag).Error(message);
        }

        public void Error<T>(string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Error(messageTemplate, propertyValues);
        }

        public void Error<T>(Exception ex, string messageTemplate)
        {
            _logger.WithContext<T>(_contextTag).Error(ex, messageTemplate);
        }

        public void Error<T>(Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Error(ex, messageTemplate, propertyValues);
        }
        #endregion

        #region Fatal Wrappers
        // with type
        public void Fatal(Type type, string message)
        {
            _logger.WithContext(type, _contextTag).Fatal(message);
        }

        public void Fatal(Type type, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Fatal(messageTemplate, propertyValues);
        }

        public void Fatal(Type type, Exception ex, string messageTemplate)
        {
            _logger.WithContext(type, _contextTag).Fatal(ex, messageTemplate);
        }

        public void Fatal(Type type, Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext(type, _contextTag).Fatal(ex, messageTemplate, propertyValues);
        }

        // with T
        public void Fatal<T>(string message)
        {
            _logger.WithContext<T>(_contextTag).Fatal(message);
        }

        public void Fatal<T>(string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Fatal(messageTemplate, propertyValues);
        }

        public void Fatal<T>(Exception ex, string messageTemplate)
        {
            _logger.WithContext<T>(_contextTag).Fatal(ex, messageTemplate);
        }

        public void Fatal<T>(Exception ex, string messageTemplate, params object[] propertyValues)
        {
            _logger.WithContext<T>(_contextTag).Fatal(ex, messageTemplate, propertyValues);
        }
        #endregion
    }
}
