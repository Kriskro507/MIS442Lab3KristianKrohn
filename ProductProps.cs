using System;
using System.Collections.Generic;
using System.Text;

using MMABooksTools;
using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace MMABooksProps
{
    [Serializable]

    public class ProductProps : IBaseProps
    {

        //properties for products
        #region Auto-implemented Properties
        public string ProductCode { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal UnitPrice { get; set; } = 0.0m;
        public int OnHandQuantity { get; set; } = 0;

        /// <summary>
        /// ConcurrencyID. Don't manipulate directly.
        /// </summary>
        public int ConcurrencyID { get; set; } = 0;
        #endregion



        public object Clone()
        {
            ProductProps p = new ProductProps();
            p.ProductCode = this.ProductCode;
            p.Description = this.Description;
            p.UnitPrice = this.UnitPrice;
            p.OnHandQuantity = this.OnHandQuantity;

            p.ConcurrencyID = this.ConcurrencyID;
            return p;
        }

        public string GetState()
        {
            string jsonString;
            jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

        public void SetState(string jsonString)
        {
            ProductProps p = JsonSerializer.Deserialize<ProductProps>(jsonString);
            this.ProductCode = p.ProductCode;
            this.Description = p.Description;
            this.UnitPrice = p.UnitPrice;
            this.OnHandQuantity = p.OnHandQuantity;

            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.ProductCode = (string)dr["ProductCode"];
            this.Description = (string)dr["Description"];
            this.UnitPrice = (int)dr["UnitPrice"];
            this.OnHandQuantity = (int)dr["OnHandQuantity"];

            this.ConcurrencyID = (Int32)dr["ConcurrencyID"];
        }
    }
}