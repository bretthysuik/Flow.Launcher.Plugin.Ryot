using System.Collections.Generic;

namespace Flow.Launcher.Plugin.Ryot;

internal static class RyotQuery
{
    internal const string MediaListQuery =
        """
        query MediaList($input: MediaListInput) {
          mediaList(input: $input) {
            details {
              total
              nextPage
            }
            items {
              averageRating
              data {
                identifier
                title
                image
                publishYear
              }
            }
          }
        }
        """;

    internal class MediaListResponseRoot
    {
        public MediaListResponse MediaList { get; set; }
    }

    internal class MediaListResponse
    {
        public IList<MediaListItem> Items { get; set; }
    }

    internal class MediaListItem
    {
        public string AverageRating { get; set; }
        public MediaListItemData Data { get; set; }
    }

    internal class MediaListItemData
    {
        public string Identifier { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int? PublishYear { get; set; }
    }
}
