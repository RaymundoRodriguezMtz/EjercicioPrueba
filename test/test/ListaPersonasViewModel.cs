namespace test
{
    using GalaSoft.MvvmLight.Command;
    using Rg.Plugins.Popup.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using test.Modelos;
    using test.Vistas;
    using Xamarin.Forms;

    public class ListaPersonasViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Usuarios> _lista;
        private Usuarios _usuarioSeleccionado;
        private string _nombre;
        private string _apellidos;
        private string _editanombre;
        private string _editaapellido;
        private bool _refrescando;
        #endregion

        #region Propiedades
        public ObservableCollection<Usuarios> ListaUsuarios
        {
            get { return this._lista; }
            set { SetValue(ref this._lista, value); }
        }

        public Usuarios UsuarioSeleccionado
        {
            get { return this._usuarioSeleccionado; }
            set
            {
                if (_usuarioSeleccionado != value)
                    this._usuarioSeleccionado = value;
            }
        }

        public bool Refrescando
        {
            get { return this._refrescando; }
            set { SetValue(ref this._refrescando, value); }
        }

        public string NombreSeleccionado
        {
            get { return this._nombre; }
            set { SetValue(ref this._nombre, value); }
        }

        public string ApellidoSeleccionado
        {
            get { return this._apellidos; }
            set { SetValue(ref this._apellidos, value); }
        }

        public string EditaNombre
        {
            get { return this._editanombre; }
            set { SetValue(ref this._editanombre, value); }
        }

        public string EditaApellidos
        {
            get { return this._editaapellido; }
            set { SetValue(ref this._editaapellido, value); }
        }
        #endregion

        #region Contructor
        public ListaPersonasViewModel()
        {
            this.ListaUsuarios = new ObservableCollection<Usuarios>();
            this.CargaLista();
        }
        #endregion

        #region Comandos
        public ICommand GuardarComando
        {
            get { return new RelayCommand(Guardar); }
        }

        public ICommand RefreshComando
        {
            get { return new RelayCommand(CargaLista); }
        }

        public ICommand ItemClickCommand
        {
            get
            {
                return new Command<Usuarios>((itemselected) => 
                {
                    PaginaEditar(itemselected);
                });
            }
        }
        #endregion

        #region Metodos
        private async void PaginaEditar(Usuarios item)
        {
            this.NombreSeleccionado = item.Nombre;
            this.ApellidoSeleccionado = item.Apellido;
            UsuarioSeleccionado = item;
            await PopupNavigation.Instance.PushAsync(new EditarPage());
        }

        public void CargaLista()
        {
            this.Refrescando = true;
            ListaUsuarios = new ObservableCollection<Usuarios>
            {
                new Usuarios{IdUsuario = 1, Nombre = "David", Apellido = ""},
                new Usuarios{IdUsuario = 2, Nombre = "Mauricio", Apellido = ""},
                new Usuarios{IdUsuario = 3, Nombre = "Berenice", Apellido = ""},
                new Usuarios{IdUsuario = 4, Nombre = "Domingo", Apellido = ""}
            };
            this.Refrescando = false;
        }

        private async void Guardar()
        {
            var usr = new Usuarios { IdUsuario = UsuarioSeleccionado.IdUsuario, Nombre = EditaNombre , Apellido = EditaApellidos};

            //if(!string.Equals(EditaNombre, UsuarioSeleccionado.Nombre))
            //{
            if (string.IsNullOrEmpty(this.EditaNombre))
            {
                usr.Nombre = this.NombreSeleccionado;
            }
            //}

            ListaUsuarios.Remove(UsuarioSeleccionado);
            ListaUsuarios.Add(usr);
            this.ListaUsuarios.OrderByDescending(v => v.IdUsuario);
            this.EditaNombre = string.Empty;
            this.EditaApellidos = string.Empty;
            await PopupNavigation.Instance.PopAsync(true);
        }
        #endregion
    }
}
