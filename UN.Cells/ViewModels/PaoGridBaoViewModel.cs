using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using UN.Core.Events;
namespace UN.Cells.ViewModels
{
    class PaoGridBaoViewModel : BindableBase
    {
        private readonly IEventAggregator _ea;
        public PaoGridBaoViewModel(IEventAggregator ea)
        {
            _ea = ea; ;
            _ea.GetEvent<PaoGridLoadEvent>().Subscribe(PaoGridLoadEReceived);//订阅事件
        }

        private void PaoGridLoadEReceived()
        {
            
        }
    }
}
