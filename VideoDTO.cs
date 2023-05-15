using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using YtMAD;

public class VideoDTO
{
    public string Title { get; set; }
    public string Id { get; set; }
    public string Author { get; set; }
    public TimeSpan Duration { get; set; }
    public string Thumbnail { get; set; }
    public string Url { get; set; }
    public List<StreamDTO> Quality { get; set; }
}

public class StreamDTO
{
    public string Type { get; set; }
    public double Size { get; set; }
    public double Bitrate { get; set; }
    public string Url { get; set; }
}
