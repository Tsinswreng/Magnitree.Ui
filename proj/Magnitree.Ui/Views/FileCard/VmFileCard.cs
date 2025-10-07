namespace Magnitree.Ui.Views.FileCard;
using System.Collections.ObjectModel;
using Magnitree.Core.Path;
using Magnitree.Ui.Infra;


using Ctx = VmFileCard;
public partial class VmFileCard: ViewModelBase{
	//蔿從構造函數依賴注入、故以靜態工廠代無參構造器



	protected VmFileCard(){}
	public static Ctx Mk(){
		return new Ctx();
	}

	public static ObservableCollection<Ctx> Samples = [];
	static VmFileCard(){

		#if DEBUG
		{
			var o = new Ctx();
			Samples.Add(o);
			o.Name = "File";
			o.PathType = EPathType.File;
		}
		{
			var o = new Ctx();
			Samples.Add(o);
			o.Name = "Dir";
			o.PathType = EPathType.Dir;
		}
		#endif
	}

	public nil FromPathInfo(IPathInfo PathInfo){
		this.Bo = PathInfo;
		Name = Bo.GetLastSeg();
		PathType = PathInfo.Type;
		return NIL;
	}

	protected str _Name = "";
	public str Name{
		get{return _Name;}
		set{SetProperty(ref _Name, value);}
	}

	protected EPathType _PathType = EPathType.File;
	public EPathType PathType{
		get{return _PathType;}
		set{SetProperty(ref _PathType, value);}
	}

	protected IPathInfo? _Bo;
	public IPathInfo? Bo{
		get{return _Bo;}
		set{SetProperty(ref _Bo, value);}
	}


}
