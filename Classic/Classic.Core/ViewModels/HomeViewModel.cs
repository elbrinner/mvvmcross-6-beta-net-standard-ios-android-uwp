using Classic.Core.Models.Movie;
using Classic.Core.Services.WebServices;
using Classic.Core.ViewModels.Base;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace Classic.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(IMvxNavigationService navigationService, IMovieWebService webMovieService) : base(navigationService, webMovieService)
        {
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public async override void ViewAppeared()
        {
            this.SelectedMovie = null;
            if (this.Movies != null){
                return;
            }
            this.IsBusy = true;
            await Task.Delay(5000); //Simular espera del servicio
            var response = await this.webMovieService.Movie();
            this.IsBusy = false;
            if (response.IsCorrect)
            {
                Movies = response.Movies;
            }
            else
            {
                //mostrar el mensaje de error
            }

        }

        private List<ResultMovie> movies;
        public List<ResultMovie> Movies
        {
            get
            {
                return this.movies;
            }

            set
            {
                this.movies = value;
                this.RaisePropertyChanged();

            }
        }
        private ResultMovie selectedMovie;
        public ResultMovie SelectedMovie
        {
            get
            {
                return this.selectedMovie;
            }

            set
            {
                this.selectedMovie = value;
                this.RaisePropertyChanged();
                this.OpenModal(value);
            }
        }

        private IMvxCommand selectedCommand;
        public IMvxCommand SelectedCommand => selectedCommand = selectedCommand ?? new MvxCommand<ResultMovie>(OpenModal);

        private void OpenModal(ResultMovie value)
        {
            if (value != null)
            {
                object parameter = value;
                navigationService.Navigate<AboutViewModel, object>(parameter);
            }
           

        }
    }
}
