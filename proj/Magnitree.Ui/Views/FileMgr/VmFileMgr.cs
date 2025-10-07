namespace Magnitree.Ui.Views.FileMgr;
using System.Collections.ObjectModel;
using Magnitree.Core.FileMgr_;
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

	IFileMgr? FileMgr;

	public VmFileMgr(
		IFileMgr? FileMgr
	){
		this.FileMgr = FileMgr;
	}

	CancellationTokenSource Cts = new();

	protected nil FromPath(str Path){
		FromPathAsy(Path).ContinueWith(t=>{
			if(t.IsFaulted){
				System.Console.WriteLine(t.Exception);//t
			}
		});
		return NIL;
	}

	protected async Task<nil> FromPathAsy(str Path){
		if(FileMgr == null){
			return NIL;
		}
		FullPath = Path;
		var Ct = Cts.Token;
		var AsyE = FileMgr.LsPathInfoAsyE(Path, Ct);
		await foreach(var x in AsyE){
			var o = VmFileCard.Mk();
			o.FromPathInfo(x);
			VmFileCards.Add(o);
		}
		return NIL;
	}

	public nil GoToFullPath(str FullPath){
		this.FullPath = FullPath;
		return GoToCurFullPath();
	}

	public nil GoToCurFullPath(){
		//VmFileCards.Clear();
		VmFileCards = new();
		return FromPath(FullPath);
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
