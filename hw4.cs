// Stuart Wyse
// CSE 465 - HW4

// ----------------------------------------------------------
// CommonCityNames.txt

using System.IO;
using System;
using System.Collections.Generic;

class Program
{
  static void Main()
  {
    string line;
    System.IO.StreamReader file = new System.IO.StreamReader("states.txt");

    // List to hold states in states.txt
    List<string> states = new List<string>();

    // add states to states list
    while((line = file.ReadLine()) != null) {
      states.Add(line);
    }

    System.IO.StreamReader zipcodes = new System.IO.StreamReader("zipcodes.txt");
    List<string> CommonCityNames = new List<string>();

    // if city is in state that is in states.txt, add it to CommonCityNames
    while((line = zipcodes.ReadLine()) != null) {
      string[] words = line.Split('\t');
      foreach(string state in states) {
        if(words[4] == state) {
          CommonCityNames.Add(words[3]);
        }
      }
    }

    // sort List, and write List to CommonCityNames.txt
    CommonCityNames.Sort();
    using(StreamWriter writeText = new StreamWriter("CommonCityNames.txt")) {
      CommonCityNames.ForEach(delegate(string city) {
        writeText.WriteLine(city);
        });
      }

      file.Close();
      zipcodes.Close();

// ---------------------------------------------------------
// LatLon.txt

      string line2;
      System.IO.StreamReader file2 = new System.IO.StreamReader("zips.txt");

      // List to hold states in states.txt
      List<string> zips = new List<string>();

      // add states to states list
      while((line2 = file2.ReadLine()) != null) {
        zips.Add(line2);
      }

      System.IO.StreamReader zipcodes2 = new System.IO.StreamReader("zipcodes.txt");
      List<string> LatLon = new List<string>();

      // add zip, lat, and lon to LatLon list
      // use zip to make sure no duplicates are added
      while((line = zipcodes2.ReadLine()) != null) {
        string[] words2 = line.Split('\t');
        foreach(string zip in zips) {
          if(words2[1] == zip && !LatLon.Contains(words2[1])) {
            LatLon.Add(words2[1]);
            LatLon.Add(words2[6]);
            LatLon.Add(words2[7]);
          }
        }
      }

      using (StreamWriter writeText2 = new StreamWriter("LatLon.txt")) {

        // add lat and lon to LatLon.txt
        int counter = 0;
        foreach(string entry in LatLon) {
          if(counter == 1 || counter == 2) {
            writeText2.Write(entry + ' ');
          }
          if(counter >= 2) {
            writeText2.Write('\n');
            counter = 0;
          } else {
            counter++;
          }
        }
      }
      file2.Close();
      zipcodes2.Close();
    }
  }
