using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace LiteNinja.Analytics
{
  /// <summary>
  /// A simple analytics provider that logs events to the console.
  /// </summary>
  [CreateAssetMenu(fileName = "ConsoleAnalyticsProvider", menuName = "LiteNinja/Analytics/Console Analytics Provider", order = 1)]
  public class ConsoleAnalyticsProvider : AnalyticsProvider
  {
    [SerializeField]
    private Color _debugColor = Color.white;
    private string _colorString;
    public override void Initialize()
    {
      _colorString = ColorUtility.ToHtmlStringRGB(_debugColor);
      Debug.Log($"<color=#{_colorString}>ConsoleAnalyticsProvider initialized");
    }

    public override bool CanLog() => true;
    protected override Dictionary<string, object> ConvertParameters(Dictionary<string, object> parameters) => parameters;
    protected override string ConvertEventName(string eventName) => eventName;


    protected override void SendAnalytics(string eventName, Dictionary<string, object> parameters)
    {
      var sb = new StringBuilder();
      sb.Append("<color=#");
      sb.Append(_colorString);
      sb.Append(">Event: ").Append(eventName).Append("</color>").AppendLine();
      if (parameters != null)
      {
          foreach (var parameter in parameters)
          {
            sb.Append("\t");
            sb.Append(parameter.Key);
            sb.Append(": ");
            sb.Append(parameter.Value);
            sb.AppendLine();
          }
      }
      Debug.Log(sb.ToString());
    }
  }
}