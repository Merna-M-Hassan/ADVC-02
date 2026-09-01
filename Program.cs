namespace Assignment_11_C__Adv
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Product> catalog = new()
            {
            new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
            new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
            new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
            new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
            new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
            new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
            new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
            new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
            new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
            new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };


            // 1. All Electronics products
            List<Product> electronics = Product.SearchProducts(catalog, p => p.Category == "Electronics");
            Console.WriteLine("----- Electronics Products -----");
            Product.PrintProducts(electronics);

            Console.WriteLine();

            // 2. Products cheaper than $50
            List<Product> cheapProducts =Product.SearchProducts(catalog, p => p.Price < 50);
            Console.WriteLine("----- Products Cheaper Than $50 -----");
            Product.PrintProducts(cheapProducts);

            Console.WriteLine();

            // 3. Products that are in stock (Stock > 0)
            List<Product> inStockProducts = Product.SearchProducts(catalog, p => p.Stock > 0);
            Console.WriteLine("----- Products In Stock -----");
            Product.PrintProducts(inStockProducts);

            Console.WriteLine();

            // 4. Clothing products under $100
            List<Product> clothingUnder100 = Product.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            Console.WriteLine("----- Clothing Products Under $100 -----");
           Product. PrintProducts(clothingUnder100);

            Console.WriteLine("\n*********************************\n");

            Console.WriteLine("--- Short Report ---");
            Product.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine();

            Console.WriteLine("--- Detailed Report ---");
            Product.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

            Console.WriteLine("\n*********************************\n");

            Console.WriteLine("---  Summary List ---");
            List<string> summaries = Product.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");

            // Print each transformed string
            foreach (string summary in summaries)
            {
                Console.WriteLine(summary);
            }

            Console.WriteLine();

            Console.WriteLine("--- Price Label ---");
            List<string> priceLabels = Product.TransformProducts(catalog, p =>
            {
                string label = p.Price > 100 ? "Expensive!" : "Affordable";
                return $"{p.Name}: {label}";
            });

            foreach (string label in priceLabels)
            {
                Console.WriteLine(label);
            }

            Console.WriteLine("\n*********************************\n");

            Console.WriteLine("--- Low Stock Alert ---");
            List<Product> lowStockProducts = Product.FilterProducts(catalog, p => p.Stock < 20);

            // Print alerts for each low-stock product
            foreach (Product product in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
            }


        }
    }
}
