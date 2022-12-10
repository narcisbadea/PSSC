using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Models;

public class OrderItem
{
    public string Id { get; set; }  
    public Order Order { get; set; }
    public Item Item { get; set; }
}
