namespace Graduation_project;


public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
       


    }
    private void Login_Button_Clicked(object sender, EventArgs e)
    {
        LoginClass.Email = logemail.Text;
        LoginClass.Password = logpassword.Text;

        bool result = App.DBTrans.IsLogin();

        if (result == true)
        {
             Navigation.PushAsync(new MainPage());
        }
        else
        {
            DisplayAlert("Fail", "Email address or password is wrong!", "OK");
        }
    }


    private void Reg_nav_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Register());
    }
    //protected override bool OnBackButtonPressed()
    //{
    //    return true;
    //}
}