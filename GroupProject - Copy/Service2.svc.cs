using HashPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GroupProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {

        DataClasses1DataContext db = new DataClasses1DataContext();

        public int Register(string name, string surname, string phone_number, string email, string password, string confirm, char type)
        {
            var hashedPassword = Secrecy.HashPassword(password);
            var tempUser = (from u in db.Users
                            where u.User_Email.Equals(email) &&
                            u.User_Password_Hash.Equals(hashedPassword)
                            select u).FirstOrDefault();
            if (tempUser == null)
            {
                // we can proceed with registering
                var objUser = new User();
                objUser.User_Name = name;
                objUser.User_Email = email;
                objUser.User_Password_Hash = hashedPassword;
                objUser.User_Type = type;
                // add user to user table
                db.Users.InsertOnSubmit(objUser);
                try
                {
                    //Successful Registration
                    db.SubmitChanges();
                    return 0;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return -1;
                }
            }
            else
            {
                // the user already exists
                return 1;
            }
        }

        public User login(string name, string email, string password)
        {
            var hashedPassword = Secrecy.HashPassword(password);
            var user = (from u in db.Users
                            where u.User_Email.Equals(email) &&
                            u.User_Password_Hash.Equals(hashedPassword)
                            select u).FirstOrDefault();
            if (user == null)
            {
                // the user does not exist
                return null;
            }
            else
            {
                // the user does exist
                return user;
            }
        }

        public Product getProduct(int prod_ID)
        {
            
            var product = (from p in db.Products 
                           where p.Product_ID.Equals(prod_ID) 
                           select p).FirstOrDefault();
           
            if(product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public List<Product> getActiveProducts(int catID)
        {
            dynamic products = (from p in db.Products 
                                where p.Product_Availability.Equals(true) && p.Category_ID.Equals(catID) 
                                select p).DefaultIfEmpty();

            if(products != null)
            {
                List<Product> activeProducts = new List<Product>();
                Product product = null;

                foreach (Product np in products)
                {
                    product = new Product
                    {
                        Product_ID = np.Product_ID,
                        Product_Availability = np.Product_Availability,
                        Product_Brand = np.Product_Brand,
                        Product_Name = np.Product_Name,
                        Product_Price = np.Product_Price,
                        Product_Quantity = np.Product_Quantity,
                        Product_Updated_At = np.Product_Updated_At,                 
                        Category_ID = np.Category_ID
                    };

                    activeProducts.Add(product);
                }

                return activeProducts;
            }
            else
            {
                return null;
            }
        }



        public bool isProdAdded(int Category_ID, string product_name, string product_brand, decimal product_price, int product_quantity, bool product_availability, DateTime product_UpdatedAt)
        {
            {
                Product newProduct = new Product
                {
                    Product_Name = product_name,
                    Product_Availability = product_availability,
                    Product_Brand = product_brand,
                    Product_Price = product_price,
                    Product_Quantity = product_quantity,
                    Product_Updated_At = product_UpdatedAt
                };

                try
                {
                    db.Products.InsertOnSubmit(newProduct);
                    db.SubmitChanges();

                    return true;
                }
                catch (Exception x)
                {
                    return false;
                }
            }
    }
}
