﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardAbast.Shared.StandarizedDbModel
{
    [NotMapped]
    public class StProveedor
    {
        [Key]
        public string Rut { get; set; }
        public string? Nombre { get; set; }
    }
}
