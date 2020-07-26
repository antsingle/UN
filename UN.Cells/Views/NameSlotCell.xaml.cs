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
using UN.Core.DB.DBModels;
using UN.Core.DB;
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

        private void ShowHide_Click(object sender, RoutedEventArgs e)
        {
            if(this.ReoGridS.Visibility== Visibility.Visible)
            {
                this.ReoGridM.Height = 400;
                this.ReoGridS.Visibility = Visibility.Hidden;
                this.Bt2.Visibility = Visibility.Hidden;
                //this.Row1.Height = 0;
            }
            else
            {
                this.ReoGridM.Height = 200;
                this.ReoGridS.Visibility = Visibility.Visible;
                this.Bt2.Visibility = Visibility.Visible;
                this.ReoGridS.Height = 200;
            }
          
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            var range = ReoGridS.CurrentWorksheet.SelectionRange;
            var list = new List<UN_Slots>();
            for(int r = 0; r < range.Rows; r++)
            {
                var s = new UN_Slots();
                s.Name = ReoGridS.CurrentWorksheet.Cells[r,1].DisplayText;
                s.Slot1 = ReoGridS.CurrentWorksheet.Cells[r, 2].DisplayText;
                s.Slot2 = ReoGridS.CurrentWorksheet.Cells[r, 3].DisplayText;
                s.Slot3 = ReoGridS.CurrentWorksheet.Cells[r, 4].DisplayText;
                list.Add(s);
            }
            SugarDb.GetDbInstance().Insertable(list.ToArray()).ExecuteCommand();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select Id,Name,Slot1,Slot2,Slot3 from UN_Slots ";
            var dt=SugarDb.GetDbInstance().Ado.GetDataTable(sql);
            this.ReoGridM.CurrentWorksheet.SetRangeData("A1:E200", dt);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var range = ReoGridM.CurrentWorksheet.SelectionRange;
            var list = new List<UN_Slots>();
            for (int r = range.Row; r < range.Row +range.Rows; r++)
            {
                if (ReoGridM.CurrentWorksheet.Cells[r, 0].DisplayText is null) break;
                var s = new UN_Slots();
                s.Id = int.Parse(ReoGridM.CurrentWorksheet.Cells[r, 0].DisplayText);
                s.Name = ReoGridM.CurrentWorksheet.Cells[r, 1].DisplayText;
                s.Slot1 = ReoGridM.CurrentWorksheet.Cells[r, 2].DisplayText;
                s.Slot2 = ReoGridM.CurrentWorksheet.Cells[r, 3].DisplayText;
                s.Slot3 = ReoGridM.CurrentWorksheet.Cells[r, 4].DisplayText;
                list.Add(s);
            }
            SugarDb.GetDbInstance().Updateable(list).ExecuteCommand();
        }
    }
}
