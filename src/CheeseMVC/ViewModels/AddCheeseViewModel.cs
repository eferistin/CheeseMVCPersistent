using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description")]
        public string Description { get; set; }

       // public CheeseType Type { get; set; }

       // public List<SelectListItem> CheeseTypes { get; set; }

        [Required]
        [Display(Name="Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddCheeseViewModel( IEnumerable<CheeseCategory> categories)//This will be passed in when we create a new AddCheeseViewModel in the controller, and will be a collection of all categories
         // only obtain a list via the CheeseDBContext
        {
            Categories = new List<SelectListItem>();// initializing an empty list of the Categories define in line 28
            foreach (var mycheeseCat in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = mycheeseCat.ID.ToString(),// inserting into Value, the ID that was created by the category cheese that was passed in the parameters. The ID is define in the CheeseCategory.cs 
                    Text = mycheeseCat.Name // inserting into Test, the Name of the the category that was pass inthe parameter, the Name is define in the CheeseCategory.cs 
                });

            }
            
            //CheeseTypes = new List<SelectListItem>();

            //// <option value="0">Hard</option>
            //CheeseTypes.Add(new SelectListItem {
            //    Value = ((int) CheeseType.Hard).ToString(),
            //    Text = CheeseType.Hard.ToString()
            //});

            //CheeseTypes.Add(new SelectListItem
            //{
            //    Value = ((int)CheeseType.Soft).ToString(),
            //    Text = CheeseType.Soft.ToString()
            //});

            //CheeseTypes.Add(new SelectListItem
            //{
            //    Value = ((int)CheeseType.Fake).ToString(),
            //    Text = CheeseType.Fake.ToString()
            //});

        }
        public AddCheeseViewModel() { }
    }
}
