using Classic.Core.Services.WebServices;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Classic.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel<object>
    {
        protected readonly IMvxNavigationService navigationService;
        protected readonly IMovieWebService webMovieService;
        protected bool isBusy;
        protected string title;
        public BaseViewModel(IMvxNavigationService navigationService, IMovieWebService webMovieService)
        {
            this.navigationService = navigationService;
            this.webMovieService = webMovieService;
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
                this.RaisePropertyChanged(() => this.IsBusy);
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.RaisePropertyChanged(() => this.Title);
            }
        }



        public override void Prepare(object parameter)
        {

        }

        public override Task Initialize()
        {
            //TODO: Lógica inicial aqui

            return base.Initialize();
        }


    }
}
