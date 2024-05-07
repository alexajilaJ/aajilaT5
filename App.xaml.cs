namespace aajilaT5
{
    public partial class App : Application
    {
        public App(Vistas.vPersona vpersona)
        {
            InitializeComponent();

            MainPage = vpersona;
        }
    }
}
