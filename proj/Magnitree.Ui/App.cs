namespace Magnitree.Ui;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Magnitree.Ui.ViewModels;
using Magnitree.Ui.Views;
using Avalonia.Themes.Fluent;
using Microsoft.Extensions.DependencyInjection;

public partial class App : Application {

	public static T GetSvc<T>()
		where T : class
	{
		System.Console.Write("GetSvc: "+typeof(T));//t
		return App.SvcProvider.GetRequiredService<T>();
	}

	public static IServiceProvider SvcProvider { get; private set; } = null!;
	public static void SetSvcProvider(IServiceProvider SvcProvider){
		App.SvcProvider = SvcProvider;
	}


	public override void Initialize() {
		Styles.Add(new FluentTheme());
#if DEBUG
		if(OperatingSystem.IsWindows()){
			this.AttachDevTools();
		}
#endif
	}

	public override void OnFrameworkInitializationCompleted() {
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
			// Avoid duplicate validations from both Avalonia and the CommunityToolkit.
			// More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
			DisableAvaloniaDataAnnotationValidation();
			desktop.MainWindow = new MainWindow {
				DataContext = new MainViewModel()
			};
		} else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform) {
			singleViewPlatform.MainView = new MainView {
				DataContext = new MainViewModel()
			};
		}

		base.OnFrameworkInitializationCompleted();
	}

	private void DisableAvaloniaDataAnnotationValidation() {
		// Get an array of plugins to remove
		var dataValidationPluginsToRemove =
			BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

		// remove each entry found
		foreach (var plugin in dataValidationPluginsToRemove) {
			BindingPlugins.DataValidators.Remove(plugin);
		}
	}
}
