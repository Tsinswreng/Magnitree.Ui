namespace Magnitree.Ui;

using Magnitree.Ui.Views.FileMgr;
using Microsoft.Extensions.DependencyInjection;

public static class DiUi{
	public static IServiceCollection SetupUi(
		this IServiceCollection z
	){
		z.AddTransient<VmFileMgr>();
		return z;
	}
}

