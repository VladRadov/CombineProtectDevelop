public interface IProduct
{
    string Name { get; set; }
    string Description { get; set; }
    ICurrency Price { get; }
    TypeGroupProducts GroupProduct { get; set; }
}
