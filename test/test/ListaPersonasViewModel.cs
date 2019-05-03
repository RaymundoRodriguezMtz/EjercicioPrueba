using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using test.Modelos;
using test.Vistas;
using Xamarin.Forms;

namespace test
{
    public class ListaPersonasViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Usuarios> _lista;
        private bool _refrescando;
        #endregion

        #region Propiedades
        public ObservableCollection<Usuarios> ListaUsuarios
        {
            get { return this._lista; }
            set { SetValue(ref this._lista, value); }
        }

        public bool Refrescando
        {
            get { return this._refrescando; }
            set { SetValue(ref this._refrescando, value); }
        }
        #endregion

        #region Contructor
        public ListaPersonasViewModel()
        {
            this.CargaListaAsync();
        }
        #endregion

        #region Comandos
        public ICommand EditarPageComando
        {
            get { return new RelayCommand(PaginaEditar); }
        }

        public ICommand GuardarComando
        {
            get { return new RelayCommand(Guardar); }
        }

        public ICommand RefreshComando
        {
            get { return new RelayCommand(CargaListaAsync); }
        }
        #endregion

        #region Metodos
        private async void PaginaEditar()
        {
            await PopupNavigation.Instance.PushAsync(new EditarPage());
        }

        private void CargaListaAsync()
        {
            this.Refrescando = true;

            this.ListaUsuarios = new ObservableCollection<Usuarios>
            { 
                new Usuarios(){ Nombre = "David" },
                new Usuarios(){ Nombre = "David" },
                new Usuarios(){ Nombre = "David" },
                new Usuarios(){ Nombre = "David" },
            };

            if(ListaUsuarios.Count == 0)
            {
                this.Refrescando = false;
                Application.Current.MainPage.DisplayAlert("","Lista Vacia","Aceptar");
            }

            this.Refrescando = false;

        }

        private void Guardar()
        {
        }
        #endregion
    }
}
