using System;

namespace Bridge.Pattern.NaiveApproach
{
    public abstract class TimeEntry
    {
        public string Description { get; }
        public string EmployeeName { get; set; }
        public TimeSpan TimeInterval { get; }

        protected TimeEntry(string description, TimeSpan timeInterval, string employeeName)
        {
            Description = description;
            TimeInterval = timeInterval;
            EmployeeName = employeeName;
        }

        public abstract string GetBossReportsRow();
    }

    public class DurationOnlyTimeEntry : TimeEntry
    {
        public DurationOnlyTimeEntry(string description, TimeSpan timeInterval, string employeeName) : base(description, timeInterval, employeeName) { }

        public override string GetBossReportsRow() => $"The employee {EmployeeName} was {Description} for duration {TimeInterval}";
    }

    public class ApprovedDurationOnlyTimeEntry : DurationOnlyTimeEntry
    {
        public string AuthorityName { get; }

        public ApprovedDurationOnlyTimeEntry(string description, TimeSpan timeInterval, string employeeName, string authorityName) : base(description, timeInterval, employeeName)
        {
            AuthorityName = authorityName;
        }

        public override string GetBossReportsRow() => $"{base.GetBossReportsRow()} and was approved by authority {AuthorityName}";

    }

    public class BannedDurationOnlyTimeEntry : DurationOnlyTimeEntry
    {
        public string AuthorityName { get; }

        public BannedDurationOnlyTimeEntry(string description, TimeSpan timeInterval, string employeeName, string authorityName) : base(description, timeInterval, employeeName)
        {
            AuthorityName = authorityName;
        }

        public override string GetBossReportsRow() => $"{base.GetBossReportsRow()} and was banned by authority {AuthorityName}";

    }

    public class SpecificRangeTimeEntry : TimeEntry
    {
        public DateTime StartTime { get; }
        public DateTime StopTime { get; }

        public SpecificRangeTimeEntry(string description, string employeeName, DateTime startTime, DateTime stopTime) : base(description, stopTime - startTime, employeeName)
        {
            StartTime = startTime;
            StopTime = stopTime;
        }

        public override string GetBossReportsRow() => $"The employee {EmployeeName} was {Description} from {StartTime} to {StopTime}";
    }

    public class ApprovedSpecificTimeRangeTimeEntry : SpecificRangeTimeEntry
    {
        public string AuthorityName { get; }

        public ApprovedSpecificTimeRangeTimeEntry(string description, string employeeName, DateTime startTime, DateTime stopTime, string authorityName)
            : base(description, employeeName, startTime, stopTime)
        {
            AuthorityName = authorityName;
        }

        public override string GetBossReportsRow() => $"{base.GetBossReportsRow()} and was approved by authority {AuthorityName}";
    }

    public class BannedSpecificTimeRangeTimeEntry : SpecificRangeTimeEntry
    {
        public string AuthorityName { get; }

        public BannedSpecificTimeRangeTimeEntry(string description, string employeeName, DateTime startTime, DateTime stopTime, string authorityName)
            : base(description, employeeName, startTime, stopTime)
        {
            AuthorityName = authorityName;
        }

        public override string GetBossReportsRow() => $"{base.GetBossReportsRow()} and was banned by authority {AuthorityName}";
    }
}