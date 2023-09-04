using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using static Flow.Launcher.Plugin.Ryot.RyotQuery;

namespace Flow.Launcher.Plugin.Ryot;

internal class Ryot
{
    private readonly GraphQLHttpClient _ryotApi;
    private readonly Settings _settings;

    internal Ryot(Settings settings)
    {
        _settings = settings;
        _ryotApi = new GraphQLHttpClient(_settings.BaseUrl + "/graphql", new SystemTextJsonSerializer());
        _ryotApi.HttpClient.DefaultRequestHeaders.Add("X-Auth-Token", _settings.ApiToken);
    }

    internal async Task<IEnumerable<Result>> QueryAsync(Query query, Action<string> openUrl, CancellationToken token)
    {
        var (canQuery, lot) = RyotLot.Match(query.FirstSearch);
        if (!canQuery)
            return Enumerable.Empty<Result>();

        var result = await _ryotApi.SendQueryAsync<MediaListResponseRoot>(CreateListRequest(query, lot), token);

        return result.Data.MediaList.Items.Select(item => ToResult(item, openUrl));
    }

    private static GraphQLRequest CreateListRequest(Query query, string lotQuery) => new()
    {
        Query = MediaListQuery,
        Variables = new { input = new { page = 1, lot = lotQuery, query = query.SecondToEndSearch } }
    };

    private Result ToResult(MediaListItem item, Action<string> openUrl) => new()
    {
        Title = GetTitle(item),
        SubTitle = GetRating(item),
        IcoPath = item.Data.Image,
        Action = _ =>
        {
            openUrl(_settings.BaseUrl + $"/media/item?id={item.Data.Identifier}");
            return true;
        }
    };

    private static string GetTitle(MediaListItem item)
    {
        string title = item.Data.Title;
        if (item.Data.PublishYear.HasValue)
            title += $" ({item.Data.PublishYear.Value})";

        return title;
    }

    private static string GetRating(MediaListItem item)
    {
        if (double.TryParse(item.AverageRating, out double rating))
        {
            return $"★ {Math.Round(rating, 1)}";
        }

        return String.Empty;
    }
}
