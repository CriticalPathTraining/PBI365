using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerBiRestAPI.Models;

namespace PowerBiRestAPI {

  class Program {

    static void Main(string[] args) {

      PowerBiWorkspaceManager workspace = new PowerBiWorkspaceManager();


      //workspace.DisplayDatasets();

     workspace.CreateDataset();
      
      while (true) {
        workspace.AddRows();
        System.Threading.Thread.Sleep(3000);

      }



      Console.WriteLine("All done");
      Console.ReadLine();
    }
  }
}
