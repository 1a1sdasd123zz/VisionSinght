namespace VisionCore.ToolBase;

public interface ITool
{
    string Name { get; set; }
    bool Enable { get; set; }
    void Run(out bool result, out string message);

    void OpenForm();
}