using Classic.Core.ViewModels;
using Classic.IOS.DataSource;
using Classic.IOS.Views.Cell;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platform.Ios.Presenters.Attributes;
using MvvmCross.Platform.Ios.Views;
using UIKit;

namespace Classic.IOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class HomeView : MvxViewController
    {

        private SimpleDynamicTableViewSource dataSource;
        private bool isBusy;


        /// <summary>
        /// Indicado de inicio y fin de las llamadas al servicio.
        /// Ponemos a true antes de llamar un servicio y a false despúes de la llamada
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
                if (this.isBusy)
                {
                    this.myBackgroundView.Hidden = false;
                    this.myActivityIndicator.Hidden = false;
                    this.myActivityIndicator.StartAnimating();
                }
                else
                {
                    this.myBackgroundView.Hidden = true;
                    this.myActivityIndicator.Hidden = true;
                    this.myActivityIndicator.StopAnimating();
                }
            }
        }

       
        public HomeView() : base("HomeView", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "Movies";
            this.SetDataSources();
            this.SetBindings();

            // Perform any additional setup after loading the view, typically from a nib.
        }



        private void SetDataSources()
        {
            this.dataSource = new SimpleDynamicTableViewSource(this.myTableView,typeof(CustomCell));
        }


        private void SetBindings()
        {
            var set = this.CreateBindingSet<HomeView, HomeViewModel>();

            set.Bind(this.dataSource)
               .For(s => s.SelectedItem)
               .To(vm => vm.SelectedMovie);

            set.Bind(this.dataSource)
                .For(s => s.ItemsSource)
               .To(vm => vm.Movies);

            set.Bind(this)
                .For(s => s.IsBusy)
               .To(vm => vm.IsBusy);
            
            set.Apply();
        }





    }
}