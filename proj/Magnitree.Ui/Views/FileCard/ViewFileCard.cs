namespace Magnitree.Ui.Views.FileCard;

using Avalonia.Controls;
using Magnitree.Ui.Infra;
using Tsinswreng.AvlnTools.Dsl;
using Tsinswreng.AvlnTools.Tools;
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
	AutoGrid Root = new(IsRow: false);
	protected nil Render(){
		this.ContentInit(Root.Grid, o=>{
			o.ColumnDefinitions.AddRange([
				ColDef(1, GUT.Star),
				ColDef(14, GUT.Star),
			]);
		});
		Root.AddInit(_TextBlock(), o=>{
			o.Bind(
				TextBlock.TextProperty,
				CBE.Mk<Ctx>(x=>x.Icon)
			);

		});
		Root.AddInit(_TextBlock(), o=>{
			o.Bind(
				TextBlock.TextProperty,
				CBE.Mk<Ctx>(x=>x.Name)
			);
		});
		return NIL;
	}


}
