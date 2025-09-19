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

            if (product != null)
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

            if (products != null)
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

        public bool editProduct(Product product)
        {
            var prod = (from p in db.Products 
                        where p.Product_Name.Equals(product.Product_Name) && p.Product_Image.Equals(product.Product_Image) 
                        select p).FirstOrDefault();

            if(prod != null)
            {
                try
                {
                    db.Products.InsertOnSubmit(prod);
                    db.SubmitChanges();

                    return true;
                }
                catch(Exception x)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Invoice getInvoice(int invoice_id)
        {
            var inv = (from i in db.Invoices 
                       where i.Invoice_ID.Equals(invoice_id)
                       select i).FirstOrDefault();

            //
            if(inv != null)
            {
                return inv;
            }
            else
            {
                return null;
            }
        }

        public List<Invoice> getInvoices(int Customer_ID)
        {
            dynamic invoices = (from i in db.Invoices
                                where i.Customer_ID.Equals(Customer_ID)
                                select i).DefaultIfEmpty();

            List<Invoice> newInvoices = new List<Invoice>();
            Invoice inv;

            if(invoices != null)
            {
                foreach(Invoice i in invoices)
                {
                    inv = new Invoice
                    {
                        Invoice_ID = i.Invoice_ID,
                        Invoicelines = i.Invoicelines,
                        Invoice_Created_Date = i.Invoice_Created_Date
                    };

                    newInvoices.Add(inv);
                }

                return newInvoices;
            }
            else
            {
                return null;
            }
        }

        public bool addInvoice(int customer_ID)
        {
            var inv = new Invoice
            {
                Invoice_Created_Date = DateTime.Now,
                Customer_ID = customer_ID
            };

            try
            {
                db.Invoices.InsertOnSubmit(inv);
                db.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool addInvoiceLine(int invoice_id, int product_id, int invoiceline_quantity)
        {
            var invLine = new Invoiceline
            {
                Invoice_ID = invoice_id,
                Invoiceline_Quantity = invoiceline_quantity,
                Product_ID = product_id
            };

            try
            {
                db.Invoicelines.InsertOnSubmit(invLine);
                db.SubmitChanges();

                return true;
            }
            catch(Exception x)
            {
                return false;
            }
        }

        public bool addCard(string card_acc, int Customer_ID, string card_number, string card_cvv, DateTime exp_date, int card_isActive)
        {
            var objCard = (from c in db.Cards
                           where c.Card_Acc_Number.Equals(card_acc) &&
                           c.Customer_ID.Equals(Customer_ID) &&
                           c.Card_Sec_Code.Equals(card_cvv)
                           select c).FirstOrDefault();

            if (objCard == null)
            {
                //adding card if it does not exist
                var TempCard = new Card
                {
                    Card_Acc_Number = card_acc,
                    Customer_ID = Customer_ID,
                    Card_Number = card_number,
                    Card_Sec_Code = card_cvv,
                    Card_Exp_date = exp_date,

                };

                //add card to database
                try
                {

                    db.Cards.InsertOnSubmit(TempCard);
                    //notify databse of changes
                    db.SubmitChanges();

                    return true;
                }
                catch (Exception x)
                {
                    x.GetBaseException();
                    return false;
                }

            }
            else 
            {
                //if card does exist
                return false;
            }
        }

        public List<Invoiceline> getIvoiceLineItems(int inv_id)
        {
            dynamic lineItems = (from i in db.Invoicelines
                                where i.Invoice_ID.Equals(inv_id)
                                select i).DefaultIfEmpty();

            List<Invoiceline> newLineItems = new List<Invoiceline>();
            Invoiceline inv;

            if (lineItems != null)
            {
                foreach (Invoiceline i in lineItems)
                {
                    inv = new Invoiceline
                    {
                       Invoiceline_ID = i.Invoiceline_ID,
                       Invoiceline_Quantity = i.Invoiceline_Quantity,
                       Invoice_ID = i.Invoice_ID,
                       Product_ID = i.Product_ID
                    };

                    newLineItems.Add(inv);
                }

               
                return lineItems;
            }
            else
            {
                return null;
            }
        }

        public bool addOrder(int customer_id, bool order_Delivery_Staus)
        {
            var order = new Order
            {
                Customer_ID = customer_id,
                Order_Delivery_Status = order_Delivery_Staus,
                Order_Date = DateTime.Now
            };

            try
            {
                db.Orders.InsertOnSubmit(order);
                db.SubmitChanges();

                return true;
            }
            catch(Exception x)
            {
                return false;
            }
        }

        public Order getOrder(int order_id)
        {
            var order = (from u in db.Orders 
                         where u.Order_ID.Equals(order_id) 
                         select u).FirstOrDefault();

            if(order != null)
            {
                return order;
            }
            else
            {
                return null;
            }
        }

        public List<Order> getOrders()
        {
            dynamic orders= (from o in db.Orders
                                 select o).DefaultIfEmpty();

            List<Order> newOrders = new List<Order>();
            Order order;

            if (orders != null)
            {
                foreach (Order o in orders)
                {
                    order = new Order
                    {
                       Order_ID = o.Order_ID,
                       Customer_ID = o.Customer_ID,
                       Order_Date = o.Order_Date,
                       Order_Delivery_Status = o.Order_Delivery_Status
                    };
                    newOrders.Add(order);
                }

               
                return newOrders;
            }
            else
            {
                return null;
            }
        }

        public bool addOrderItem(int order_id, int product_id, int order_item_quantity)
        {
            var orderItem = new OrderItem
            { 
                Order_ID = order_id,
                Product_ID = product_id,
                OrderItem_Quantity = order_item_quantity
            };

            try
            {
                db.OrderItems.InsertOnSubmit(orderItem);
                db.SubmitChanges();

                return true;
            }
            catch(Exception x)
            {
                return false;
            }

        }

        public List<OrderItem> getOrderItems(int order_id)
        {
            dynamic orderItems = (from o in db.OrderItems
                                  select o).DefaultIfEmpty();

            List<OrderItem> newOrderItems = new List<OrderItem>();
            OrderItem orderItem;

            if (orderItems != null)
            {
                foreach (OrderItem o in orderItems)
                {
                    orderItem = new OrderItem
                    {
                        OrderItem_ID = o.OrderItem_ID,
                        Order_ID = o.Order_ID,
                        Product_ID = o.Product_ID,
                        OrderItem_Quantity = o.OrderItem_Quantity
                    };

                    newOrderItems.Add(orderItem);
                }

                return newOrderItems;
            }
            else
            {
                return null;
            }
        }
    }
}
