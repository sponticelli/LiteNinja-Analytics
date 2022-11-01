using System.Collections.Generic;

namespace LiteNinja.Analytics
{
  public interface IAnalyticsConfig 
  {
    IEnumerable<AnalyticsProvider> Providers { get; }
  }
}