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
using System.Windows.Shapes;

namespace STPRGR
{
    /// <summary>
    /// Логика взаимодействия для UniversalWindow.xaml
    /// </summary>
    public partial class UniversalWindow : Window
    {
        public UniversalWindow(string data)
        {
            InitializeComponent();
            UniversalLabel.Content = data;
            if (data.Length > 25 && !data.Contains("\n"))
            {
                scrollViewer.Width = 500;
                this.Width = 500;
                UniversalLabel.Width = 500;
            }
        }
    }
}
