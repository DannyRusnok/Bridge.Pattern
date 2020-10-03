using System;

namespace Bridge.Pattern.BridgePatternApproach
{
    public abstract class TimeEntry
    {
        public string Description { get; }
        public string EmployeeName { get; set; }
        public Authority Authority { get; }
        public TimeSpan TimeInterval { get; }

        protected TimeEntry(string description, TimeSpan timeInterval, string employeeName, Authority authority)
        {
            Description = description;
            TimeInterval = timeInterval;
            EmployeeName = employeeName;
            Authority = authority;
        }

        public abstract string GetBossReportRowCore();
        public string GetBossReportRow() => $"{GetBossReportRowCore()} was {Authority.GetAuthorityVerb()} by authority {Authority.Name}";
    }

    public class DurationOnlyTimeEntry : TimeEntry
    {
        public DurationOnlyTimeEntry(string description, TimeSpan timeInterval, string employeeName, Authority authority) : base(description, timeInterval, employeeName, authority)
        {
        }

        public override string GetBossReportRowCore() => $"The employee {EmployeeName} was {Description} for duration {TimeInterval}";
    }



    public class SpecificRangeTimeEntry : TimeEntry
    {
        public DateTime StartTime { get; }
        public DateTime StopTime { get; }

        public SpecificRangeTimeEntry(string description, string employeeName,DateTime startTime, DateTime stopTime, Authority authority) : base(description, stopTime - startTime, employeeName, authority)
        {
            StartTime = startTime;
            StopTime = stopTime;
        }
        
        public override string GetBossReportRowCore() => $"The employee {EmployeeName} was {Description} from {StartTime} to {StopTime}";
    }
}