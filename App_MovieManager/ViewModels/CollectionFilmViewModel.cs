using AdoToolbox;
using App_MovieManager.Models;
using App_MovieManager.Tools;
using App_MovieManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_MovieManager.ViewModels
{
    public class CollectionFilmViewModel : ViewModelBase
    {
        public CollectionFilmViewModel()
        {
            _collectionFilms = new ObservableCollection<FilmCollection>(_db.GetCollectionList());
        }

        DBservices _db = new DBservices();

        private int _iduser;
        private int _idfilm;
        private int _favori;
        private int _corbeille;
        private ObservableCollection<FilmCollection> _collectionFilms;
        private CommandBase _storecollectionCommand;
        private CollectionFilmViewModel _selectedItem;

        public CollectionFilmViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
                SelectedItem.ShowCollectionMovie();
            }
        }
        public int IdUser
        {
            get { return _iduser; }
            set
            {
                if (_iduser != value)
                {
                    _iduser = value;
                    RaisePropertyChanged(nameof(IdUser));
                }
            }
        }

        public int IdFilm
        {
            get { return _idfilm; }
            set
            {
                if (_idfilm != value)
                {
                    _idfilm = value;
                    RaisePropertyChanged(nameof(IdFilm));
                }
            }
        }

        public int Favori
        {
            get { return _favori; }
            set
            {
                if (_favori != value)
                {
                    _favori = value;
                    RaisePropertyChanged(nameof(Favori));
                }
            }
        }


        public int Corbeille
        {
            get { return _corbeille; }
            set
            {
                if (_corbeille != value)
                {
                    _corbeille = value;
                    RaisePropertyChanged(nameof(Corbeille));
                }
            }
        }

        public ObservableCollection<FilmCollection> CollectionFilms
        {
            get { return _collectionFilms; }
            set { _collectionFilms = value; }
        }

        public CommandBase StoreCollectionCommand
        {
            get { return _storecollectionCommand ?? (_storecollectionCommand = new CommandBase(SaveCollection)); }
        }

        public void SaveCollection()
        {
            DBservices _dbcoll = new DBservices();
            _dbcoll.CreateCollection(IdUser,Favori,Corbeille);
        }

        public void ShowCollectionMovie()
        {
            CollectionFilmWindow dw = new CollectionFilmWindow();
            dw.DataContext = this;
            dw.Show();
        }
    }
}
