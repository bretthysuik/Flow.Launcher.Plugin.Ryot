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
        _ryot = new Ryot(_settings);

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public async Task<List<Result>> QueryAsync(Query query, CancellationToken token)
    {
        try
        {
            var results = await _ryot.QueryAsync(query, url => _context.API.OpenUrl(url), token);
            return results.ToList();
        }
        catch (Exception)
        {
            return new List<Result>();
        }
    }

    /// <inheritdoc/>
    public Control CreateSettingPanel() => new SettingsControl(_settings);
}
