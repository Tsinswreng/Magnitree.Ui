namespace Magnitree.Ui.Views.FileMgr;

using Magnitree.Ui.Infra;
using Ctx = VmFileMgr;
public partial class ViewFileMgr
	:AppViewBase
{

	public Ctx? Ctx{
		get{return DataContext as Ctx;}
		set{DataContext = value;}
	}

	public ViewFileMgr(){
		Ctx = Ctx.Mk();
		Style();
		Render();
	}

	public partial class Cls_{

	}
	public Cls_ Cls{get;set;} = new Cls_();

	protected nil Style(){
		return NIL;
	}

	protected nil Render(){
		return NIL;
	}


}
