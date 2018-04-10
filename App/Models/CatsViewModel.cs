using System.Collections.Generic;
using App.Constants;

namespace App.Models
{
    public class CatViewModel : BaseViewModel
    {
        public ICollection<Cat> Cats { get; set; }
    }

    public class Cat
    {
        public string OwnerGender { get; set; }
        public string Name { get; set; }
    }
}