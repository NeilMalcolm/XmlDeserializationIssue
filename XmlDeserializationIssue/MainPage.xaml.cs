using System.Xml.Serialization;
using SharedProject;

namespace XmlDeserializationIssue;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        try
        {
            TestData.PerformTest();
            AddMessageToEditor("No exception. Yay!");
        }
        catch (Exception ex)
        {
            AddMessageToEditor(ex.ToString());
        }
    }
    
    private void OnButtonClicked2(object sender, EventArgs e)
    {
        try
        {
            TestData.PerformByteArrayTest();
            AddMessageToEditor("No exception. Yay!");
        }
        catch (Exception ex)
        {
            AddMessageToEditor(ex.ToString());
        }
    }

    private void AddMessageToEditor(string message)
    {
        ExceptionEditor.Text = message;
    }
}