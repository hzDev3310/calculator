using System.Data;
using System.Xml.XPath;

namespace calculator;

public partial class MainPage : ContentPage
{

    string ch = "";
    Boolean b = true;
    public MainPage()
	{
		InitializeComponent();
	}

    private  void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            if(button.Text == "C")
            {
                ch = "";
            }
            else if (button.Text == "x")
            {
                ch +="*";
            }
            else if (button.Text == "D") {
                ch=ch.Substring(0, ch.Length - 1);
            }
            else if (button.Text =="=")
            {
                try
                {
                   
                    DataTable dt = new DataTable();
                    object result = dt.Compute(ch, string.Empty);
                    ch = result.ToString();
                }
                catch (Exception)
                {
                    ch = "Error";
                }
                b = false;
            }
            else if (b)
            {
            ch += button.Text;
            }
            else if (!b)
            {
                ch = "";                    
                ch += button.Text;
                b = true;
            } 
            txt.Text = ch;
        }
    }
}

