namespace Magnitree.Ui.Views.FileMgr;

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Styling;
using Magnitree.Ui.Infra;
using Magnitree.Ui.Views.FileCard;
using Ctx = VmFileMgr;
public partial class ViewFileMgr
	:AppViewBase
{

	public Ctx? Ctx{
		get{return DataContext as Ctx;}
		set{DataContext = value;}
	}

	public ViewFileMgr(){
		//Ctx = Ctx.Mk();
		Ctx = App.GetSvc<Ctx>();
		Style();
		Render();
	}

	public partial class Cls_{

	}
	public Cls_ Cls{get;set;} = new Cls_();

	protected nil Style(){
		return NIL;
	}

	Grid Root = new();
	protected nil Render(){
		Root.RowDefinitions.AddRange([
			new RowDef(1, GUT.Auto),
			new RowDef(1, GUT.Star),
		]);

		var pathGrid = new Grid();
		pathGrid.ColumnDefinitions.AddRange([
			new ColDef(1, GUT.Star),
			new ColDef(1, GUT.Auto),
		]);

		var pathBox = new TextBox();
		pathBox.Bind(TextBox.TextProperty, new Binding(nameof(Ctx.FullPath)));
		Grid.SetColumn(pathBox, 0);

		var goButton = new Button { Content = "➡" };
		goButton.Click += (s,e)=>{
			Ctx?.GoToCurFullPath();
		};
		Grid.SetColumn(goButton, 1);

		pathGrid.Children.Add(pathBox);
		pathGrid.Children.Add(goButton);
		Grid.SetRow(pathGrid, 0);

		var scroll = new ScrollViewer { Content = _FileCards() };
		Grid.SetRow(scroll, 1);

		Root.Children.Add(pathGrid);
		Root.Children.Add(scroll);
		Content = Root;
		return NIL;
	}

	Control _FileCards(){
		var R = new ItemsControl();
		R.Bind(
			ItemsControl.ItemsSourceProperty
			,new Binding(nameof(Ctx.VmFileCards))
		);
		R.ItemsPanel = new FuncTemplate<Panel?>(()=>{
			return new VirtualizingStackPanel();
		});
		R.ItemTemplate = new FuncDataTemplate<VmFileCard>((vm,b)=>{
			var R = new Button();
			R.Background = Brushes.Transparent;
			R.HorizontalAlignment = HAlign.Stretch;
			R.Padding = new Avalonia.Thickness(0);
			R.Margin = new Avalonia.Thickness(0);
			R.Content = new ViewFileCard {
				DataContext = vm
			};
			R.Click += (s,e)=>{
				if(vm.Bo?.AbsPosixPath is not null){
					Ctx?.GoToFullPath(vm.Bo.AbsPosixPath);
				}
			};
			return R;
		});
		return R;
	}


}
