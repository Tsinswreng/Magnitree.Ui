using CommunityToolkit.Mvvm.ComponentModel;
using Magnitree.Ui.Infra;

namespace Magnitree.Ui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
