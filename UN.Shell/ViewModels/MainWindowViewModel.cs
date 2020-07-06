using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using UN.Core.Constants;
using UN.Cells.Views;
using Prism.Events;
using UN.Core.Events;
namespace UN.Shell.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private readonly IEventAggregator _ea;
        private IModuleManager _moduleManager;
        public IRegionManager RegionMannager { get; }

        private DelegateCommand _loadingCommand;
        private DelegateCommand _loadCommand;
        private PaoGridBao _paoGridBaoView;
        public DelegateCommand LoadingCommand =>
            _loadingCommand ?? (_loadingCommand = new DelegateCommand(ExecuteLoadingCommand));
        public DelegateCommand LoadCommand =>
         _loadCommand ?? (_loadCommand = new DelegateCommand(ExecuteLoadCommand));

        private void ExecuteLoadCommand()
        {
            _ea.GetEvent<PaoGridLoadEvent>().Publish("");
            // private readonly IEventAggregator _ea;
        }

        void ExecuteLoadingCommand()
        {
            //MessageBox.Show("fff");

            var _jieRegion = RegionMannager.Regions[RegionNames.JieRegion];
            _paoGridBaoView = CommonServiceLocator.ServiceLocator.Current.GetInstance<PaoGridBao>();
            var _jieRegion2 = RegionMannager.Regions[RegionNames.JieRegion2];
            var _paoGridBaoView2 = CommonServiceLocator.ServiceLocator.Current.GetInstance<MeCell>();
            _jieRegion.Add(_paoGridBaoView);
            _jieRegion2.Add(_paoGridBaoView2);
            /*
           var uniformContentRegion = RegionMannager.Regions["UniformContentRegion"];
           var regionAdapterView1 = CommonServiceLocator.ServiceLocator.Current.GetInstance<RegionAdapterView1>();
           uniformContentRegion.Add(regionAdapterView1);
           var regionAdapterView2 = CommonServiceLocator.ServiceLocator.Current.GetInstance<RegionAdapterView2>();
           uniformContentRegion.Add(regionAdapterView2);

           _medicineListRegion = RegionMannager.Regions[RegionNames.MedicineMainContentRegion];
           */
        }
        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager, IEventAggregator ea)
        {
            _ea = ea;
            _moduleManager = moduleManager;
            RegionMannager = regionManager;
         
           /// _moduleManager.LoadModuleCompleted += _moduleManager_LoadModuleCompleted;
        }
    }
}
