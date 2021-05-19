using Calculator.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorView2 : ContentPage
    {
        public CalculatorView2()
        {
            InitializeComponent();
            BindingContext = new CalculatorViewModel();
        }

    }
}