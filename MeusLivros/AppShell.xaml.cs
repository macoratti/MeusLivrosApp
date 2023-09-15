using MeusLivros.MVVM.Views;

namespace MeusLivros;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterForRoute<AddLivroPage>();
        RegisterForRoute<UpdateLivroPage>();
    }

    protected void RegisterForRoute<T>()
    {
        Routing.RegisterRoute(typeof(T).Name, typeof(T));
    }
}