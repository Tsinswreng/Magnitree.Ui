using Avalonia.Controls;
using Magnitree.Ui.Views.FileCard;
using Magnitree.Ui.Views.FileMgr;

namespace Magnitree.Ui.Views;

public partial class MainView : UserControl {
	public MainView() {
		Content = new ViewFileMgr();
	}
}
