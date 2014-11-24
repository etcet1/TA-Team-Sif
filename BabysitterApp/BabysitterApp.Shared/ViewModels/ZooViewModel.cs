using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterApp.ViewModels
{
    public class ZooViewModel
    {
        public ZooViewModel()
            : this(new AnimalsViewModel())
        {
        }

        public ZooViewModel(IAnimalsViewModel animalsViewModel)
        {
            this.AnimalsViewModel = animalsViewModel;
        }

        public IAnimalsViewModel AnimalsViewModel { get; set; }
    }
}
