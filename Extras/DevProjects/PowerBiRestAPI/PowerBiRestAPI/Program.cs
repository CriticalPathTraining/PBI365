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

      PowerBiWorkspaceManager workspace = new PowerBiWorkspaceManager();
      //workspace.CreateSampleCSV();
      //return;

      // workspace.DisplayDatasets();
      workspace.CreateDataset();
      workspace.AddRows();
      Thread.Sleep(5000);
      workspace.AddRows();
      Thread.Sleep(5000);
      workspace.AddRows();
      Thread.Sleep(2000);
      workspace.AddRows();
      Thread.Sleep(2000);
      workspace.AddRows();
      Thread.Sleep(2000);

      int counter = 1;

      while (counter < 150) {
        workspace.AddRows();
        counter += 1;
        Thread.Sleep(1500);
      }

      Console.WriteLine("Contribution web site has been shut down since the goal has been reached");
      Console.ReadLine();
    }
  }
}
