using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Models;

public class Item
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ItemType ItemType { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
