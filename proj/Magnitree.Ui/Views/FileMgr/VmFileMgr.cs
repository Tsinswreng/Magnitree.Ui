namespace Magnitree.Ui.Views.FileMgr;
using System.Collections.ObjectModel;
using Magnitree.Core.Path;
using Magnitree.Ui.Infra;
using Magnitree.Ui.Views.FileCard;
using Ctx = VmFileMgr;
public partial class VmFileMgr: ViewModelBase{
	//蔿從構造函數依賴注入、故以靜態工廠代無參構造器
	protected VmFileMgr(){}
	public static Ctx Mk(){
		return new Ctx();
	}

	public static ObservableCollection<Ctx> Samples = [];
	static VmFileMgr(){
		#if DEBUG
		{
			var o = new Ctx();
			Samples.Add(o);
		}
		#endif
	}


	protected str _FullPath = "";
	public str FullPath{
		get{return _FullPath;}
		set{SetProperty(ref _FullPath, value);}
	}

	protected ObservableCollection<VmFileCard> _VmFileCards = new ();
	public ObservableCollection<VmFileCard> VmFileCards{
		get{return _VmFileCards;}
		set{SetProperty(ref _VmFileCards, value);}
	}



}
