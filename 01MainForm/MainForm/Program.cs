using System;
using System.Threading;
using System.Windows.Forms;
using Logger;
using UniVision.Forms;

namespace UniVision;

static class Program
{
    [STAThread]
    private static void Main()
    {
        // 设置应用程序异常处理
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        // 处理UI线程异常
        Application.ThreadException += Application_ThreadException;
        // 处理非UI线程异常
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;


        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        LogHelper.Info("程序启动");
        Application.Run(new Frm_Main());
    }

    /// <summary>
    /// 处理UI线程异常
    /// </summary>
    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        try
        {
            // 记录异常日志
            LogHelper.Error(e.Exception, "UI线程异常");

            // 向用户显示友好错误消息
            MessageBox.Show(
                "程序遇到了一个问题，已记录异常信息。\n\n" +
                "错误信息: " + e.Exception.Message,
                "应用程序错误",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            try
            {
                LogHelper.Fatal(ex, "处理UI线程异常时发生错误");
            }
            catch
            {
                // 如果日志记录也失败，使用消息框作为最后手段
                MessageBox.Show("无法记录异常信息: " + ex.Message, "严重错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// 处理非UI线程异常
    /// </summary>
    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        try
        {
            Exception ex = e.ExceptionObject as Exception;

            // 记录异常日志
            if (ex != null)
            {
                LogHelper.Fatal(ex, "非UI线程异常");
            }
            else
            {
                LogHelper.Fatal(new Exception("未知异常类型"),
                    "发生未知类型的非UI线程异常: " + e.ExceptionObject.ToString());
            }

            // 如果异常导致应用程序终止，记录这一信息
            if (e.IsTerminating)
            {
                LogHelper.Fatal(new Exception("应用程序即将终止"), "由于未处理的异常，应用程序即将关闭");

                MessageBox.Show(
                    "程序遇到了一个严重问题，必须关闭。\n请联系技术支持获取帮助。",
                    "应用程序即将关闭",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            try
            {
                LogHelper.Fatal(ex, "处理非UI线程异常时发生错误");
            }
            catch
            {
                // 如果日志记录也失败，使用消息框作为最后手段
                MessageBox.Show("无法记录异常信息: " + ex.Message, "严重错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
