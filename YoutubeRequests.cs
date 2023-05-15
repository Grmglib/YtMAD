using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Search;

namespace YtMAD
{
    public class YoutubeRequests
    {
        public static async Task<List<VideoDTO>> VideoSearch(string query)
        {
            var youtube = new YoutubeClient();
            List<VideoDTO> videoList = new List<VideoDTO>();
            await foreach (var result in youtube.Search.GetResultsAsync(query))
            {
                if (videoList.Count < 20)
                {
                    // Use pattern matching to handle different results (videos, playlists, channels)
                    switch (result)
                    {
                        case VideoSearchResult video:
                            {
                                Thumbnail thumbnail = null;
                                int area = 0;
                                var thumbList = video.Thumbnails;
                                foreach (var thumb in thumbList)
                                {
                                    if (thumb.Resolution.Area > area)
                                    {
                                        area = thumb.Resolution.Area;
                                        thumbnail = thumb;
                                    }
                                }
                                var videoUrl = video.Url;
                                var id = video.Id.Value;
                                var title = video.Title;
                                var author = video.Author.ChannelTitle;
                                var duration = video.Duration.Value;
                                var thumbUrl = thumbnail.Url;
                                var videodto = new VideoDTO()
                                {
                                    Title = title,
                                    Id = id,
                                    Author = author,
                                    Duration = duration,
                                    Thumbnail = thumbUrl,
                                    Url = videoUrl
                                };
                                videoList.Add(videodto);
                                break;
                            }
                        case PlaylistSearchResult playlist:
                            {
                                //var id = playlist.Id;
                                //var title = playlist.Title;
                                //videoList.Add(title);
                                break;
                            }
                        case ChannelSearchResult channel:
                            {
                                //var id = channel.Id;
                                //var title = channel.Title;
                                //videoList.Add(title);
                                break;
                            }
                    }
                }
                else { break; }

            }

            return videoList;
        }

        public static async Task<VideoDTO> VideoInfo(string url)
        {
            int area = 0;
            Thumbnail thumbnail = null;
            var youtube = new YoutubeClient();

            // You can specify either the video URL or its ID
            var videoUrl = url;
            var video = await youtube.Videos.GetAsync(videoUrl);
            var thumbList = video.Thumbnails;
            foreach (var thumb in thumbList)
            {
                if (thumb.Resolution.Area > area)
                {
                    area = thumb.Resolution.Area;
                    thumbnail = thumb;
                }
            }
            var id = video.Id.Value;
            var date = video.UploadDate;
            var description = video.Description;
            var title = video.Title;
            var author = video.Author.ChannelTitle;
            var duration = video.Duration.Value;
            var thumbUrl = thumbnail.Url;
            var videodto = new VideoDTO()
            {
                Title = title,
                Id = id,
                UploadDate = date,
                Description = description,
                Author = author,
                Duration = duration,
                Thumbnail = thumbUrl,
                Url = videoUrl
            };

            return videodto;
        }
    }
}