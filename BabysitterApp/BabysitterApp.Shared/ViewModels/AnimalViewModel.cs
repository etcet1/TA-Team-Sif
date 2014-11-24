using System;
using System.Collections.Generic;
using System.Text;

namespace BabysitterApp.ViewModels
{
    public class AnimalViewModel
    {
            public string Name { get; set; }
            public string Image { get; set; }
            public string Sound { get; set; }


            public AnimalViewModel(string name, string image, string sound)
            {
                this.Name = name;
                this.Image = image;
                this.Sound = sound;
            }
        }
    }
