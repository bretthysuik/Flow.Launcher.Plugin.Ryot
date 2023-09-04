using System.Windows.Controls;

namespace Flow.Launcher.Plugin.Ryot;

public partial class SettingsControl : UserControl
{
    public SettingsControl(Settings settings)
    {
        InitializeComponent();
        DataContext = settings;
    }
}
