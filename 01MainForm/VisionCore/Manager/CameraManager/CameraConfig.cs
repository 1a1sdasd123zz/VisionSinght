using System.Xml.Serialization;
using VisionCore.PluginBase;

namespace VisionCore.Manager.CameraManager;

/// <summary>
/// 相机配置类
/// </summary>
[XmlRoot("CameraConfig")]
public class CameraConfig
{
    [XmlElement("SerialNumber")]
    public string SerialNumber { get; set; }

    [XmlElement("Manufacturer")]
    public string Manufacturer { get; set; }

    [XmlElement("Expain")]
    public string Expain { get; set; } = "";

    [XmlElement("PluginInfo")]
    public PluginInfo? PluginInfo { get; set; }

    public CameraConfig() { }

    public CameraConfig(string serialNumber, string manufacturer, PluginInfo? pluginInfo)
    {
        SerialNumber = serialNumber;
        Manufacturer = manufacturer;
        PluginInfo = pluginInfo;
    }
}
