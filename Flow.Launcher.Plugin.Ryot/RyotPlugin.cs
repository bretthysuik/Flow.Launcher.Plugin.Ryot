using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flow.Launcher.Plugin.Ryot;

public class RyotPlugin : IAsyncPlugin, ISettingProvider
{
    private PluginInitContext _context;
    private Settings _settings;
    private Ryot _ryot;

    /// <inheritdoc/>
    public Task InitAsync(PluginInitContext context)
    {
        _context = context;
        _settings = _context.API.LoadSettingJsonStorage<Settings>();

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public async Task<List<Result>> QueryAsync(Query query, CancellationToken token)
    {
        try
        {
            if (String.IsNullOrWhiteSpace(_settings.ApiToken))
                return ErrorResult("ERROR: API token must be assigned in plugin settings.");

            if (String.IsNullOrWhiteSpace(_settings.BaseUrl))
                return ErrorResult("ERROR: Base URL must be assigned in plugin settings.");

            _ryot ??= new Ryot(_settings);
            var results = await _ryot.QueryAsync(query, url => _context.API.OpenUrl(url), token);
            return results.ToList();
        }
        catch (Exception ex)
        {
            _context.API.LogException(nameof(RyotPlugin), $"Error querying ryot '{query.RawQuery}'", ex);
            return new List<Result>();
        }
    }

    private List<Result> ErrorResult(string title) => new()
    {
        new Result()
        {
            Title = title,
            SubTitle = "Go to plugin settings",
            Action = _ =>
            {
                _context.API.OpenSettingDialog();
                return true;
            }
        }
    };

    /// <inheritdoc/>
    public Control CreateSettingPanel() => new SettingsControl(_settings);
}
