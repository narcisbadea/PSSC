using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs;

public class ItemInOrderDTO
{
    public string ItemId { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
}
