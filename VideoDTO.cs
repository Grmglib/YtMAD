using System;
using System.Globalization;

public class VideoDTO
{
    public string Title { get; set; }
    public string Id { get; set; }
    public DateTimeOffset UploadDate { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public TimeSpan Duration { get; set; }
    public string Thumbnail { get; set; }
    public string Url { get; set; }
}
