using System.Windows;
using System.Windows.Controls;

namespace Homework_10
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        private ClientData data;
        private Repository repository;
        public EditClient(ClientData data, Repository repository)
        {
            InitializeComponent();
            this.data = data;
            Init(data);
            this.repository = repository;
        }
        private void Init(ClientData data)
        {
            tb_FirstName.Text = data.FirstName;
            tb_LastName.Text = data.LastName;
            tb_Patronymic.Text = data.Patronymic;
            tb_PhoneNumber.Text = data.PhoneNumber;

            string serial;
            string number;
            if (AccessMode.IsConsultantMode)
            {
                serial = "****";
                number = "******";
            }
            else
            {
                serial = data.Passport.Remove(data.Passport.IndexOf(","));
                number = data.Passport.Remove(0, data.Passport.IndexOf(" ") + 1);
            }
            tb_PassportSerial.Text = serial;
            tb_PassportNumber.Text = number;


            tb_FirstName.IsEnabled  = !AccessMode.IsConsultantMode;
            tb_LastName.IsEnabled   = !AccessMode.IsConsultantMode;
            tb_Patronymic.IsEnabled = !AccessMode.IsConsultantMode;
            tb_PassportSerial.IsEnabled = !AccessMode.IsConsultantMode;
            tb_PassportNumber.IsEnabled = !AccessMode.IsConsultantMode;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            l_StatusBar.Content = "";
            string errorStatus = "";

            if (string.IsNullOrEmpty(tb_FirstName.Text)) { errorStatus += $"[{l_FirstName.Content.ToString()}] "; }
            if (string.IsNullOrEmpty(tb_LastName.Text)) { errorStatus += $"[{l_LastName.Content.ToString()}] "; }
            if (string.IsNullOrEmpty(tb_Patronymic.Text)) { errorStatus += $"[{l_Patronymic.Content.ToString()}] "; }
            if (string.IsNullOrEmpty(tb_PhoneNumber.Text)) { errorStatus += $"[{l_PhoneNumber.Content.ToString()}] "; }
            if (string.IsNullOrEmpty(tb_PassportSerial.Text) && string.IsNullOrEmpty(tb_PassportNumber.Text)) { errorStatus += "[Паспортные данные] "; }

            if (!string.IsNullOrEmpty(errorStatus)) { l_StatusBar.Content = "Требуеться заполнить поле: " + errorStatus; return; }

            data.FirstName = tb_FirstName.Text;
            data.LastName = tb_LastName.Text;
            data.Patronymic = tb_Patronymic.Text;
            data.PhoneNumber = tb_PhoneNumber.Text; 
            if(!AccessMode.IsConsultantMode)
            {
                data.Passport = tb_PassportSerial.Text + ", " + tb_PassportNumber.Text;
            }
            repository.SaveJson();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
