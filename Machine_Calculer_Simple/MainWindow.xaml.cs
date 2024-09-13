using Machine_Calculer_Simple.Calcul;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Machine_Calculer_Simple
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static string? txtClique;
        private static bool isActive = true;
        private static string? historique;
        private static string? reponse = string.Empty;
        private string? temps;
        private char dernier = 'O';
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Closed_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Affiche.Text.Length >= 16)
            {
                if (sender is Button btn)
                {
                    if (btn.Name == _SUP.Name)
                    {
                        txtClique = txtClique.Substring(0, txtClique.Length - 1);
                        txt_Affiche.Text = txtClique;
                    }
                    else
                    {
                        txt_Affiche.Text = "Trop long! diminuer et activer";
                        DesactiActiveBtn();
                    }
                }

            }
            else
            {
                if (sender is Button btnClicked)
                {
                    if (btnClicked.Name == _CE.Name)
                    {
                        Cleaner();
                    }
                    if (btnClicked.Name == _SUP.Name)
                    {
                        Suppression();
                    }
                    if (btnClicked.Name == _OFF.Name)
                    {
                        DesactiActiveBtn();
                    }
                    if(dernier != '=')
                    {
                        if (btnClicked.Name == _0.Name) { txtClique += "0"; temps = "0"; }
                        if (btnClicked.Name == _1.Name) { txtClique += "1"; temps = "1"; }
                        if (btnClicked.Name == _2.Name) { txtClique += "2"; temps = "2"; }
                        if (btnClicked.Name == _3.Name) { txtClique += "3"; temps = "3"; }
                        if (btnClicked.Name == _4.Name) { txtClique += "4"; temps = "4"; }
                        if (btnClicked.Name == _5.Name) { txtClique += "5"; temps = "5"; }
                        if (btnClicked.Name == _6.Name) { txtClique += "6"; temps = "6"; }
                        if (btnClicked.Name == _7.Name) { txtClique += "7"; temps = "7"; }
                        if (btnClicked.Name == _8.Name) { txtClique += "8"; temps = "8"; }
                        if (btnClicked.Name == _9.Name) { txtClique += "9"; temps = "9"; }
                        if (btnClicked.Name == _POI.Name)
                        {
                            if (!txtClique.Contains(",") && txtClique != string.Empty)
                            {
                                txtClique += ","; temps = ",";
                            }
                            else { return; }
                        }
                    }
                    if (btnClicked.Name == _DIV.Name)
                    {
                        MethodeEvent('/');
                        return;
                    }
                    if (btnClicked.Name == _MUL.Name)
                    {
                        MethodeEvent('*');
                        return;
                    }
                    if (btnClicked.Name == _ADD.Name)
                    {
                        MethodeEvent('+');
                        return;
                    }
                    if (btnClicked.Name == _SOU.Name)
                    {
                        MethodeEvent('-');
                        return;
                    }
                    if (btnClicked.Name == _EGA.Name)
                    {
                        if (dernier == '=')
                            return;
                        else
                        {
                            reponse = ACalculer();
                            txt_Affiche.Text = reponse;
                            txtClique = string.Empty;
                            dernier = '=';
                        }
                        return;
                    }

                }
                if(dernier != '=')
                {
                    txt_Affiche.Text = txtClique;
                    historique += temps;
                    txt_historique.Text = historique;
                }
            }



        }
        private void DesactiActiveBtn()
        {
            if (isActive)
            {
                isActive = false;
                _OFF.Content = "ON";
                _CE.IsEnabled = isActive; _SUP.IsEnabled = isActive; _DIV.IsEnabled = isActive;
                _7.IsEnabled = isActive; _8.IsEnabled = isActive; _9.IsEnabled = isActive; _MUL.IsEnabled = isActive;
                _4.IsEnabled = isActive; _5.IsEnabled = isActive; _6.IsEnabled = isActive; _SOU.IsEnabled = isActive;
                _1.IsEnabled = isActive; _2.IsEnabled = isActive; _3.IsEnabled = isActive; _ADD.IsEnabled = isActive;
                _0.IsEnabled = isActive; _POI.IsEnabled = isActive; _EGA.IsEnabled = isActive;
            }
            else
            {
                txt_Affiche.Text = txtClique;
                isActive = true;
                _OFF.Content = "OFF";
                _CE.IsEnabled = isActive; _SUP.IsEnabled = isActive; _DIV.IsEnabled = isActive;
                _7.IsEnabled = isActive; _8.IsEnabled = isActive; _9.IsEnabled = isActive; _MUL.IsEnabled = isActive;
                _4.IsEnabled = isActive; _5.IsEnabled = isActive; _6.IsEnabled = isActive; _SOU.IsEnabled = isActive;
                _1.IsEnabled = isActive; _2.IsEnabled = isActive; _3.IsEnabled = isActive; _ADD.IsEnabled = isActive;
                _0.IsEnabled = isActive; _POI.IsEnabled = isActive; _EGA.IsEnabled = isActive;
            }
        }
        private void Recap()
        {
            if (historique.EndsWith("/") || historique.EndsWith("*") || historique.EndsWith("+") || historique.EndsWith("-"))
            {
                historique = historique.Substring(0, historique.Length - 1);
            }
        }
        private string ACalculer()
        {
            string rep = string.Empty;
            if (txtClique != string.Empty)
            {
                
                switch (dernier)
                {
                    case '/':
                        rep = Operation.Division(txtClique, reponse) + "";
                        break;
                    case '*':
                        rep = Operation.Multiplication(txtClique, reponse) + "";
                        break;
                    case '-':
                        rep = Operation.Soustraction(txtClique, reponse) + "";
                        break;
                    case '+':
                        rep = Operation.Addition(txtClique, reponse) + "";
                        break;
                    case 'O':
                        rep = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                txtClique = reponse;
                rep = reponse;
            }
            return rep;
        }
        private void MethodeEvent(char der)
        {
            if(historique == string.Empty)
            {
                return;
            }
            else
            {
                if (dernier == '=')
                {
                    dernier = der;
                    historique += dernier;
                    txt_historique.Text = historique;
                    return;
                }
                Recap();
                reponse = dernier != 'O' ? ACalculer() : txtClique;
                txt_Affiche.Text = string.Empty;
                dernier = der;
                historique += dernier;
                txtClique = string.Empty;
                txt_Affiche.Text += reponse;
                temps = string.Empty;
                txt_historique.Text = historique;
            }
        }
        private void Suppression()
        {
            if(txtClique != string.Empty)
            {
                txtClique = txtClique.Substring(0, txtClique.Length - 1);
                txt_Affiche.Text = txtClique;
                temps = string.Empty;
                historique = historique.Substring(0, historique.Length - 1);
            }
        }
        private void Cleaner()
        {
            txtClique = string.Empty;
            temps = string.Empty;
            historique = string.Empty;
            dernier = 'O';
        }
    }
}