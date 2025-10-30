using System;
using System.Diagnostics;

namespace VisionCore.ToolBase
{
    /// <summary>
    /// 抽象工具基类：封装 Run 模板（计时、异常捕获），减少插件样板代码。
    /// 插件只需实现 OnRun() 与可选 OpenForm()/持久化接口。
    /// </summary>
    public abstract class ToolBase : ITool
    {
        public string Name { get; set; }
        public bool Enable { get; set; } = true;

        /// <summary>最近一次运行耗时(ms)</summary>
        public long LastElapsedMs { get; private set; }
        /// <summary>最近一次运行是否成功</summary>
        public bool LastSuccess { get; private set; }
        /// <summary>最近一次错误消息</summary>
        public string LastError { get; private set; }

        /// <summary>
        /// 模板方法：外部统一调用此方法；内部调用子类 OnRun 实现具体逻辑。
        /// </summary>
        public void Run(out bool success, out string message)
        {
            success = false; message = null; LastError = null;
            if (!Enable) { message = "Disabled"; return; }
            var sw = Stopwatch.StartNew();
            try
            {
                success = OnRun(out message);
                LastSuccess = success;
            }
            catch (Exception ex)
            {
                LastSuccess = false;
                LastError = ex.Message;
                message = ex.Message;
            }
            finally
            {
                sw.Stop();
                LastElapsedMs = sw.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// 子类实现核心业务；返回 true/false 和文本信息。
        /// </summary>
        protected abstract bool OnRun(out string message);

        /// <summary>
        /// 可覆盖：打开配置界面。
        /// </summary>
        public virtual void OpenForm() { }
    }
}
