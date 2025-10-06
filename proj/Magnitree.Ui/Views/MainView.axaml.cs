using Avalonia.Controls;
using Magnitree.Ui.Views.FileCard;

namespace Magnitree.Ui.Views;

public partial class MainView : UserControl {
	public MainView() {
		Content = new ViewFileCard();
	}
}
