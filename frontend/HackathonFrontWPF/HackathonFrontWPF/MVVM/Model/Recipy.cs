using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonFrontWPF.MVVM.Model
{
    public class Recipy
    {
        public int Time { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image_path { get; set; }
        public ArrayList? Ingredients_arr { get; set; }
        public float? Price { get; set; }
        public string? Category { get; set; }
        // create class constructor
        public Recipy(int time, string? name, string? description, string? image_path, ArrayList? ingredients_arr, float? price, string? category)
        {
            Time = time;
            Name = name;
            Description = description;
            Image_path = image_path;
            Ingredients_arr = ingredients_arr;
            Price = price;
            Category = category;
        }

        // create a function to add new Ingredient to the Ingredients_arr
        public void Add_Ingredient(object ingredient)
        {
            if (ingredient == null)
            {
                return;
            }
            if (Ingredients_arr == null)
            {
                Ingredients_arr = new ArrayList();
            }
            Ingredients_arr.Add(ingredient);
        }


    }
}
