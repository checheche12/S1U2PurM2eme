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


    }
}
