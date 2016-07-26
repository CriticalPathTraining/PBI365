using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using PowerBiRestAPI.Models;

namespace PowerBiRestAPI {

  class Program {

    static void Main(string[] args) {

      Console.WriteLine("Starting up Contributions web site..");
      Thread.Sleep(2000);
      Console.WriteLine("Web site has successfully restarted");
      Console.WriteLine();
      Thread.Sleep(1500);
      Console.WriteLine("Connecting to credit card authority...");
      Thread.Sleep(2500);
      Console.WriteLine("Connection to credit card authority established");
      Console.WriteLine();
      Thread.Sleep(1000);
      Console.WriteLine("Connecting to Power BI workspace...");
      Thread.Sleep(1000);

      PowerBiWorkspaceManager workspace = new PowerBiWorkspaceManager();
      workspace.CreateDataset();

      Console.WriteLine("Connection to Power BI workspace established");
      Thread.Sleep(1000);
      Console.WriteLine();
      Console.WriteLine("System is now operational and ready to accept contributions...");
      Console.WriteLine();

      int counter = 1;

      while (counter < 7) {
        workspace.AddRows();
        counter += 1;
        Thread.Sleep(10000);
      }


      while (counter < 21) {
        workspace.AddRows();
        counter += 1;
        Thread.Sleep(3000);
      }
      
      while (counter < 160) {
        workspace.AddRows();
        counter += 1;
        Thread.Sleep(1500);
      }

      Console.WriteLine();
      Console.WriteLine("Contribution web site is now shuting down since the contribution goal has been reached");
      Console.ReadLine();
    }
  }
}
