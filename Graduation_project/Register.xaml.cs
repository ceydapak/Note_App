namespace Graduation_project;

public partial class Register : ContentPage
{

	public Register()
	{
		InitializeComponent();
           NavigationPage.SetHasBackButton(this, false);
        
    }

    private void Save_Btn_Clicked(object sender, EventArgs e)
    {
        var user = new User();
        user.Name = name.Text;
        user.Surname = sname.Text;
        user.BirthDate = bdate.Date;
        user.Email = email.Text;
        user.Password= password.Text;
        App.DBTrans.InsertUser(user);
        LoginClass.Email = user.Email;
        LoginClass.Password = user.Password;
        DisplayAlert("Registered", "You registered on the system successfully!", "OK");
        Navigation.PushAsync(new MainPage());
      
        
    }

    //private async void Log_nav_Clicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushAsync(new Login());
    //}


    //protected override bool OnBackButtonPressed()
    //{
    //    return true;
    //}
}