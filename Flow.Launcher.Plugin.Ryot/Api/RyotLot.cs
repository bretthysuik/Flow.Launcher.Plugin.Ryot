namespace Flow.Launcher.Plugin.Ryot;

internal static class RyotLot
{
    private const string AudioBook = "AUDIO_BOOK";
    private const string Anime = "ANIME";
    private const string Book = "BOOK";
    private const string Podcast = "PODCAST";
    private const string Manga = "MANGA";
    private const string Movie = "MOVIE";
    private const string Show = "SHOW";
    private const string VideoGame = "VIDEO_GAME";

    internal static (bool, string) Match(string lot) =>
        lot.ToUpperInvariant() switch
        {
            AudioBook or "AUDIOBOOK" or "ABOOK" or "AB" => (true, AudioBook),
            Anime or "A" => (true, Anime),
            Book or "B" => (true, Book),
            Podcast or "POD" or "PC" => (true, Podcast),
            Manga => (true, Manga),
            Movie or "MOV" or "M" => (true, Movie),
            Show or "TVSHOW" or "TV" => (true, Show),
            VideoGame or "VIDEOGAME" or "VG" => (true, VideoGame),
            _ => (false, "")
        };
}
