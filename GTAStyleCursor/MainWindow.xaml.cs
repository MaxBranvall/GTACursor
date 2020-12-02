using System;
using System.IO;
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
using WinCursorChanger;

namespace GTAStyleCursor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int selection { get; set; }
        private string cursorPath { get; init; }

        private CursorChanger cursorChanger;

        enum CursorOptions
        {
            NoSelection,
            Common,
            LinkSelect,
            All
        }

        public MainWindow()
        {
            InitializeComponent();
            this.cursorPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Cursors\\_middleFinger.cur");
            cursorChanger = new CursorChanger(this.cursorPath);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            selection = cmb.SelectedIndex;
        }

        private void ChangeCursor_Click(object sender, RoutedEventArgs e)
        {

            switch(this.selection)
            {
                case (int)CursorOptions.LinkSelect:
                    this.replaceLinkSelect();
                    break;
                case (int)CursorOptions.Common:
                    this.replaceCommon();
                    break;
                case (int)CursorOptions.All:
                    this.replaceAll();
                    break;

                default:
                    break;

            };
                    
        }

        private void RevertToDefault_Click(object sender, RoutedEventArgs e)
        {
            if (this.cursorChanger.restoreAllDefaultCursors())
            {
                MessageBox.Show("Success!");
                return;
            }

            MessageBox.Show("Error..");
        }

        private void replaceLinkSelect()
        {
            if (this.cursorChanger.replaceLinkSelectCursor())
            {
                MessageBox.Show("Success!");
                return;
            }

            MessageBox.Show("Error..");
        }

        private void replaceCommon()
        {
            if (this.cursorChanger.replaceCommonCursors())
            {
                MessageBox.Show("Success!");
                return;
            }

            MessageBox.Show("Error..");
        }

        private void replaceAll()
        {
            if (this.cursorChanger.replaceAllCursors())
            {
                MessageBox.Show("Success!");
                return;
            }

            MessageBox.Show("Error..");
        }
    }
}
