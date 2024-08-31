using System.Windows;
using System.Windows.Controls;

namespace Homework_10
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        Repository repository;
        public AddClient(Repository repository)
        {
            InitializeComponent();
            this.repository = repository;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            l_StatusBar.Content = "";  
            string errorStatus = "";

            if (string.IsNullOrEmpty(tb_FirstName.Text))   { errorStatus += $"[{l_FirstName.Content.ToString()}] "  ;}
            if (string.IsNullOrEmpty(tb_LastName.Text))    { errorStatus += $"[{l_LastName.Content.ToString()}] "  ;}
            if (string.IsNullOrEmpty(tb_Patronymic.Text))  { errorStatus += $"[{l_Patronymic.Content.ToString()}] " ;}
            if (string.IsNullOrEmpty(tb_PhoneNumber.Text)) { errorStatus += $"[{l_PhoneNumber.Content.ToString()}] ";}
            if (string.IsNullOrEmpty(tb_PassportSerial.Text) && string.IsNullOrEmpty(tb_PassportNumber.Text)) { errorStatus += "[Паспортные данные] "; }

            if (!string.IsNullOrEmpty(errorStatus)) { l_StatusBar.Content = "Требуеться заполнить поле: " + errorStatus; return; }

            ClientData clientData = new ClientData(
                tb_FirstName.Text,
                tb_LastName.Text,
                tb_Patronymic.Text,
                tb_PhoneNumber.Text,
                tb_PassportSerial.Text + ", " + tb_PassportNumber.Text);

            repository.AddClient(clientData);
            this.Close();
        }
    }
}
