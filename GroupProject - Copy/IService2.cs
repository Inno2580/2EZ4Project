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
        User login(string name, string email, string password);

        //Returning a single product
        [OperationContract]
        Product getProduct(int prod_ID);

        //Returning a list of Active Products
        [OperationContract]
        List<Product> getActiveProducts(int catID);

        //Adding a new product
        [OperationContract]
        bool isProdAdded(int Category_ID, String product_name, String product_brand, decimal product_price,int product_quantity, bool product_availability, DateTime product_UpdatedAt);

        //Editing existing product
    }
}
