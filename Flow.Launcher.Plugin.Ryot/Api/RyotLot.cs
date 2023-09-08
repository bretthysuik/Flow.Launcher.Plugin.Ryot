using System.Collections.Generic;
using System.Linq;

namespace Flow.Launcher.Plugin.Ryot;

internal record RyotLot(string Lot, params string[] Aliases)
{
    internal bool Match(string lot) =>
        string.Equals(lot, Lot, System.StringComparison.InvariantCultureIgnoreCase) ||
        Aliases.Any(alias => string.Equals(alias, lot, System.StringComparison.InvariantCultureIgnoreCase));

    internal Result ToResult()
    {
        string aliases = "---";
        if (Aliases.Any())
        {
            aliases = string.Join(" | ", Aliases.Select(a => a.ToLower()));
        }

        return new()
        {
            Title = Lot.ToLower(),
            SubTitle = "Aliases: " + aliases,
            IcoPath = "Images\\ryot.png"
        };
    }
}

internal static class RyotLots
{
    internal static readonly RyotLot
        AudioBook = new("AUDIO_BOOK", "AUDIOBOOK", "ABOOK", "AB"),
        Anime = new("ANIME"),
        Book = new("BOOK", "B"),
        Podcast = new("PODCAST", "POD", "PC"),
        Manga = new("MANGA"),
        Movie = new("MOVIE", "MOV", "M"),
        Show = new("SHOW", "TVSHOW", "TV"),
        VideoGame = new("VIDEO_GAME", "VIDEOGAME", "VG");

    internal static readonly IReadOnlyCollection<RyotLot> Lots = new List<RyotLot>()
    {
        AudioBook, Anime, Book, Podcast, Manga, Movie, Show, VideoGame
    };
}
