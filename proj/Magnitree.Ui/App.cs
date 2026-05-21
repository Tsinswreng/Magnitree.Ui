namespace Magnitree.Ui;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.Linq;
using Avalonia.Markup.Xaml;
using Magnitree.Ui.ViewModels;
using Magnitree.Ui.Views;
using Avalonia.Themes.Fluent;
using Microsoft.Extensions.DependencyInjection;
using Avalonia.Controls;

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
			this.AttachDeveloperTools();
		}
#endif
	}

	public override void OnFrameworkInitializationCompleted() {
		if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
			desktop.MainWindow = MkWindow();
		} else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform) {
			singleViewPlatform.MainView = new MainView {
				DataContext = new MainViewModel()
			};
		}

		base.OnFrameworkInitializationCompleted();
	}

	Window MkWindow(){
		var R = new MainWindow {
			DataContext = new MainViewModel(),
			Width = 400,
			Height = 700
		};
		return R;
	}
}
