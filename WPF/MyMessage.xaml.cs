using System.Windows;
using System.Windows.Input;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MyMessage.xaml
    /// </summary>
    public partial class MyMessage : Window
    {
        public bool Save { get; set; }
        public MyMessage(string message)
        {
            InitializeComponent();
            txtMessage.Text = message;
        }


        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Yes_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                No_Click(sender, e);
            }
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Save = true;
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Save = false;
            this.Close();
        }
    }
}
