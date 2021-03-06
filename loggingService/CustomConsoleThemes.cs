using System.Collections.Generic;
using Serilog.Sinks.SystemConsole.Themes;

namespace loggingService
{
    public static class CustomConsoleThemes
    {
        public static CustomConsoleTheme VisualStudioMacLight
        {
            get;
        } = new CustomConsoleTheme(new Dictionary<ConsoleThemeStyle, string>
        {
            [ConsoleThemeStyle.Text] = "\u001b[37m",
            [ConsoleThemeStyle.SecondaryText] = "\u001b[30m",
            [ConsoleThemeStyle.TertiaryText] = "\u001b[37m",
            [ConsoleThemeStyle.Invalid] = "\u001b[37m",
            [ConsoleThemeStyle.Null] = "\u001b[37m",
            [ConsoleThemeStyle.Name] = "\u001b[37m",
            [ConsoleThemeStyle.String] = "\u001b[37m",
            [ConsoleThemeStyle.Number] = "\u001b[37m",
            [ConsoleThemeStyle.Boolean] = "\u001b[37m",
            [ConsoleThemeStyle.Scalar] = " \u001b[37mm",
            [ConsoleThemeStyle.LevelVerbose] = "\u001b[37m",
            [ConsoleThemeStyle.LevelDebug] = "\u001b[44;1m\u001b[37;1m",
            [ConsoleThemeStyle.LevelInformation] = "\u001b[42;1m\u001b[37;1m",
            [ConsoleThemeStyle.LevelWarning] = "\u001b[43;1m\u001b[37;1m",
            [ConsoleThemeStyle.LevelError] = "\u001b[41;1m\u001b[37;1m",
            [ConsoleThemeStyle.LevelFatal] = "\u001b[46;1m\u001b[37;1m"
        });
    }
}