using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GDS.Mobile.Helpers
{
    public class ObservableGroupCollection<S, T> : ObservableCollection<T>
    {
        private readonly S key;

        public ObservableGroupCollection(IGrouping<S, T> grouping) : base(grouping)
        {
            key = grouping.Key;
        }

        public S Key => key;
    }
}