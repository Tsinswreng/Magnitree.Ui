namespace Magnitree.Ui.Desktop;

using System;
using Avalonia;
using Magnitree.Core;
using Microsoft.Extensions.DependencyInjection;



sealed class Program {
	// Initialization code. Don't use any Avalonia, third-party APIs or any
	// SynchronizationContext-reliant code before AppMain is called: things aren't initialized
	// yet and stuff might break.
	[STAThread]
	public static void Main(string[] args){
		var svc = new ServiceCollection();
		svc
			.SetupCore()
			.SetupUi()
		;
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
