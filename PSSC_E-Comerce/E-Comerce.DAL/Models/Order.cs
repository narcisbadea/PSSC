﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Comerce.DAL.Models;

public class Order
{
    public string Id { get; set; }
    public User User { get; set; }
    public DateTime Created { get; set; }
}