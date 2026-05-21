namespace Magnitree.Ui.Views;

using Avalonia.Controls;

public class WebViewDemoWindow : Window
{
	public WebViewDemoWindow()
	{
		Title = "Avalonia 12 WebView Demo";
		Width = 1100;
		Height = 760;

		Content = new NativeWebView {
			Source = new Uri("https://avaloniaui.net/")
		};
	}
}
