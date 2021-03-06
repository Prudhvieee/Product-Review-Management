﻿using System;
using System.Collections.Generic;

namespace Product_Review_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management Problem.");
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID=1,UserID=1,Rating=2,Review="Bad",isLike=false},
                new ProductReview(){ProductID=2,UserID=1,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductID=3,UserID=2,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductID=1,UserID=2,Rating=3,Review="Nice",isLike=true},
                new ProductReview(){ProductID=2,UserID=3,Rating=2,Review="Nice",isLike=true},
                new ProductReview(){ProductID=2,UserID=4,Rating=1,Review="Bad",isLike=false},
                new ProductReview(){ProductID=4,UserID=3,Rating=1,Review="Bad",isLike=false},
                new ProductReview(){ProductID=6,UserID=5,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductID=2,UserID=6,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProductID=4,UserID=1,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProductID=5,UserID=2,Rating=3,Review="Nice",isLike=true}
            };
            foreach (var list in productReviewList)
            {
                Console.WriteLine("ProductId: " + list.ProductID + " UserId: " + list.UserID + " Rating: " + list.Rating +
                    " Review: " + list.Review + " IsLike: " + list.isLike);
            }
        }
    }
}
