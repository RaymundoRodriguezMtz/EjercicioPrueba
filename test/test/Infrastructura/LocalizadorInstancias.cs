namespace test
{
    class LocalizadorInstancias
    {
        #region Propiedades
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public LocalizadorInstancias()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
