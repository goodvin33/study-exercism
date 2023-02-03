using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class BookStore
    {
        private static readonly decimal CostOneCopy = 8;
        private static readonly Dictionary<int, decimal> GroupDiscount = new Dictionary<int, decimal>()
        {
            {1, 0m },
            {2, 0.05m },
            {3, 0.1m },
            {4, 0.2m },
            {5, 0.25m }
        };
        public static decimal Total(IEnumerable<int> books)
        {
            List<decimal> listOfTotalResults = new List<decimal>();

            for (int countBooksInOneGroup = 5; countBooksInOneGroup > 0; countBooksInOneGroup--)
            {
                List<List<int>> listOfBooks = InitListGroups(books.ToList(), countBooksInOneGroup);
                decimal total = 0.0m;
                if (listOfBooks.Count > 0)
                {

                    foreach (List<int> oneGroupBooks in listOfBooks)
                    {
                        total = total + CalculateSumOneGroup(GroupDiscount.Where(x => x.Key == oneGroupBooks.Count()).First().Value, oneGroupBooks.Count());
                    }

                }
                else
                {
                    total = CalculateSumOneGroup(GroupDiscount.Where(x => x.Key == 1).First().Value, books.Count());
                }
                listOfTotalResults.Add(total);
            }

            return listOfTotalResults.Min();
        }

        private static List<List<int>> InitListGroups(List<int> allBooks, int maxGroupSize)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> oneGroup = new List<int>();
            Dictionary<int, int> booksInGroups = OrderBooksInGroups(allBooks);
            

                while (booksInGroups.Any(x=>x.Value >0))
            {
                oneGroup = new List<int>();
                oneGroup = booksInGroups.Where(x => x.Value > 0).OrderByDescending(x=>x.Value).Take(maxGroupSize).Select(x => x.Key).ToList();
                booksInGroups.Where(x => x.Value > 0).OrderByDescending(x => x.Value).Take(maxGroupSize).Select(x => x.Key).ToList().ForEach(x => booksInGroups[x]--);
                result.Add(oneGroup);
            }
            return result;
        }
        private static decimal CalculateSumOneGroup(decimal discount, int countBooks) => (CostOneCopy - (CostOneCopy * discount)) * countBooks;
        private static Dictionary<int, int> OrderBooksInGroups(List<int> allBooks) => allBooks.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

    }
}
