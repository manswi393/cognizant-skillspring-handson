using System;

namespace ECommerceSearch
{
    public class SearchOperations
    {
        // Linear Search
        public static Product LinearSearch(Product[] products, int id)
        {
            foreach (Product product in products)
            {
                if (product.ProductId == id)
                {
                    return product;
                }
            }
            return null;
        }

        // Binary Search
        public static Product BinarySearch(Product[] products, int id)
        {
            int low = 0;
            int high = products.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (products[mid].ProductId == id)
                    return products[mid];

                if (products[mid].ProductId < id)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return null;
        }
    }
}