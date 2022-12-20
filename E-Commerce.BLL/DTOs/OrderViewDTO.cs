using E_Commerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BLL.DTOs;

public class OrderViewDTO
{
    public string Id { get; set; }
    public string User { get; set; }
    public string Status { get; set; }
    public DateTime Created { get; set; }
}
