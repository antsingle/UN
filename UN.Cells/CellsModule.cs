using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using UN.Cells.Views;
using UN.Core.Constants;
namespace UN.Cells
{
    public class CellsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.JieRegion, typeof(PaoGridBao));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
