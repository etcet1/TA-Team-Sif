using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

using BabysitterApp;
using System.Windows.Input;

namespace BabysitterApp.ViewModels
{
    public class AnimalsViewModel : ViewModelBase, IAnimalsViewModel
    {
        private ObservableCollection<AnimalViewModel> animals;

        public IEnumerable<AnimalViewModel> Animals
        {
            get
            {
                return this.animals;
            }
            set
            {
                if (this.animals == null)
                {
                    this.animals = new ObservableCollection<AnimalViewModel>();
                }
                this.animals.Clear();
                this.animals.AddRange(value);
                this.SelectedAnimal = this.animals.First();
            }
        }

        public AnimalViewModel NewAnimal { get; set; }

        public AnimalViewModel SelectedAnimal
        {
            get
            {
                return this.selectedAnimal;
            }
            set
            {
                this.selectedAnimal = value;
                this.OnPropertyChanged("SelectedAnimal");
            }
        }

        public ICommand SaveNewAnimal
        {
            get
            {
                if (this.saveNewAnimalCommand == null)
                {
                    this.SaveNewAnimal = new DelegateCommand(execute: this.PerformSaveNewAnimal);
                }
                return this.saveNewAnimalCommand;
            }
            set
            {
                this.saveNewAnimalCommand = value;
            }
        }

        public AnimalsViewModel()
        {
            this.Animals = new AnimalViewModel[]
            {
                new AnimalViewModel("Sheep", "/Assets/Images/sheep.png", "Sample"),
                new AnimalViewModel("Donkey", "/Assets/Images/donkey.png", "Sample")
            };
        }

        public void AddRandomAnimal()
        {
            this.animals.Add(this.GetRandomAnimal());
        }

        public void PerformSaveNewAnimal()
        {
            var b = 5;
        }

        static Random rand = new Random();

        private AnimalViewModel selectedAnimal;
        private ICommand saveNewAnimalCommand;

        private AnimalViewModel GetRandomAnimal()
        {
            return new AnimalViewModel("Phone #" + rand.Next(),
                "Model #" + rand.Next(), "Sound");
        }
    }
}
