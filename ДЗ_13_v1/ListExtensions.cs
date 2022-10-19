using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ДЗ_13_v1.EntityObject;
namespace ДЗ_13_v1
{
    public static class ListExtensions
    {
        public static IEnumerable<T> Top<T>(this List<T> list, int num)
        {
            try
            {
                if (num <= 100 && num >= 1)
                {

                    IEnumerable<T> newList = list
                        .OrderByDescending(sort => sort)
                        .Take((int)Math.Ceiling((double)list.Count * num / 100));

                    Console.WriteLine("[" + string.Join(", ", newList) + $"] ({ num}%)");
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.Write("Значение больше 100 или меньше 1");
            }
            return list;
        }

        public static IEnumerable<T> Top<T>(this List<T> list, int num, Func<T, int> func )  where T : IEntityObject

        {
            int maxAge = func(list.OrderByDescending(func => func.Age).First());

            try
            {
                if (num <= 100 && num >= 1)
                {

                    IEnumerable<T> newList = (from row in list
                                         where row.Age <= maxAge
                                         orderby row.Age descending 
                                         select row).Take((int)Math.Ceiling((double)list.Count * num / 100));

                    StringBuilder sb = new StringBuilder();

                    int i = newList.Count();
                    int j = 0;
                    foreach (var row in newList)
                    {
                        j++;
                        if (j < i) 
                        {
                            sb.Append(row.Age + ","); 
                        }
                        else
                        {
                            sb.Append(row.Age);
                        }  
                    }
                    Console.WriteLine($"[{sb}] ({num}%)");
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.Write("Значение больше 100 или меньше 1");
            }
            return list;
        }
    }

}
