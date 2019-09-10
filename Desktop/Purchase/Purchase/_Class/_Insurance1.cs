using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using NoomLibrary;

namespace Purchase
{
    public class _Insurance1
    {
        public int ID { get; set; }
        public _InsuranceList._Insurance _Insurane { get; set; }
        public decimal Outlay { get; set; }
        public decimal Price { get; set; }
        public string Free { get; set; }

        public _Insurance1()
        {
            this.ID = 0;
            this._Insurane = new _InsuranceList._Insurance();
            this.Outlay = 0;
            this.Price = 0;
            this.Free = "N";
        }
    }
}