using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonFrontWPF.MVVM.Model
{
    public class Ingredient
    {
        public string? Name { get; set; }
        public string? Image_path { get; set; }
        public float? Price { get; set; }
        public float? Quantity { get; set; }

        public Ingredient(string? name, string? image_path, float? price, float? quantity)
        {
            Name = name;
            Image_path = image_path;
            Price = price;
            Quantity = quantity;
        }
    }
}
