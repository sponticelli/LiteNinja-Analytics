using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LiteNinja.Analytics
{
  public class AnalyticsManager
  {
    private List<AnalyticsProvider> _providers;

    public AnalyticsManager()
    {
      _providers = new List<AnalyticsProvider>();
    }
    
    public AnalyticsManager(IAnalyticsConfig config) : this()
    {
      foreach (var _providers in config.Providers)
      {
        AddProvider(_providers);
      }

    }

    
    public void AddProvider(AnalyticsProvider provider)
    {
      _providers.Add(provider);
    }
    
    public void Initialize()
    {
      foreach (var provider in _providers)
      {
        provider.Initialize();
      }
    }
    
    public void LogEvent(string eventName, Dictionary<string, object> parameters)
    {
      foreach (var provider in _providers)
      {
        provider.LogEvent(eventName, parameters);
      }
    }
  }
}