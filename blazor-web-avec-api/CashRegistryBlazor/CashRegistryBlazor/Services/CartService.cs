using CashRegistryBlazor.Models;

namespace CashRegistryBlazor.Services
{
    public class CartService
    {
        public Cart Cart { get; set; }
        private ProductService _productService;
        public CartService(ProductService productService)
        {
            Cart = new Cart();
            _productService = productService;
        }

        public bool AddProductToCart(int productId)
        {
            Product? product = _productService.GetProductById(productId);
            if(product != null)
            {
                CartProduct? cartProduct = ProductInCart(product.Id);
                if(cartProduct != null)
                {
                    cartProduct.Qty++;
                }
                else
                {
                    cartProduct = new CartProduct() { Qty = 1, Product = product };
                    Cart.Products.Add(cartProduct);
                }
                return true;
            }
            return false;
        }

        public bool UpdateQtyProduct(int productId, int Qty)
        {
            CartProduct? cartProduct = ProductInCart(productId);
            if(cartProduct != null)
            {
                cartProduct.Qty = Qty;
                return true;
            }
            return false;
        }

        public CartProduct? ProductInCart(int productId)
        {
            CartProduct? product = null;
            foreach(CartProduct p in Cart.Products)
            {
                if(p.Product.Id == productId)
                {
                    product = p; break;
                }
            }
            return product;
        }
    }
}
