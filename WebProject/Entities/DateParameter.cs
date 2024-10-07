public class DateParameter
{
    public DateParameter(DateTime startDate, DateTime endDate)
    {
        this.StartDate=startDate;
        this.EndDate=endDate;
    }
    public DateTime StartDate{get; set;}
    public DateTime EndDate{get; set;}
}