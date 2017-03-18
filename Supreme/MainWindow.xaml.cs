using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Supreme
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        String URL;
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void setString(string a)
        {
            number_textbox.Text = a;
        }

        private void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (i == 0)
            {
                mshtml.HTMLDocument document = (mshtml.HTMLDocument)webBrowser1.Document;
                var elems = document.getElementsByName("commit");
                foreach (mshtml.IHTMLElement button in elems)
                {
                    mshtml.IHTMLElement k = button;
                    k.click();
                    i = 1; 
                }
                webBrowser1.Navigate("https://www.supremenewyork.com/checkout");
            }
            else if (i == 1)
            {
                mshtml.HTMLDocument document2 = (mshtml.HTMLDocument)webBrowser1.Document;
                mshtml.IHTMLInputElement input = (mshtml.IHTMLInputElement)document2.getElementById("order_billing_name");
                input.value = name_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("order_email");
                input.value = email_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("order_tel");
                input.value = tel_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("bo");
                input.value = add1_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("oba3");
                input.value = add2_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("order_billing_zip");
                input.value = zip_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("order_billing_city");
                input.value = city_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("cnb");
                input.value = number_textbox.Text;

                input = (mshtml.IHTMLInputElement)document2.getElementById("vval");
                input.value = cvv_textbox.Text;

                mshtml.IHTMLSelectElement select = (mshtml.IHTMLSelectElement)document2.getElementById("order_billing_state");
                select.value = state_combobox.Text;

                select = (mshtml.IHTMLSelectElement)document2.getElementById("credit_card_type");
                if (type_combobox.Text == "Visa")
                {
                    select.value = "visa"; 
                }
                if (type_combobox.Text == "American Express")
                {
                    select.value = "american_express";

                }
                if (type_combobox.Text == "Master Card")
                {
                    select.value = "master";
                }

                select = (mshtml.IHTMLSelectElement)document2.getElementById("credit_card_month");
                select.value = month_combobox.Text;

                select = (mshtml.IHTMLSelectElement)document2.getElementById("credit_card_year");
                select.value = year_combobox.Text;

                var elems = document2.getElementsByName("order[terms]");
                foreach (mshtml.IHTMLElement button in elems)
                {
                    mshtml.IHTMLElement k = button;
                    k.click();
                }

                elems = document2.getElementsByName("commit");
                foreach (mshtml.IHTMLElement button in elems)
                {
                    mshtml.IHTMLElement k = button;
                    k.click();
                }

                i = 2;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            URL = URL_Text.Text;
            webBrowser1.Navigate(URL);
        }

        private void country_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void save_1(object sender, RoutedEventArgs e)
        {
            FileWrite a = new FileWrite(1);
        }

        private void save_2(object sender, RoutedEventArgs e)
        {
            FileWrite a = new FileWrite(2);
        }

        private void save_3(object sender, RoutedEventArgs e)
        {
            FileWrite a = new FileWrite(3);
        }

        private void save_4(object sender, RoutedEventArgs e)
        {
            FileWrite a = new FileWrite(4);
        }

        private void load_1(object sender, RoutedEventArgs e)
        {
            FileRead a = new FileRead(1);
        }

        private void load_2(object sender, RoutedEventArgs e)
        {
            FileRead a = new FileRead(2);
        }

        private void load_3(object sender, RoutedEventArgs e)
        {
            FileRead a = new FileRead(3);
        }

        private void load_4(object sender, RoutedEventArgs e)
        {
            FileRead a = new FileRead(4);
        }


    }


    public class FileWrite{

        string select_number;
        private string [] data = new string [13];
        string exePath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public FileWrite(int i)
        {
            select_number = i.ToString();
            exePath = exePath + "/"+ select_number + ".txt";
            data[0] = ((MainWindow)System.Windows.Application.Current.MainWindow).name_textbox.Text;
            data[1] = ((MainWindow)System.Windows.Application.Current.MainWindow).email_textbox.Text;
            data[2] = ((MainWindow)System.Windows.Application.Current.MainWindow).tel_textbox.Text;
            data[3] = ((MainWindow)System.Windows.Application.Current.MainWindow).add1_textbox.Text;
            data[4] = ((MainWindow)System.Windows.Application.Current.MainWindow).add2_textbox.Text;
            data[5] = ((MainWindow)System.Windows.Application.Current.MainWindow).zip_textbox.Text;
            data[6] = ((MainWindow)System.Windows.Application.Current.MainWindow).city_textbox.Text;
            data[7] = ((MainWindow)System.Windows.Application.Current.MainWindow).number_textbox.Text;
            data[8] = ((MainWindow)System.Windows.Application.Current.MainWindow).cvv_textbox.Text;
            data[9] = ((MainWindow)System.Windows.Application.Current.MainWindow).state_combobox.Text;
            data[10] = ((MainWindow)System.Windows.Application.Current.MainWindow).type_combobox.Text;
            data[11] = ((MainWindow)System.Windows.Application.Current.MainWindow).month_combobox.Text;
            data[12] = ((MainWindow)System.Windows.Application.Current.MainWindow).year_combobox.Text;

            System.IO.File.WriteAllText(exePath, data[0], Encoding.Default);

            for (int k = 1; k < 13; k++)
            {
                System.IO.File.AppendAllText(exePath, "\r\n"+data[k], Encoding.Default);
            }
        }

        ~FileWrite()
        {

        }

    }


    public class FileRead
    {
        string select_number;
        private string[] data = new string[13];
        string exePath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        string line;
        public FileRead(int i)
        {
            try
            {
                select_number = i.ToString();
                exePath = exePath + "/" + select_number + ".txt";
                System.IO.StreamReader file = new System.IO.StreamReader(exePath);
                int k = 0;
                while ((line = file.ReadLine()) != null)
                {
                    data[k] = line;
                    k++;
                }

                file.Close();

                ((MainWindow)System.Windows.Application.Current.MainWindow).name_textbox.Text = data[0];
                ((MainWindow)System.Windows.Application.Current.MainWindow).email_textbox.Text = data[1];
                ((MainWindow)System.Windows.Application.Current.MainWindow).tel_textbox.Text = data[2];
                ((MainWindow)System.Windows.Application.Current.MainWindow).add1_textbox.Text = data[3];
                ((MainWindow)System.Windows.Application.Current.MainWindow).add2_textbox.Text = data[4];
                ((MainWindow)System.Windows.Application.Current.MainWindow).zip_textbox.Text = data[5];
                ((MainWindow)System.Windows.Application.Current.MainWindow).city_textbox.Text = data[6];
                ((MainWindow)System.Windows.Application.Current.MainWindow).number_textbox.Text = data[7];
                ((MainWindow)System.Windows.Application.Current.MainWindow).cvv_textbox.Text = data[8];
                ((MainWindow)System.Windows.Application.Current.MainWindow).state_combobox.Text = data[9];
                ((MainWindow)System.Windows.Application.Current.MainWindow).type_combobox.Text = data[10];
                ((MainWindow)System.Windows.Application.Current.MainWindow).month_combobox.Text = data[11];
                ((MainWindow)System.Windows.Application.Current.MainWindow).year_combobox.Text = data[12];
            }
            catch (Exception)
            {

            }
             
            
        }

        ~FileRead()
        {

        }

    }

}
