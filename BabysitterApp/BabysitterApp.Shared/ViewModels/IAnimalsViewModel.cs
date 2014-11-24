using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterApp.ViewModels
{
    public interface IAnimalsViewModel
    {
        IEnumerable<AnimalViewModel> Animals { get; set; }
    }
}
