using System.Collections.Generic;
using UnityEngine;

namespace LiteNinja.Analytics
{
  [CreateAssetMenu(fileName = "AnalyticsConfig", menuName = "LiteNinja/Analytics/Config", order = 0)]
  public class SOAnalyticsConfig : ScriptableObject, IAnalyticsConfig
  {
    [SerializeField]
    private AnalyticsProvider[] _providers;
    
    public IEnumerable<AnalyticsProvider> Providers => _providers;
  }
}