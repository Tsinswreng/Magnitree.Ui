using System;
using Avalonia;
using Microsoft.Extensions.DependencyInjection;

namespace Magnitree.Ui.Desktop;

sealed class Program {
	// Initialization code. Don't use any Avalonia, third-party APIs or any
	// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
	// yet and stuff might break.
	[STAThread]
	public static void Main(string[] args){
		var svc = new ServiceCollection();
		var svcProvider = svc.BuildServiceProvider();

		BuildAvaloniaApp()
		.AfterSetup(x=>{
			App.SetSvcProvider(svcProvider);
		})
		.StartWithClassicDesktopLifetime(args);

	}

	// Avalonia configuration, don't remove; also used by visual designer.
	public static AppBuilder BuildAvaloniaApp(){
		return AppBuilder.Configure<App>()
			.UsePlatformDetect()
			.WithInterFont()
			.LogToTrace();
	}

}
