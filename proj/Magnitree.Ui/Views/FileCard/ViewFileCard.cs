namespace Magnitree.Ui.Views.FileCard;

using Avalonia.Controls;
using Avalonia.Data;
using Magnitree.Ui.Infra;
using Ctx = VmFileCard;
public partial class ViewFileCard
	:AppViewBase
{

	public Ctx? Ctx{
		get{return DataContext as Ctx;}
		set{DataContext = value;}
	}


	public ViewFileCard(){
		Ctx = Ctx.Mk();
		//Ctx = Ctx.Samples[0];
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
		Root.ColumnDefinitions.AddRange([
			new ColDef(1, GUT.Star),
			new ColDef(14, GUT.Star),
		]);

		var icon = new TextBlock();
		icon.Bind(TextBlock.TextProperty, new Binding(nameof(Ctx.Icon)));
		Grid.SetColumn(icon, 0);

		var name = new TextBlock();
		name.Bind(TextBlock.TextProperty, new Binding(nameof(Ctx.Name)));
		Grid.SetColumn(name, 1);

		Root.Children.Add(icon);
		Root.Children.Add(name);
		Content = Root;
		return NIL;
	}


}


