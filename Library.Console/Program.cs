using Library.Entities;
using System.ComponentModel;
using System.Text;

public class program
{
    public static readonly List<Category> categories = new List<Category>();   
    public static void Main(string[] args)
    {

        StringBuilder menu = new();
        menu.AppendLine("1)Add Category");
        menu.AppendLine("2)Category List");


        for (; ; )
        {
            Console.WriteLine(menu);
            var item = Console.ReadLine();
            Console.Clear();

            switch (item)
            {
                case "1":
                    {
                        Console.WriteLine("Please enter category title");
                        var title = Console.ReadLine();
                        var catDto = new Category
                        {
                            Title = title
                        };
                        categories.Add(catDto);
                        break;
                    }
                case "2":
                    {
                        foreach (var cat in categories)
                        {
                            Console.WriteLine(cat.Title);
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}

public class GetCategoryDto
{
    public string Title { get; set; }

}

public class AddCategoryDto
{
    public string Title { get; set; }

}
