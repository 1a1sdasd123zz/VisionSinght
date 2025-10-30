namespace VisionCore.ToolBase
{
    /// <summary>
    /// 可持久化工具：提供配置导出/导入。实现后框架会自动写入 ToolRef.SettingsJson 并在加载时恢复。
    /// </summary>
    public interface IPersistableTool
    {
        string ExportSettings();
        void ImportSettings(string data);
    }
}
