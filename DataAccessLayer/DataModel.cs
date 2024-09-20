using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region CATEGORY METOT

        public List<Categories> GetCategories()
        {
            List<Categories> categories = new List<Categories>();
            try
            {
                cmd.CommandText = "SELECT ID, Name FROM PurchasingCategories";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories c = new Categories() { ID = reader.GetInt32(0), Name = reader.GetString(1) };
                    categories.Add(c);
                }
                return categories;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Categories AddCategory(Categories model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO PurchasingCategories(Name) VALUES(@categoryName) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categoryName", model.Name);
                con.Open();
                model.ID = Convert.ToInt32(cmd.ExecuteScalar());
                return model;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public Categories GetCategory(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Name FROM PurchasingCategories WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Categories c = new Categories();
                while (reader.Read())
                {
                    c.ID = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                }
                return c;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool UpdateCategory(Categories model)
        {
            try
            {
                cmd.CommandText = "UPDATE PurchasingCategories SET Name = @categoryName WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", model.ID);
                cmd.Parameters.AddWithValue("@categoryName", model.Name);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public void RemoveCategory(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM PurchasingCategories WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region DEPARTMENT METOT

        public Departments AddDepartment(Departments model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO PurchasingDepartments(Name) VALUES(@Name) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                con.Open();
                model.ID = Convert.ToInt32(cmd.ExecuteScalar());
                return model;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Departments> DepartmentList()
        {
            List<Departments> department = new List<Departments>();
            try
            {
                cmd.CommandText = "SELECT ID, Name FROM PurchasingDepartments";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Departments model = new Departments();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    department.Add(model);
                }
                return department;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region SUPPLIER METOT

        public List<Suppliers> SupplierList()
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            try
            {
                cmd.CommandText = "SELECT ID, Name FROM PurchasingSuppliers";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Suppliers model = new Suppliers();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    suppliers.Add(model);
                }
                return suppliers;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Suppliers AddSupplier(Suppliers model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO PurchasingSuppliers(Name) VALUES(@Name) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", model.Name);
                con.Open();
                model.ID = Convert.ToInt32(cmd.ExecuteScalar());
                return model;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region EMPLOYEE METOT

        public Employee GetEmployee(int id)
        {
            try
            {
                Employee model = new Employee();
                cmd.CommandText = "SELECT ID, Name, Username, Password FROM PurchasingEmployee WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    model.Username = reader.GetString(2);
                    model.Password = reader.GetString(3);
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Employee EmployeeLogin(string username, string password)
        {
            Employee model = new Employee();
            try
            {
                cmd.CommandText = "SELECT ID FROM PurchasingEmployee WHERE Username=@userName AND Password = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    model = GetEmployee(id);
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region INCOMING PRODUCT METOT

        public List<IncomingProducts> IncomingProductList()
        {
            List<IncomingProducts> incomingProducts = new List<IncomingProducts>();
            try
            {
                cmd.CommandText = "SELECT ip.ID, ip.Date, c.Name, m.Name, ip.Quantity, ip.UnitPrice, ip.Total, ex.Name, ip.TurkishLiraEquivalent, d.Name, s.Name " +
                                  "FROM PurchasingIncomingProducts AS ip " +
                                  "JOIN PurchasingCategories AS c ON c.ID = ip.CategoryID " +
                                  "JOIN PurchasingMaterials AS m ON m.ID = ip.MaterialDescriptionID " +
                                  "JOIN PurchasingDepartments AS d ON d.ID = ip.DepartmentID " +
                                  "JOIN PurchasingExchangeRate AS ex ON ex.ID = ip.ExchangeRateID " +
                                  "JOIN PurchasingSuppliers AS s ON s.ID = ip.SupplierID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IncomingProducts model = new IncomingProducts
                    {
                        ID = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Category = reader.GetString(2),
                        MaterialDescription = reader.GetString(3),
                        Quantity = reader.GetDecimal(4),
                        UnitPrice = reader.GetDecimal(5),
                        Total = reader.GetDecimal(6),
                        ExchangeRate = reader.GetString(7),
                        TurkishLiraEquivalent = reader.GetDecimal(8),
                        Department = reader.GetString(9),
                        Supplier = reader.GetString(10)
                    };
                    incomingProducts.Add(model);
                }
                return incomingProducts;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public IncomingProducts AddIncomingProduct(IncomingProducts model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO PurchasingIncomingProducts(Date, CategoryID, MaterialDescriptionID, ExchangeRateID, TurkishLiraEquivalent, Quantity, UnitPrice, Total, DepartmentID, SupplierID) " +
                                  "VALUES(@date, @catid, @mdesc, @ExchangeRateID, @TurkishLiraEquivalent, @quantity, @unit, @total, @depid, @supid); " +
                                  "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@date", model.Date);
                cmd.Parameters.AddWithValue("@catid", (object)model.CategoryID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@mdesc", (object)model.MaterialDescriptionID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ExchangeRateID", model.ExchangeRateID);
                cmd.Parameters.AddWithValue("@TurkishLiraEquivalent", model.TurkishLiraEquivalent);
                cmd.Parameters.AddWithValue("@quantity", model.Quantity);
                cmd.Parameters.AddWithValue("@unit", model.UnitPrice);
                cmd.Parameters.AddWithValue("@total", model.Total);
                cmd.Parameters.AddWithValue("@depid", (object)model.DepartmentID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@supid", (object)model.SupplierID ?? DBNull.Value);
                con.Open();
                model.ID = Convert.ToInt32(cmd.ExecuteScalar());
                return model;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetFilteredIncomingProducts(DateTime? searchDate, int? categoryId, int? supplierId, int? departmentId)
        {
            // Dinamik SQL sorgusu oluşturma
            StringBuilder query = new StringBuilder();
            query.Append("SELECT ip.ID, ip.Date, c.Name AS CategoryName, m.Name AS MaterialName, ip.Quantity, ip.UnitPrice, ip.Total, d.Name AS DepartmentName, s.Name AS SupplierName ");
            query.Append("FROM PurchasingIncomingProducts AS ip ");
            query.Append("JOIN PurchasingMaterials AS m ON m.ID = ip.MaterialDescriptionID ");
            query.Append("JOIN PurchasingCategories AS c ON c.ID = ip.CategoryID ");
            query.Append("JOIN PurchasingDepartments AS d ON d.ID = ip.DepartmentID ");
            query.Append("JOIN PurchasingSuppliers AS s ON s.ID = ip.SupplierID ");
            query.Append("WHERE 1=1"); // Koşul eklemek için temel

            // Dinamik olarak filtreleri ekleyin
            if (searchDate.HasValue)
            {
                query.Append(" AND CAST(ip.Date AS DATE) = @date"); // Tarih kısmını karşılaştır
            }

            if (categoryId.HasValue)
            {
                query.Append(" AND ip.CategoryID = @catid");
            }

            if (supplierId.HasValue)
            {
                query.Append(" AND ip.SupplierID = @supid");
            }

            if (departmentId.HasValue)
            {
                query.Append(" AND ip.DepartmentID = @depid");
            }

            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(query.ToString(), con))
                {
                    cmd.Parameters.Clear();

                    // Parametreleri ekleyin
                    if (searchDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@date", searchDate.Value.Date); // Tarih kısmını ekleyin
                    }

                    if (categoryId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@catid", categoryId.Value);
                    }

                    if (supplierId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@supid", supplierId.Value);
                    }

                    if (departmentId.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@depid", departmentId.Value);
                    }

                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi (örneğin, loglama veya mesaj gösterme)
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return dt;
        }

        #endregion

        #region MATERIAL METOT
        public List<Materials> MaterialList()
        {
            List<Materials> department = new List<Materials>();
            try
            {
                cmd.CommandText = "SELECT ID, Name FROM PurchasingMaterials";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materials model = new Materials();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    department.Add(model);
                }
                return department;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public int AddMaterial(string materialDescription)
        {
            try
            {
                // Önce malzemenin zaten mevcut olup olmadığını kontrol edin
                cmd.CommandText = "SELECT ID FROM PurchasingMaterials WHERE Name = @materialDescription";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@materialDescription", materialDescription);
                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // Malzeme zaten mevcut, ID'sini döndür
                    return Convert.ToInt32(result);
                }

                // Malzeme mevcut değil, yeni malzeme ekle
                cmd.CommandText = "INSERT INTO PurchasingMaterials(Name) VALUES(@materialDescription); SELECT SCOPE_IDENTITY();";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@materialDescription", materialDescription);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                return newId;
            }
            catch (Exception ex)
            {
                // Hata mesajını daha detaylı bir şekilde loglayabilir veya kullanıcıya gösterebilirsiniz
                Console.WriteLine($"Hata: {ex.Message}");
                return -1; // Hata durumunda -1 döndür
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region EXCHANGE RATE METOT
        public List<ExchangeRate> ExchangeList()
        {
            List<ExchangeRate> exchanges = new List<ExchangeRate>();
            try
            {
                cmd.CommandText = "SELECT ID, Name FROM PurchasingExchangeRate";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeRate model = new ExchangeRate();
                    model.ID = reader.GetInt32(0);
                    model.Name = reader.GetString(1);
                    exchanges.Add(model);
                }
                return exchanges;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        private static readonly HttpClient client = new HttpClient();

        // Döviz kurlarını API'den almak için metod
        public async Task<decimal> GetExchangeRateAsync(string currencyCode)
        {
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";
            decimal exchangeRate = 0;

            try
            {
                // API'den veriyi al
                string response = await client.GetStringAsync(url);

                // XML verisini parse et
                XDocument xml = XDocument.Parse(response);
                XElement currencyElement = xml.Descendants("Currency")
                                              .FirstOrDefault(e => e.Attribute("CurrencyCode")?.Value == currencyCode);

                if (currencyElement != null)
                {
                    string exchangeRateString = currencyElement.Element("BanknoteBuying")?.Value;
                    if (decimal.TryParse(exchangeRateString, out decimal rate))
                    {
                        exchangeRate = rate;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine("Kuru alırken hata oluştu: " + ex.Message);
            }

            return exchangeRate;
        }


        #endregion
    }
}
