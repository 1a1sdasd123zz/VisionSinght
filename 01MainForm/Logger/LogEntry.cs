using System;
using NLog;

namespace Logger;

internal class LogEntry
{
    public DateTime Time { get; set; }
    public LogLevel Level { get; set; } 
    public string Content { get; set; }
}
