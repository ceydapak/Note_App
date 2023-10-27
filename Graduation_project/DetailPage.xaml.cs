namespace Graduation_project;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
        App.DBTrans.FindFileName();
        label.Text = Detail.Title;
		label2.Text = Detail.Description;
        label3.Text = Detail.File;

       
       
	
	}

    private void Note_Update_Clicked(object sender, EventArgs e)
    {
        Detail.Title = label.Text;
        Detail.Description = label2.Text;
        Detail.Date = DateTime.Now;
        Detail.User = LoginClass.Email;
    
        App.DBTrans.UpdateNote(Detail.Id, Detail.Title, Detail.Description, Detail.Date, Detail.User, Detail.File);
        DisplayAlert("Success", "Updating is successful", "OK");

    }

    private void Note_Delete_Clicked(object sender, EventArgs e)
    {
		App.DBTrans.DeleteNote(Detail.Id);
        DisplayAlert("Success", "Deleting is successful", "OK");
        Navigation.PushAsync(new MainPage());

    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        App.DBTrans.GetNotes();
    }
}