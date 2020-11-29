using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Product_Review_Management
{
    public class ProductReviewManagement
    {
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId: " + list.ProductID + " UserId: " + list.UserID + " Rating: " + list.Rating +
                    " Review: " + list.Review + " IsLike: " + list.isLike);
            }
        }
        public void RatingsGreaterThanThreeOfSpecificProducts(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               where (productReview.ProductID == 1 || productReview.ProductID == 2 || productReview.ProductID == 4)
                               && productReview.Rating > 3
                               select productReview;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId: " + list.ProductID + " UserId: " + list.UserID + " Rating: " + list.Rating +
                    " Review: " + list.Review + " IsLike: " + list.isLike);
            }
        }
        public void GetReviewsCount(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + ": " + list.Count);
            }
        }
        public void GetProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview select new { productReview.ProductID, productReview.Review };

            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "-->" + list.Review);
            }
        }
        public void SkipTopFiveRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                orderby productReview.Rating descending
                                select productReview).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId: " + list.ProductID + " UserId: " + list.UserID + " Rating: " + list.Rating +
                    " Review: " + list.Review + " IsLike: " + list.isLike);
            }
        }
    }
}
