using Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Objects
{
    public class Product
    {
        public int Id { get; private set; }
        public string Articul { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Unit { get; private set; }
        public int Sale { get; private set; }
        public int Count { get; private set; }
        public int ProviderId { get; private set; }
        public string Provider {  get; private set; }
        public int ProducerId { get; private set; }
        public string Producer { get; private set; }
        public int CategoryId { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public string FotoPath { get; private set; } = "C:\\Users\\leraa\\Documents\\лера_демо\\приложение\\Demo\\Resuources\\";
        public Product(int id, string articul, string name, int price, string unit, int sale, int count, int providerId, int producerId, int categoryId, string description, string fotoName)
        {
            this.Id = id;
            this.Articul = articul;
            this.Name = name;
            this.Price = price;
            this.Unit = unit;
            this.Sale = sale;
            this.Count = count;
            this.ProviderId = providerId;
            this.ProducerId = producerId;
            this.CategoryId = categoryId;
            this.Description = description;
            this.FotoPath += fotoName;

            Database.OpenConnection();
            Database.SetQuery("SELECT наименование FROM Поставщики WHERE id_поставщика=@providerId");
            Database.AddParameter("providerId", providerId);
            object provider = Database.ExecuteScalar();
            if (provider != null && provider != DBNull.Value)
            {
                this.Provider = provider.ToString();
            }
            Database.ClearParameters();

            Database.SetQuery("SELECT наименование FROM Производители WHERE id_производителя=@producerId");
            Database.AddParameter("producerId", producerId);
            object producer = Database.ExecuteScalar();
            if (producer != null && producer != DBNull.Value)
            {
                this.Producer = producer.ToString();
            }
            Database.ClearParameters();

            Database.SetQuery("SELECT наименование FROM Категории WHERE id_категории=@categoryId");
            Database.AddParameter("@categoryId", categoryId);
            object category = Database.ExecuteScalar();
            if (category != null && category != DBNull.Value)
            {
                this.Category = category.ToString();
            }
            Database.ClearParameters();

            Database.CloseConnection();
        }
    }
}
