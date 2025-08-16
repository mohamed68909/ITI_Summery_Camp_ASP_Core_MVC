using System;

namespace Task_2
{
   
    enum Category
    {
        Electronics,
        Clothing,
        Food,
        Books
    }

   
    struct Size
    {
        public double Width;
        public double Height;
        public double Depth;

        public Size(double width, double height, double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public override string ToString()
        {
            return $"{Width} x {Height} x {Depth} cm";
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public Size ProductSize { get; set; }

       
        public Product(int id, string name, Category category, double price, Size productSize)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            ProductSize = productSize;
        }

       
        public void DisplayInfo()
        {
            Console.WriteLine($"Product: {Name}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Size: {ProductSize}");
            Console.WriteLine();
        }
    }

    class Program
    {
     
        static double GetTotalPrice(Product[] products)
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total;
        }

       
        static Product GetMostExpensiveProduct(Product[] products)
        {
            Product mostExpensive = products[0];
            foreach (var product in products)
            {
                if (product.Price > mostExpensive.Price)
                {
                    mostExpensive = product;
                }
            }
            return mostExpensive;
        }

        static void Main(string[] args)
        {
            
            Product[] products = new Product[3];

            products[0] = new Product(1, "Laptop", Category.Electronics, 15000, new Size(35, 25, 2));
            products[1] = new Product(2, "T-shirt", Category.Clothing, 300, new Size(40, 60, 1));
            products[2] = new Product(3, "Book", Category.Books, 150, new Size(21, 29, 2));

            // Displaying all products
            foreach (var product in products)
            {
                product.DisplayInfo();
            }

            // Display total price
            double totalPrice = GetTotalPrice(products);
            Console.WriteLine($"Total Price: {totalPrice}");

            // Display most expensive product
            Product topProduct = GetMostExpensiveProduct(products);
            Console.WriteLine($"\nMost Expensive Product: {topProduct.Name}");
        }
    }
}
