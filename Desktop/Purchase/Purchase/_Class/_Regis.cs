using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _Regis
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Free { get; set; }

        public _Regis()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Price = 0;
            this.Free = "N";
        }
    }
}