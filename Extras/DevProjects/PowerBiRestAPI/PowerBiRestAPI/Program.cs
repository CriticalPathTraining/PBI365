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


      // workspace.DisplayDatasets();
      workspace.CreateDataset();

      workspace.AddRows();



      Console.WriteLine("All done");
      Console.ReadLine();
    }
  }
}
