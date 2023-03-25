using System.Text;

public class Bouquet
{
    public string Pack { get; set; }
    public string Tape { get; set; }
    public double Size { get; set; }
    public int NumberFlowers{ get; set; }
    public string Name { get; set; }
}
public class ProductBouquet
{

    public string BodyPart { get; set; }

    public override string ToString() =>
        new StringBuilder()

        .AppendLine(BodyPart)
        .ToString();
}
public interface ProductBouquetBuilder
{

    void BuildBody();


}
public class ProductBouquetBuilder : ProducBouquetBuilder
{
    private ProducBouquet _producBouquet;
    private IEnumerable<Product> _products;

    public ProducBouquetBuilder(IEnumerable<Product> products)
    {
        _products = products;
        _productBouquet = new ProducBouquet();
    }



    public void BuildBody()
    {
        _producBouquet.BodyPart = string.Join(Environment.NewLine, _products.Select(p => $"\nProduct name: {p.Name}," +
        $" \nproduct pack: {p.pack} , \nproduct size: {p.size}, \nproduct tape: {p.tape} , \nproduct FlowersBouquet: {p.FlowersBouquet}"));
    }



    public ProductFlowersBouquet GetReport()
    {
        var productFlowersBouquet = _productFlowersBouquet;
        Clear();
        return productFlowersBouquet;
    }

    private void Clear() => _productFlowersBouquet = new ProductFlowersBouquet();
}
public class ProductFlowersBouquetDirector
{
    private readonly ProductFlowersBouquetBuilder _productFlowersBouquetBuilder;

    public ProductFlowersBouquetDirector(IProductFlowersBouquetBuilder productFlowersBouquetBuilder)
    {
        _productFlowersBouquetBuilder = productFlowersBouquetBuilder;
    }

    public void BuildFlowersBouquet()
    {

        _productFlowersBouquetBuilder.BuildBody();

    }
}
class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new FlowersBouquet { Name = "Rose", Pack = "blue" ,size = 20, Tape = "green" ,NumberFlowers = 7 },
            new FlowersBouquet { Name = "Chamomile", Pack = "gold",size = 30 , Tape = "black", NumberFlowers = 9},
            new FlowersBouquet { Name = "Orchids", Pack = "white",size = 30 , Tape = "red", NumberFlowers = 3}

        };
       


        var builder = new ProductFlowersBouquetBuilder(products);
        var director = new ProductFlowersBouquetDirector(builder);
        director.BuildFlowersBouquet();

        var report = builder.GetReport();
        Console.WriteLine(report);
    }
}