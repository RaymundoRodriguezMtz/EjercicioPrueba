using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    class MainViewModel
    {
        #region Propiedades
        public ListaPersonasViewModel ListaView { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instancia = this;

        } 
        #endregion

        #region Singleton
        private static MainViewModel instancia;

        public static MainViewModel ObtenerInstancia()
        {
            if(instancia == null)
            {
                return new MainViewModel();
            }

            return instancia;
        }
        #endregion
    }
}
