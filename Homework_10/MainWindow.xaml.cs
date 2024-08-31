using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Homework_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository repository;
        public ICommand EditCommand { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            repository  = new Repository();
            DataContext = repository;
            lv_ClientsBase.ItemsSource = repository.Clients;
            repository.PropertyChanged += Repository_PropertyChanged;

            button_Del.IsEnabled = !AccessMode.IsConsultantMode;
        }        
        
        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient(repository);
            addClient.Show();           
        }
        private void button_Del_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = lv_ClientsBase.SelectedItems.Cast<ClientData>().ToList();
            repository.RemoveClientItems(selectedItems);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Repository_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Repository.Clients))
            {
                lv_ClientsBase.ItemsSource = null;
                lv_ClientsBase.ItemsSource = repository.Clients;
            }
        }


        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.IsEnabled = false;
        }

        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }

        private void lv_ClientsBase_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lv_ClientsBase.SelectedItem == null) return;
            ClientData selectedClient = lv_ClientsBase.SelectedItem as ClientData;
            if (selectedClient == null) return;
            
            EditClient editClient = new EditClient(selectedClient, repository);
            editClient.Show();
        }
    }
}
