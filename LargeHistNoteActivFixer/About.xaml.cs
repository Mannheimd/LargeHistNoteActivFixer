using System.Windows;

namespace LargeHistNoteActivFixer
{
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
