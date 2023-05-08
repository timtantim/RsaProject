namespace RsaProject.Model
{
    public class Bom
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string MaterialId { get; set; }
        public string Description { get; set; }
        public int ParentNode { get; set; }
        public bool isHead { get; set; }
    }
}
