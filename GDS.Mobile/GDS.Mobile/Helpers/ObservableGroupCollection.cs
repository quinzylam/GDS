using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GDS.Mobile.Helpers
{
    public class ObservableGroupCollection<S, T> : ObservableCollection<T>
    {
        private readonly S _key;

        public ObservableGroupCollection(IGrouping<S, T> grouping) : base(grouping)
        {
            _key = grouping.Key;
        }

        public S Key => _key;
    }
}