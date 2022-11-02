using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    
    /// <summary>
    /// Check if all the providers are ready to send events
    /// </summary>
    /// <returns>true if all the provider are initialized</returns>
    public bool CanLog()
    {
      return _providers.All(provider => provider.CanLog());
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