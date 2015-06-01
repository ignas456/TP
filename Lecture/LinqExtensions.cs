﻿// ***********************************************************************
// Assembly         : Lecture
// Author           : mpostol
// Created          : 05-31-2015
//
// Last Modified By : mpostol
// Last Modified On : 05-31-2015
// ***********************************************************************
// <copyright file="LinqExtensions.cs" company="Microsoft">
//     Copyright © Microsoft 2014
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;

namespace TP.Lecture
{
  /// <summary>
  /// Class FromClause 
  /// </summary>
  public class LinqExtensions
  {
    public string FromClauseExample1()
    {
      // Example #1: var is optional because 
      // the select clause specifies a string 
      string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
      //var wordQuery = from word in words
      IEnumerable<string> wordQuery = words.Where<string>(word => word[0] == 'g').Select<String, String>(word => word);
      List<string> _selection = new List<string>();
      // Because each element in the sequence is a string, not an anonymous type, var is optional here also. 
      foreach (string s in wordQuery)
        _selection.Add(s);
      return String.Join(";", _selection.ToArray());
    }

    /// <summary>
    /// Defered execution
    /// </summary>
    /// <returns>System.String.</returns>
    public string FromClauseExample2()
    {
      // Example #1: var is optional because 
      // the select clause specifies a string 
      string[] words = new string[] { "apple", "strawberry", "grape", "peach", "banana" };
      //var wordQuery = from word in words
      IEnumerable<string> wordQuery = words.Where<string>(word => word[0] == 'g'); //.Select<String, String>(word => word);
      words = null; // new string[] { "apple", "strawberry", "peach", "banana" };
      List<string> _selection = new List<string>();
      // Because each element in the sequence is a string, not an anonymous type, var is optional here also. 
      foreach (string s in wordQuery)
        _selection.Add(s);
      return String.Join(";", _selection.ToArray());
    }

    /// <summary>
    /// Example #2: how to use an anonymous type in the select clause
    /// </summary>
    /// <returns>System.String.</returns>
    public string FromClauseExample3()
    {
      Customer[] customers = new Customer[] { new Customer() { City = "Phoenix", Name = "Name1", Revenue=11.0E3F  },
                                              new Customer() { City = "NewYork", Name = "Name2", Revenue=12.0E4F   },
                                              new Customer() { City = "Phoenix", Name = "Name3", Revenue=13.0E4F   }, 
                                              new Customer() { City = "Washington", Name = "Name4", Revenue=14.0E4F   }
      };
      // Example #2: var is required because the select clause specifies an anonymous type 
      //The compiler infers the types if not explicit stated.
      var custQuery = customers.Where(cust => cust.City == "Phoenix").Select( cust=> new { cust.Name, cust.Revenue } );
      return String.Join(";", custQuery.Select(x => String.Format("{0}:{1:F}", x.Name, x.Revenue)).ToArray<string>());
    }
    private class Customer
    {
      public string City { get; set; }
      public string Name { get; set; }
      public float Revenue { get; set; }
    }
  }
}
