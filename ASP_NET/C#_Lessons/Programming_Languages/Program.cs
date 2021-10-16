using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
  class Program
  {
    static void Main()
    {
      //File path may need to be changed as needed to languages.tsv current location 
      string filePath = @"C:\Users\Adam Barron\source\repos\Codeacademy_Projects\ASP_NET\C#_Lessons\Programming_Languages\languages.tsv";
      List<Language> languages = File.ReadAllLines(filePath)
        .Skip(1)
        .Select(line => Language.FromTsv(line))
        .ToList();

      //LINQ query to search for C# in the list of langauges
      var cSharpLangs = languages.Where(lang => lang.Name == "C#");
      PrettyPrintAll(cSharpLangs);
      
      //LINQ query to search for langauges which were developed by Microsoft
      var microsoftLangs = languages.Where(lang => lang.ChiefDeveloper.Contains("Microsoft"));
      //PrettyPrintAll(microsoftLangs);

      //LINQ query to search for langauges that descend from Lisp
      var lispDescendents = languages.Where(lang => lang.Predecessors.Contains("Lisp"));
      //PrettyPrintAll(lispDescendents);
      
      //LINQ query to search for langauges that contain "Script" in their name
      var scriptLangs = languages.Where(lang => lang.Name.Contains("Script")).Select(lang => lang.Name);
      //PrintAll(scriptLangs);

      //LINQ query to search for langauges that were invented between 1995 and 2005
      var nearMilleniumLangs = languages.Where(lang => (lang.Year >= 1995) && (lang.Year <= 2005)).Select(lang => $"{lang.Name} was invented in {lang.Year}");
      //PrintAll(nearMilleniumLangs);
    }

    //Purpose: Iterates through a List of Language elements, formats them using Prettify() and prints them.
    public static void PrettyPrintAll(IEnumerable<Language> languageList)
    {
      foreach(Language elem in languageList)
      {
        Console.WriteLine(elem.Prettify());
      }
    }

    //Purpose: Iterates through a List of Object elements and prints them. 
    public static void PrintAll(IEnumerable<Object> objectList)
    {
      foreach(Object elem in objectList)
      {
        Console.WriteLine(elem);
      }
    }
  }
}
