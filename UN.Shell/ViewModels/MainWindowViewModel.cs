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
namespace UN.Shell.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private IModuleManager _moduleManager;
        public IRegionManager RegionMannager { get; }

        private DelegateCommand _loadingCommand;
        public DelegateCommand LoadingCommand =>
            _loadingCommand ?? (_loadingCommand = new DelegateCommand(ExecuteLoadingCommand));

        void ExecuteLoadingCommand()
        {
            MessageBox.Show("fff");

            var _jieRegion = RegionMannager.Regions[RegionNames.JieRegion];
            var _paoGridBaoView = CommonServiceLocator.ServiceLocator.Current.GetInstance<PaoGridBao>();
            _jieRegion.Add(_paoGridBaoView);
            /*
           var uniformContentRegion = RegionMannager.Regions["UniformContentRegion"];
           var regionAdapterView1 = CommonServiceLocator.ServiceLocator.Current.GetInstance<RegionAdapterView1>();
           uniformContentRegion.Add(regionAdapterView1);
           var regionAdapterView2 = CommonServiceLocator.ServiceLocator.Current.GetInstance<RegionAdapterView2>();
           uniformContentRegion.Add(regionAdapterView2);

           _medicineListRegion = RegionMannager.Regions[RegionNames.MedicineMainContentRegion];
           */
        }
        public MainWindowViewModel(IModuleManager moduleManager, IRegionManager regionManager )
        {
            _moduleManager = moduleManager;
            RegionMannager = regionManager;
         
           /// _moduleManager.LoadModuleCompleted += _moduleManager_LoadModuleCompleted;
        }
    }
}
