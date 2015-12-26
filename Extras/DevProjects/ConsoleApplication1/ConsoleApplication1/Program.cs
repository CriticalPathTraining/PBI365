using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
  class Program {
    static void Main(string[] args) {


      while (true) {
        string x = DateTime.Now.ToString("hh:mm") + ":" + ((DateTime.Now.Second / 10) * 10) ;

        Console.WriteLine(x);
        System.Threading.Thread.Sleep(1000);
      }

    }
  }
}
