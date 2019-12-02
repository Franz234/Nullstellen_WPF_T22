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

namespace Nullstellen_WPF_T22
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_berechnen_Click(object sender, RoutedEventArgs e)
        {
            Berechnen_quad();
        }

        private void Berechnen_quad()
        {            
            double a = Convert.ToDouble(TxtBx_a.Text);
            double b = Convert.ToDouble(TxtBx_b.Text);
            double c = Convert.ToDouble(TxtBx_c.Text);
            if (a == 0.0)
            {
                MessageBox.Show("a muss verschieden von Null sein!");
            }
            else
            {
                double p, q, D;
                double x1, x2;
                p = b / a;
                q = c / a;
                D = Math.Pow(p / 2, 2) - q;
                if (D > 0)
                {
                    x1 = -p / 2 + Math.Sqrt(D);
                    x2 = -p / 2 - Math.Sqrt(D);
                    TxtBx_ausgabe.Text = "Es gibt zwei einfache reelle Nullstellen: x_1=" + x1 + " und x_2=" + x2 + " .";
                }
                else if (D == 0.0)
                {
                    x1 = -p / 2;
                    TxtBx_ausgabe.Text = "Es gibt eine doppelte reelle Nullstelle: x_1=" + x1 + " .";
                }
                else
                {
                    TxtBx_ausgabe.Text = "Es gibt keine relle Nullstelle.";
                }
            }
        }

        private void Btn_berechnen1_Click(object sender, RoutedEventArgs e)
        {
            Berechnen_kub();
        }

        private void Berechnen_kub()
        {
            string ausgabe;
            double A = Convert.ToDouble(TxtBx_a1.Text);
            if (A == 0.0)
            {
                Console.WriteLine("a muss verschieden von Null sein!");

            }
            else
            {
                Console.Write("b=");
                double B = Convert.ToDouble(TxtBx_b1.Text);
                Console.Write("c=");
                double C = Convert.ToDouble(TxtBx_c1.Text);
                Console.Write("d=");
                double D = Convert.ToDouble(TxtBx_d1.Text);
                double X0, X1, X2;
                //Normierung
                double a, b, c;
                a = B / A;
                b = C / A;
                c = D / A;
                double p, q;
                p = b - (a * a) / 3.0;
                q = 2.0 * (a * a * a) / 27.0 - a * b / 3.0 + c;
                //Diskriminante
                double delta;
                delta = Math.Pow((q / 2.0), 2.0) + Math.Pow((p / 3.0), 3.0);
                double u, v;
                u = NthRoot(-q / 2.0 + Math.Sqrt(delta), 3.0);
                v = NthRoot(-q / 2.0 - Math.Sqrt(delta), 3.0);
                //Fallunterscheidung
                if (delta > 0.0)
                {
                    X0 = u + v - a / 3.0;
                    ausgabe = "Es gibt eine reelle Nullstelle bei x0=" + X0 + ".";
                    TxtBx_ausgabe1.Text = ausgabe;

                }
                else if (delta == 0.0 && p == 0.0)
                {
                    X0 = -a / 3.0;
                    ausgabe = "Es gibt eine dreifache reelle Nullstelle bei x0=" + X0 + ".";
                    TxtBx_ausgabe1.Text = ausgabe;

                }
                else if (delta == 0.0 && p != 0.0)
                {
                    X0 = 2.0 * u - a / 3.0;
                    X1 = -u - a / 3.0;
                    ausgabe = "Es gibt eine einfache reelle Nullstelle bei x0=" + X0 + " und eine doppelte reelle Nullstelle x1=" + X1 + ".";
                    TxtBx_ausgabe1.Text = ausgabe;
                }
                else
                {
                    X0 = -Math.Sqrt(-4d / 3d * p) * Math.Cos(1d / 3d * Math.Acos(-q / 2 * Math.Sqrt(-27 / (p * p * p))) + Math.PI / 3d) - a / 3.0;
                    X1 = Math.Sqrt(-4d / 3d * p) * Math.Cos(1d / 3d * Math.Acos(-q / 2 * Math.Sqrt(-27 / (p * p * p)))) - a / 3.0;
                    X2 = -Math.Sqrt(-4d / 3d * p) * Math.Cos(1d / 3d * Math.Acos(-q / 2 * Math.Sqrt(-27 / (p * p * p))) - Math.PI / 3d) - a / 3.0;
                    ausgabe = "Es gibt drei reelle Nullstellen x0=" + X0 + ", x1=" + X1 + " und x2=" + X2 + ".";
                    TxtBx_ausgabe1.Text = ausgabe;
                }
            }
        }

        ///<summary>
        /// Bestimmt die N-te Wurzel von positiven und negativen Werten von x
        ///</summary>
        private double NthRoot(double x, double N)
        {
            return (x < 0.0 && N % 2 != 0.0) ? -Math.Pow(-x, 1d / N) : Math.Pow(x, 1d / N);
        }
    }

}


