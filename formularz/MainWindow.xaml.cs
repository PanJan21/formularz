using System.Windows;
namespace formularz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZapiszButton_Click(object sender, RoutedEventArgs e)
        {
            string imie = ImieTextBox.Text.Trim();
            string nazwisko = NazwiskoTextBox.Text.Trim();
            string dodatkoweInfo = DodatkoweInfoTextBox.Text.Trim();

            bool isKobieta = KobietaRadioButton.IsChecked ?? false;
            bool isMezyczyzna = MezyczyznaRadioButton.IsChecked ?? false;
            string plec = isKobieta ? "Kobieta" : (isMezyczyzna ? "Mężczyzna" : string.Empty);
            DateTime? dataUrodzenia = DataUrodzeniaPicker.SelectedDate;
            if (string.IsNullOrEmpty(imie) ||
                string.IsNullOrEmpty(nazwisko) ||
                string.IsNullOrEmpty(plec) ||
                !dataUrodzenia.HasValue ||
                string.IsNullOrEmpty(dodatkoweInfo))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola formularza!", "Błąd walidacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MessageBox.Show($"Zapisano pomyślnie:\n" +
                            $"Imię: {imie}\n" +
                            $"Nazwisko: {nazwisko}\n" +
                            $"Płeć: {plec}\n" +
                            $"Data urodzenia: {dataUrodzenia.Value.ToShortDateString()}\n" +
                            $"Dodatkowe info: {dodatkoweInfo}",
                            "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void AnulujButton_Click(object sender, RoutedEventArgs e)
        {
            ImieTextBox.Clear();
            NazwiskoTextBox.Clear();
            DodatkoweInfoTextBox.Clear();
            KobietaRadioButton.IsChecked = false;
            MezyczyznaRadioButton.IsChecked = false;
            DataUrodzeniaPicker.SelectedDate = null;
        }
    }
}