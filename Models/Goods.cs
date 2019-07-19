namespace Bakery.Goods
{
  class Breads
  {
    public string Bread { get; set; }
    public int BreadCost { get; set; }

    public Breads()
    {
      Bread = "bread";
      BreadCost = 5;
    }
  }

  class Pastries
  {
    public string Pastry { get; set; }
    public int PastryCost { get; set; }

    public Pastries()
    {
      Pastry = "pastry";
      PastryCost = 2;
    }

  }
}