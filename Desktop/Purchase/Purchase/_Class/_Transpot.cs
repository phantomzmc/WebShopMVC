using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _Transpot
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public string Free { get; set; }

        public _Transpot()
        {
            this.ID = 0;
            this.Price = 0;
            this.Free = "N";
        }
    }
}