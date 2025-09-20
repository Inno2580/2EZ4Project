using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GroupProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        //Function for inserting User into database(REGISTER)
        [OperationContract]
        int Register(string name, string surname, string phone_number, string email, string password, string confirm, char type);

        //Function for retrieving User from database(LOGIN)
        [OperationContract]
        User login(string email, string password);

        //Returning a single product
        [OperationContract]
        Product getProduct(int prod_ID);

        //Returning a list of Active Products
        [OperationContract]
        List<Product> getActiveProducts(int catID);

        //Adding a new product
        [OperationContract]
        bool isProdAdded(int Category_ID, String product_name, String product_brand, decimal product_price, int product_quantity, bool product_availability, DateTime product_UpdatedAt);

        //Editing existing product
        [OperationContract]
        bool editProduct(Product product);

        //Add Invoice
        [OperationContract]
        bool addInvoice(int customer_ID);

        //Retrieving invoice 
        [OperationContract]
        Invoice getInvoice(int invoice_id);

        //Retrieving list of invoices for customer
        [OperationContract]
        List<Invoice> getInvoices(int Customer_ID);

        //Add Invoice Line
        [OperationContract]
        bool addInvoiceLine(int invoice_id, int product_id, int invoiceline_quantity);

        //Retrieving Invoice Line Items
        [OperationContract]
        List<Invoiceline> getIvoiceLineItems(int inv_id);

        //FOR ORDER:
        //Add Order
        [OperationContract]
        bool addOrder(int customer_id, bool order_Delivery_Staus);

        //Retrieving Order 
        [OperationContract]
        Order getOrder(int order_id);

        //Retrieving list of orders
        [OperationContract]
        List<Order> getOrders();

        //Add order Line
        [OperationContract]
        bool addOrderItem(int order_id, int product_id, int order_item_quantity);

        //Retrieving Order Line Items
        [OperationContract]
        List<OrderItem> getOrderItems(int order_id);

        //REPORTS




        //add card 
        [OperationContract]
        bool addCard(string card_acc, int Customer_ID, string card_number, string card_cvv, DateTime exp_date, int card_isActive);
    }
}
