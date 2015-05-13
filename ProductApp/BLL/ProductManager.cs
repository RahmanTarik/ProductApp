using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.DAL;
using ProductApp.MODEL;

namespace ProductApp.BLL
{
  public class ProductManager
    {

      ProductDataAccess gatway = new ProductDataAccess();
        internal string Save(MODEL.Product aProduct)
        {
            if (aProduct.Code.Length >2)
            {
                if (aProduct.Quantity > 0)
                {
                  Product returnProduct   = IsCodeExists(aProduct.Code);
                  if (returnProduct != null)
                  {
                        aProduct.Id = returnProduct.Id;
                        int updt = gatway.Update(aProduct);
                        if (updt > 0)
                        {
                            return "Updated Successfully";
                        }
                        else
                        {
                            return "Failed to Update";
                        }
                    }
                    else
                    {
                        int result = gatway.Save(aProduct);
                        if (result > 0)
                        {
                            return "Saved Successfully";
                        }
                        else
                        {
                            return "Failed to Save";
                        }
                    }
                  
                }
                else
                {
                    return "Please Enter Valid Quantity";
                }
            }
            else
            {
                return "Product Code Must be at least 3 Characters";
            }
        }

        private Product IsCodeExists(string code)
        {
            Product aProduct = gatway.GetProductByCode(code);
            return aProduct;
        }

        internal List<Product> GetAllProducts()
        {
            return gatway.GetAllProducts();
        }
    }
}
