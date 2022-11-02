using System.Collections.Generic;
using Firebase;
using Firebase.Analytics;
using UnityEngine;

namespace LiteNinja.Analytics
{

#if LITENINJA_FIREBASE_ANALYTICS
  [CreateAssetMenu(fileName = "FirebaseAnalyticsProvider", menuName = "LiteNinja/Analytics/Firebase Analytics Provider", order = 2)]
  public class FirebaseAnalyticsProvider : AnalyticsProvider
  {
    [SerializeField]
    private Color _debugColor = Color.white;
    private string _colorString;
    
    
    private FirebaseApp _firebaseApp;
    private bool _isInitialized;
    public override void Initialize()
    {
      _colorString = ColorUtility.ToHtmlStringRGB(_debugColor);
      // Initialize Firebase
      FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
      {
        var dependencyStatus = task.Result;
        if (dependencyStatus == DependencyStatus.Available)
        {
          _firebaseApp = FirebaseApp.DefaultInstance;
          _isInitialized = true;
          Debug.Log($"<color=#{_colorString}>Firebase Analytics Initialized</color>");
        }
        else
        {
          Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
        }
      });
    }
  
    public override bool CanLog() => _isInitialized;
    protected override Dictionary<string, object> ConvertParameters(Dictionary<string, object> parameters) => parameters;
    protected override string ConvertEventName(string eventName) => eventName;
  
    protected override void SendAnalytics(string eventName, Dictionary<string, object> parameters)
    {
      var firebaseParameters = new List<Parameter>();
      if (parameters != null)
      {
          foreach (var parameter in parameters)
          {
            switch (parameter.Value)
            {
              case string value:
                firebaseParameters.Add(new Parameter(parameter.Key, value));
                break;
              case long value:
                firebaseParameters.Add(new Parameter(parameter.Key, value));
                break;
              case int value:
                firebaseParameters.Add(new Parameter(parameter.Key, value));
                break;
              case double value:
                firebaseParameters.Add(new Parameter(parameter.Key, value));
                break;
              case float value:
                firebaseParameters.Add(new Parameter(parameter.Key, value));
                break;
            }
          }
      }
      FirebaseAnalytics.LogEvent(eventName, firebaseParameters.ToArray());
    }
  }
#endif
}