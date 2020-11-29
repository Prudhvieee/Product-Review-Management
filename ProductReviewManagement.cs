using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Product_Review_Management
{
    public class ProductReviewManagement
    {
        public readonly DataTable dataTable = new DataTable();
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
        public void SelectProductIDAndReviews(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { x.ProductID, x.Review });
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product ID: " + list.ProductID + " " + "Review: " + list.Review);
            }
        }
        public void InsertValuesIntoDataTable(List<ProductReview> listProductReview)
        {
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike", typeof(bool));

            dataTable.Rows.Add(1, 1, 3, "Nice", true);
            dataTable.Rows.Add(1, 2, 5, "Good", true);
            dataTable.Rows.Add(2, 1, 1, "Bad", false);
            dataTable.Rows.Add(4, 3, 3, "Nice", true);
            dataTable.Rows.Add(3, 4, 2, "Bad", false);
            dataTable.Rows.Add(5, 1, 5, "Good", true);
            dataTable.Rows.Add(6, 5, 3, "Nice", true);
            dataTable.Rows.Add(2, 6, 5, "Good", true);
            dataTable.Rows.Add(8, 5, 2, "Bad", false);
            dataTable.Rows.Add(6, 7, 3, "Nice", true);
            dataTable.Rows.Add(7, 6, 5, "Good", true);
            dataTable.Rows.Add(9, 9, 3, "Nice", true);
            dataTable.Rows.Add(10, 8, 4, "Good", true);
            dataTable.Rows.Add(9, 10, 1, "Bad", false);
            dataTable.Rows.Add(11, 11, 5, "Good", true);
        }
        public void GetRecordsWithIsLikeTrue()
        {
            var recordedData = from productReview in dataTable.AsEnumerable()
                               where productReview.Field<bool>("isLike") == true
                               select productReview;

            foreach (var product in recordedData)
            {
                Console.WriteLine("ProductID : " + product.Field<int>("ProductID") + " " + "UserID : " + product.Field<int>("UserID")
                    + " " + "Rating : " + product.Field<double>("Rating") + " " + "Review : " + product.Field<string>("Review") + " "
                    + "isLike : " + product.Field<bool>("isLike"));
            }
        }
        public void GetAverageRating()
        {
            var recordedData = dataTable.AsEnumerable().GroupBy(e => e.Field<int>("ProductID")).Select
                               (x => new { ProductID = x.Key, Average = x.Average(y => y.Field<double>("Rating")) });

            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + ": " + list.Average);
            }
        }
        public void GetProductWithReviewNice()
        {
            var recordedData = from productReview in dataTable.AsEnumerable()
                               where productReview.Field<string>("Review").ToUpper().Contains("NICE")
                               select productReview;

            foreach (var product in recordedData)
            {
                Console.WriteLine("ProductID : " + product.Field<int>("ProductID") + " " + "UserID : " + product.Field<int>("UserID")
                    + " " + "Rating : " + product.Field<double>("Rating") + " " + "Review : " + product.Field<string>("Review") + " "
                    + "isLike : " + product.Field<bool>("isLike"));
            }
        }
    }
}