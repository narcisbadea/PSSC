using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs;

public class ItemResponseDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ItemType { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
