using System;
using System.Collections.Generic;

public class Foo
{
    /*
    * Complete the 'IsBuyerWinner' function below.
    *
    * The function is expected to return an Integer.
    * The function accepts following parameters:
    * 1. List (STRING_ARRAY) - codeList
    * 2. List (STRING_ARRAY) - shoppingCart
    */
    public static int IsBuyerWinner(List<string> codeList, List<string> shoppingCart)
    {
        int codeIndex = 0;
        int cartIndex = 0;

        while (codeIndex < codeList.Count && cartIndex + codeList[codeIndex].Split(',').Length <= shoppingCart.Count)
        {
            string[] codeItems = codeList[codeIndex].Split(',');
            bool match = true;
            for (int i = 0; i < codeItems.Length; i++)
            {
                if (!codeItems[i].Equals("anything") && !codeItems[i].Equals(shoppingCart[cartIndex + i]))
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                cartIndex += codeItems.Length;
                codeIndex++;
            }
            else
            {
                cartIndex++;
            }
        }

        return codeIndex == codeList.Count ? 1 : 0;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Unesite broj setova voca:");
        int codeListCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<string> codeList = new List<string>();
        for (int i = 0; i < codeListCount; i++)
        {
            Console.WriteLine("Unesite artikle za " + (i + 1) + ". set voca (svaki artikal odvojiti zarezom):");
            string codeListItem = Console.ReadLine();
            codeList.Add(codeListItem);
        }

        Console.WriteLine("Unesite broj artikala kupca:");
        int shoppingCartCount = Convert.ToInt32(Console.ReadLine().Trim());
        List<string> shoppingCart = new List<string>();
        for (int i = 0; i < shoppingCartCount; i++)
        {
            Console.WriteLine("Unesite " + (i + 1) + ". artikal u shoppingCart");
            string shoppingCartItem = Console.ReadLine();
            shoppingCart.Add(shoppingCartItem);
        }

        int foo = Foo.IsBuyerWinner(codeList, shoppingCart);
        Console.WriteLine(foo == 1 ? "Kupac je pobjednik" : "Kupac nije pobjednik");
    }
}
