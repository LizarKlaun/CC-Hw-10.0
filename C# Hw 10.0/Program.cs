namespace CollectionsHw
{
    internal class Program
    {
        class Product
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            List<Product> products = new List<Product>
            {
                new Product { Name = "Ноуттбук", Price = 25000, Category = "Електроніка" },
                new Product { Name = "Смартфон", Price = 15000, Category = "Електроніка" },
                new Product { Name = "Холодильник", Price = 30000, Category = "Побутова техніка" },
                new Product { Name = "Праска", Price = 2000, Category = "Побутова техніка" },
                new Product { Name = "Книга", Price = 500, Category = "Книги" },
                new Product { Name = "Навушники", Price = 3000, Category = "Електроніка" }
            };

            Console.WriteLine("Всі товари:");
            products.ForEach(p => Console.WriteLine($"{p.Id} | {p.Name} | {p.Price} грн | {p.Category}"));

            Console.Write("Введіть назву товару для пошуку: ");
            string searchName = Console.ReadLine();
            var foundProduct = products.FirstOrDefault(p => p.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(foundProduct != null ? $"Знайдено: {foundProduct.Name} - {foundProduct.Price} грн" : "Товар не знайдено");

            Console.Write("Введіть категорію для фільтрації: ");
            string searchCategory = Console.ReadLine();
            var filteredProducts = products.Where(p => p.Category.Equals(searchCategory, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Товари у цій категорії:");
            foreach (var product in filteredProducts)
                Console.WriteLine($"{product.Name} - {product.Price} грн");

            var mostExpensive = products.OrderByDescending(p => p.Price).First();
            Console.WriteLine($"Найдорожчий товар: {mostExpensive.Name} - {mostExpensive.Price} грн");

            Console.Write("Введіть Id товару для видалення: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid deleteId))
            {
                var productToRemove = products.FirstOrDefault(p => p.Id == deleteId);
                if (productToRemove != null)
                {
                    products.Remove(productToRemove);
                    Console.WriteLine("Товар видалено!");
                }
                else Console.WriteLine("Товар не знайдено!");
            }

            Console.WriteLine("Товари за зростанням ціни:");
            foreach (var product in products.OrderBy(p => p.Price))
                Console.WriteLine($"{product.Name} - {product.Price} грн");

            Console.Write("Введіть Id товару для зміни ціни: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid editId))
            {
                var productToEdit = products.FirstOrDefault(p => p.Id == editId);
                if (productToEdit != null)
                {
                    Console.Write("Введіть нову ціну: ");
                    if (double.TryParse(Console.ReadLine(), out double newPrice))
                    {
                        productToEdit.Price = newPrice;
                        Console.WriteLine("Ціну змінено!");
                    }
                    else Console.WriteLine("Некоректне значення ціни!");
                }
                else Console.WriteLine("Товар не знайдено!");
            }
        }
    }
}