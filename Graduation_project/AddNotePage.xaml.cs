namespace Graduation_project;

public partial class AddNotePage : ContentPage
{


    public AddNotePage()
    {
        InitializeComponent();



    }

    private void Send_Btn_Clicked(object sender, EventArgs e)
    {
        var note = new Note();
        note.Title = title.Text;
        note.Date = DateTime.Now;
        note.Description = note_entry.Text;
        note.User = LoginClass.Email;
        note.File = FileNameLabel.Text;
        App.DBTrans.InsertNote(note);
        DisplayAlert("Success", "Adding is successful", "OK");



    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        App.DBTrans.GetNotes();
       
    }

    private async void Load_Btn_Clicked(object sender, EventArgs e)
    {

        FileResult result = await FilePicker.PickAsync();

        if (result != null)
        {
            string fileName = Path.GetFileName(result.FullPath);
            FileNameLabel.Text = fileName;


        }

    }
}
