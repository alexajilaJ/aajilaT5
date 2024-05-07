namespace aajilaT5.Vistas;

public partial class vPersona : ContentPage
{
    private readonly FileAccessHelper _dbService;
    private int _editNombreId;

    public vPersona(FileAccessHelper dbService)
	{
		InitializeComponent();
        _dbService = dbService;

        Task.Run(async () => listView.ItemsSource = await _dbService.GetPersonas());

    }

    private async void saveButton_Clicked(object sender, EventArgs e)
    {
        if (_editNombreId == 0)
        {
            await _dbService.Create(new Modelos.Persona
            {
                Nombre = txtNombre.Text,
                Email = txtCorreo.Text,
                Telefono = txtTelefono.Text,
            });
        }
        else
        {
            await _dbService.Update(new Modelos.Persona
            {
                Id = _editNombreId,
                Nombre = txtNombre.Text,
                Email = txtCorreo.Text,
                Telefono = txtTelefono.Text,
            });

            _editNombreId = 0;
        }

        txtNombre.Text = string.Empty;
        txtCorreo.Text = string.Empty;
        txtTelefono.Text = string.Empty;

        listView.ItemsSource = await _dbService.GetPersonas();
    }
    private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var customer = (Modelos.Persona)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");
        switch (action)
        {
            case "Edit":

                _editNombreId = customer.Id;
                txtNombre.Text = customer.Nombre;
                txtCorreo.Text = customer.Email;
                txtTelefono.Text = customer.Telefono;
                break;
            case "Delete":
                await _dbService.Delete(customer);
                listView.ItemsSource = await _dbService.GetPersonas();
                break;
        }
    }
}