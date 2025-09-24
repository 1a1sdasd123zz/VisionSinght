#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Logger;

public static class LogHelper
{
    public static event Action? LogChanged;

    private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();
    private static readonly List<LogEntry> _cache = new();
    private const int _maxCount = 2000;


    internal static IReadOnlyList<LogEntry> Logs => _cache;

    /// <summary>
    /// 记录信息日志
    /// </summary>
    /// <param name="content">日志消息</param>
    public static void Info(string content)
    {
        logger.Info(content);
        Cache(LogLevel.Info, content);
    }

    /// <summary>
    /// 记录警告日志
    /// </summary>
    /// <param name="content">警告消息</param>
    public static void Warn(string content)
    {
        logger.Warn(content);
        Cache(LogLevel.Warn, content);
    }

    /// <summary>
    /// 记录错误日志
    /// </summary>
    /// <param name="ex">异常对象</param>
    /// <param name="content">附加消息</param>
    public static void Error(Exception ex, string content = "")
    {
        if (string.IsNullOrEmpty(content))
        {
            logger.Error(ex);
        }
        else
        {
            logger.Error(ex, content);
        }
        Cache(LogLevel.Error, $"[{content}],{ex}");
    }

    /// <summary>
    /// 记录致命错误日志
    /// </summary>
    /// <param name="ex">异常对象</param>
    /// <param name="content">附加消息</param>
    public static void Fatal(Exception ex, string content = "")
    {
        if (string.IsNullOrEmpty(content))
        {
            logger.Fatal(ex);
        }
        else
        {
            logger.Fatal(ex, content);
        }
    }

    private static void Cache(LogLevel level, string content)
    {
        
        var entry = new LogEntry
        {
            Time = DateTime.Now,
            Level = level,
            Content = content
        };

        // 内存缓存
        if (_cache.Count >= _maxCount)
            _cache.RemoveAt(0);
        _cache.Add(entry);

        LogChanged?.Invoke();
    }

    internal static List<LogEntry> GetLogsByType(LogLevel? level = null)
    {
        if (level == null)
            return _cache.ToList();
        return _cache.Where(l => l.Level == level).ToList();
    }
}

