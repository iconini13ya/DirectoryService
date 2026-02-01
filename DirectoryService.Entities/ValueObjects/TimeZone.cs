namespace DirectoryService.Entities.ValueObjects;

public record TimeZone
{
    public TimeZone(string timeZone)
    {
        try
        {
            TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            Value = timeZone;
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Wrong argument {timeZone}, that trigger exception {e}");
        }
    }

    public string Value { get; }
}
