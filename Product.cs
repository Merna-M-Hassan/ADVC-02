using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_11_C__Adv
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } // "Electronics", "Clothing", "Food", "Books"
        public double Price { get; set; }
        public int Stock { get; set; }


        //search method that filters products based on a condition
        public static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            //Creates an empty list to store results
            List<Product> result = new List<Product>();

            // Iterate through each product in the catalog
            foreach (Product product in products)
            {
                // If the product satisfies the filter condition, add it to results
                if (filter(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }

        // Helper method to display products in a readable format
       public static void PrintProducts(List<Product> products)
        {
            foreach (Product p in products)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
        }


        //////////////////////////////////////////////////////////////////////
        

        //Prints a report by applying the provided action to each product
        public static void PrintReport(List<Product> products, Action<Product> printAction)
        {
            // Loop through each product in the catalog
            foreach (Product product in products)
            {
                // Execute the action on the current product
                // The caller decides what this action does!
                printAction(product);
            }
        }

        //////////////////////////////////////////////////////////////////////

        // Transforms each product in the list using the provided function
       public static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transform)
        {
            // a new list to store the transformed results
            List<TResult> result = new List<TResult>();

            // Loop through each product in the catalog
            foreach (Product product in products)
            {
                // Apply the transform function to the product and add to results
                TResult transformedItem = transform(product);
                result.Add(transformedItem);
            }

            return result;
        }

        //////////////////////////////////////////////////////////////////////

        public static List<Product> FilterProducts(List<Product> products, Predicate<Product> match)
        {
          
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (match(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
    }
}
