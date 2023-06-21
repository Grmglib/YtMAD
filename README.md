# YtMAD
YtMad is an C# API for extracting video and audio from youtube links listing all possible resolutions and bitrates with multiple methods for transfering the requested data.

#Usage
* `Get /YtMad/VideoInfo`: Show information, thumbnail and all possible qualities and file format using the provided youtube link.
* `Get /YtMad/VideoSearch`: Returns the 20 first results using the provided query, equivalent to searching on youtube.
* `Get /YtMad/VideoDownload`: Using a url, valid container file format, path and resolution or bitrate, download the video on the provided path.
* `Get /Ytmad/StreamDownload`: Using a url, valid container file format, resolution or bitrate, returns the video as readable information, you can save the result as a valid file format to make it playable.

#Technologies Utilized
* .Net7.0
* YoutubeExplode Lib
