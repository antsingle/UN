using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using UN.Core.Events;
using unvell.ReoGrid;
using Prism.Commands;
using UN.Core.Services;

namespace UN.Cells.ViewModels
{
    class PaoGridBaoViewModel : BindableBase
    {
        private readonly IEventAggregator _ea;
        private ReoGridControl _reoGrid;
        private string _searchCondition;
        public string SearchCondition
        {
            get { return _searchCondition; }
            set { SetProperty(ref _searchCondition, value); }
        }
        public PaoGridBaoViewModel(IEventAggregator ea)
        {
            _ea = ea; ;
            _ea.GetEvent<PaoGridLoadEvent>().Subscribe(PaoGridLoadEReceived);//订阅事件
        }

        private DelegateCommand<ReoGridControl> _loadedCommand;
        public DelegateCommand<ReoGridControl> LoadedCommand =>
           _loadedCommand ?? (_loadedCommand = new DelegateCommand<ReoGridControl>(LoadGridData));
        private void LoadGridData(ReoGridControl reoGridControl)
        {
            _reoGrid = reoGridControl;
            var worksheet = reoGridControl.CurrentWorksheet;
            worksheet.SelectionForwardDirection = SelectionForwardDirection.Down;
            
            worksheet.ColumnHeaders["B"].DefaultCellBody = typeof(unvell.ReoGrid.CellTypes.ButtonCell);
            worksheet[2, 1] = "22";
            worksheet[1, 1] = "fffff";






        }
        private void PaoGridLoadEReceived(string s)
        {
            //ReoGrid.ent
            var worksheet = _reoGrid.CurrentWorksheet;
            worksheet.SelectionForwardDirection = SelectionForwardDirection.Down;
          
            //worksheet.
            //worksheet.ctrl
            worksheet.SetRangeData("A1:Z4", DataBaseData.GetDataBaseData(this.SearchCondition));
            //worksheet[1, 2] = new Button();
        }
    }
}
