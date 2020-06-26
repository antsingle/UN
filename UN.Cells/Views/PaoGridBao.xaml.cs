using Prism.Events;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UN.Core.Events;
using UN.Core.Services;
using Prism.Ioc;
namespace UN.Cells.Views
{
    /// <summary>
    /// PaoGridBao.xaml 的交互逻辑
    /// </summary>
    public partial class PaoGridBao : StackPanel
    {
        private readonly IContainerExtension _containerProvider;
        private readonly IEventAggregator _ea;
        public PaoGridBao(IContainerExtension containerProvider)
        {
            InitializeComponent();
            _containerProvider = containerProvider;
            _ea = containerProvider.Resolve<IEventAggregator>();
            //_ea = ea; ;
            _ea.GetEvent<PaoGridLoadEvent>().Subscribe(PaoGridLoadEReceived);//订阅事件

        }
        private void PaoGridLoadEReceived()
        {
            var worksheet = ReoGrid.CurrentWorksheet;
          
            worksheet.SetRangeData("A1:Z4", DataBaseData.GetDataBaseData());
        }
    }
}
