namespace Magnitree.Ui.Views.FileMgr;

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Media;
using Magnitree.Ui.Infra;
using Magnitree.Ui.Views.FileCard;
using Tsinswreng.AvlnTools.Dsl;
using Tsinswreng.AvlnTools.Tools;
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

	AutoGrid Root = new(IsRow:true);
	protected nil Render(){
		this.ContentInit(Root.Grid, o=>{
			o.RowDefinitions.AddRange([
				RowDef(1, GUT.Auto),
				RowDef(1, GUT.Star),
			]);
		});
		var PathGrid = new AutoGrid(IsRow:false);
		Root.AddInit(PathGrid.Grid, o=>{
			o.ColumnDefinitions.AddRange([
				ColDef(1, GUT.Star),
				ColDef(1, GUT.Auto),
			]);
			PathGrid.AddInit(_TextBox(), o=>{
				o.Bind(
					TextBox.TextProperty
					,CBE.Mk<Ctx>(x=>x.FullPath)
				);
			})
			.AddInit(_Button(), o=>{
				o.Content = "➡";
				o.Click+=(s,e)=>{
					Ctx?.GoToCurFullPath();
				};
			})
			;

		});

		Root.AddInit(_ScrollViewer(), o=>{
			o.Content = _FileCards();
		});
		return NIL;
	}

	Control _FileCards(){
		var R = new ItemsControl();
		R.Bind(
			ItemsControl.ItemsSourceProperty
			,CBE.Mk<Ctx>(x=>x.VmFileCards)
		);
		R.ItemsPanel = new FuncTemplate<Panel?>(()=>{
			return new VirtualizingStackPanel();
		});
		R.ItemTemplate = new FuncDataTemplate<VmFileCard>((vm,b)=>{
			var R = new Button();
			R.Styles.Add(new Style().NoCornerRadius().NoMargin().NoPadding());
			R.Styles.Add(new Style().Set(
				Button.BackgroundProperty
				,Brushes.Transparent
			).Set(
				HorizontalAlignmentProperty
				,HAlign.Stretch
			));

			R.ContentInit(new ViewFileCard(), o=>{
				o.DataContext = vm;
			});
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
