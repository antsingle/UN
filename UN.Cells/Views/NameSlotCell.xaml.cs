using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UN.Cells.Views
{
    /// <summary>
    /// NameSlotCell.xaml 的交互逻辑
    /// </summary>
    public partial class NameSlotCell : StackPanel
    {
        public NameSlotCell()
        {
            InitializeComponent();
            ReoGridM.SheetTabVisible = false;
            ReoGridS.SheetTabVisible = false;
            ReoGridM.CurrentWorksheet.ColumnCount = 5;
            ReoGridM.CurrentWorksheet.ColumnHeaders["A"].IsVisible = false;
            ReoGridS.CurrentWorksheet.ColumnCount = 5;
            ReoGridS.CurrentWorksheet.ColumnHeaders["A"].IsVisible = false;

            ReoGridM.CurrentWorksheet.ColumnHeaders["B"].Text = "Name";
            ReoGridM.CurrentWorksheet.ColumnHeaders["C"].Text = "Slot1";
            ReoGridM.CurrentWorksheet.ColumnHeaders["D"].Text = "Slot2";
            ReoGridM.CurrentWorksheet.ColumnHeaders["E"].Text = "Slot3";

            ReoGridS.CurrentWorksheet.ColumnHeaders["B"].Text = "Name";
            ReoGridS.CurrentWorksheet.ColumnHeaders["C"].Text = "Slot1";
            ReoGridS.CurrentWorksheet.ColumnHeaders["D"].Text = "Slot2";
            ReoGridS.CurrentWorksheet.ColumnHeaders["E"].Text = "Slot3";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.ReoGridS.Visibility== Visibility.Visible)
            {
                this.ReoGridM.Height = 400;
                this.ReoGridS.Visibility = Visibility.Hidden;
            }
            else
            {
                this.ReoGridM.Height = 200;
                this.ReoGridS.Visibility = Visibility.Visible;
                this.ReoGridS.Height = 200;
            }
          
        }
    }
}
