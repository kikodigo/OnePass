namespace OnePass.Domain.Data
{
    public class EstoqueItem
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public int Qtd { get; set; }
        public int QtdMin { get; set; }
        public int QtdMax { get; set; }
    }
}
