namespace SGSTestTask.Models;

public class JsonWrapper
{
    public string? Date { get; set; }
    public string? PreviousDate { get; set; }
    public string? PreviousURL { get; set; }
    public string? Timestamp { get; set; }
    public Dictionary<string, Cur>? Valute { get; set; }
}