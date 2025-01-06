public class Encomenda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Estado { get; set; }
    public double Custo { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}
