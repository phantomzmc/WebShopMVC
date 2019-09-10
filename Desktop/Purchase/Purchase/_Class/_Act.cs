using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _Act
    {
        public int ID { get; set; }
        public string ActNo { get; set; }
        public decimal Price { get; set; }
        public string Free { get; set; }

        public _Act()
        {
            this.ID = 0;
            this.ActNo = string.Empty;
            this.Price = 0;
            this.Free = "N";
        }
    }
}