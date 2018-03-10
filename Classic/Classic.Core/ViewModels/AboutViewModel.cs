using Classic.Core.Models.Movie;
using Classic.Core.Services.WebServices;
using Classic.Core.ViewModels.Base;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classic.Core.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IMvxNavigationService navigationService, IMovieWebService webMovieService) : base(navigationService, webMovieService)
        {

        }

        private IMvxCommand closeCommand;
        public IMvxCommand CloseCommand => closeCommand = closeCommand ?? new MvxCommand(DoCloseHandler);

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
            }
        }

        private void DoCloseHandler()
        {
            this.navigationService.Close(this);
        }

        public override void Prepare(object parameter)
        {
            if (parameter != null)
            {
                 this.SelectedMovie = (ResultMovie)Convert.ChangeType(parameter, typeof(ResultMovie));
                 this.Title = this.SelectedMovie?.Title;
            }
           
        }
    }
}
