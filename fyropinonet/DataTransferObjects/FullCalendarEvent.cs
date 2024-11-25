namespace fyropinonet.DataTransferObjects;

public class FullCalendarEvent
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool AllDay { get; set; }

    public FullCalendarEvent(int id, string title, DateTime start, DateTime end)
    {
        Id = id;
        Title = title;
        Start = start;
        End = end;
        
        // TODO
        Description = "bleble";
        AllDay = false;
    }
}