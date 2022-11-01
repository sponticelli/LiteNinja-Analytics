using System;
using System.Collections.Generic;
using UnityEngine;

namespace LiteNinja.Analytics
{
  /// <summary>
  /// The base class to send events
  /// Implement this class to send events to your analytics service
  /// </summary>
  [Serializable]
  public abstract class AnalyticsProvider : ScriptableObject
  {
    
    /// <summary>
    /// If it is true, it will send events to the analytics service
    /// </summary>
    [SerializeField]
    private bool _active = true;
    
    public bool Active
    {
      get => _active;
      set => _active = value;
    }
    
    /// <summary>
    /// Sets up the necessary data/connections for this analytics provider.
    /// Implement your setup behaviour here.
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Returns whether the provider can currently send events or not.
    /// </summary>
    /// <returns>Whether events can be logged.</returns>
    /// <remarks>
    /// For example, if the provider is not initialized, it will return false.
    /// Or you can decide to not send events if you are in the editor.
    /// </remarks>
    public abstract bool CanLog();
    
    
    /// <summary>
    /// Prepare the parameters and send the event to the analytics service
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="parameters"></param>
    public void LogEvent(string eventName, Dictionary<string, object> parameters)
    {
      if (!Active || !CanLog())
        return;

      SendAnalytics(ConvertEventName(eventName), ConvertParameters(parameters));
    }
    
    /// <summary>
    /// Converts the data from the event into accepted data types for the analytics.
    /// Implement your own conversion behaviour here.
    /// </summary>
    /// <param name="parameters">Parameters from the logged event.</param>
    /// <returns>Converted parameters.</returns>
    protected abstract Dictionary<string, object> ConvertParameters(Dictionary<string, object> parameters);
    
    /// <summary>
    /// Converts the event name into accepted name for the analytics.
    /// </summary>
    protected abstract string ConvertEventName(string eventName);
    
    
    /// <summary>
    /// Logs an event to the analytics platform.
    /// Implement your analytics sending behaviour here.
    /// </summary>
    /// <param name="eventName">Name of the event.</param>
    /// <param name="parameters">Converted parameters.</param>    
    protected abstract void SendAnalytics(string eventName, Dictionary<string, object> parameters);
    
  }
}