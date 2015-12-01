using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WingtipDataGenerator {

  #region "Classes for generating sample data for wingtip sales model"

  public class CustomerLocationData {
    public string AreaCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
  }

  public class CustomerData {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string EmailAddress { get; set; }
    public string WorkPhone { get; set; }
    public string HomePhone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime FirstPurchaseDate { get; set; }
    public DateTime LastPurchaseDate { get; set; }

    public InvoiceData FirstInvoice { get; set; }

  }

  public class InvoiceData {
    public double InvoiceAmount { get; set; }
    public string InvoiceType { get; set; }
    public List<InvoiceDetailData> InvoiceDetails { get; set; }
  }

  public class InvoiceDetailData {
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
  }

  public class ProductData {
    public string ProductCode { get; set; }
    public string ProductCategory { get; set; }
    public string ProductDescription { get; set; }
    public string Title { get; set; }
    public double UnitCost { get; set; }
    public double ListPrice { get; set; }
    public string Color { get; set; }
    public int? MinimumAge { get; set; }
    public int? MaximumAge { get; set; }
  }

  #endregion

  public class DataFactory {

    public static IEnumerable<ProductData> GetProductsList() {
      return Products;
    }

    private static int customerCount = 0;
    public static CustomerData GetNextCustomer() {

      CustomerLocationData customerLocation = GetNextCustomerLocation();

      string Address = GetNextAddress();
      string City = customerLocation.City;
      string State = customerLocation.State;
      string ZipCode = customerLocation.ZipCode;

      string AreaCode = customerLocation.AreaCode;

      string WorkPhoneNumber = GetNextPhoneNumber(AreaCode);
      string HomePhoneNumber = GetNextPhoneNumber(AreaCode);

      string Gender = "F";
      string invoiceType = "InPerson";

      switch (CustomerGrowthPhase) {
        case 1: // phase 1
          if (WingtipRandom.Next(1, 100) > 32) { Gender = "M"; }
          break;

        case 2: // phase 2
          if (WingtipRandom.Next(1, 100) > 45) { Gender = "M"; }
          break;

        case 3: // phase 3
          if (WingtipRandom.Next(1, 100) > 55) { Gender = "M"; }
          break;

        case 4: // phase 4
          if (WingtipRandom.Next(1, 100) > 40) { Gender = "M"; }
          break;
          
      }

      string FirstName = "";
      if (Gender.Equals("F")) {
        FirstName = GetNextFemaleFirstName();
      }
      else {
        FirstName = GetNextMaleFirstName();
      }

      string LastName = GetNextLastName();
      string Company = GetNextCompany();
      string EmailAddress = (FirstName + "." + LastName + "@" + Company + ".com").Replace(" ", "").Replace("'", "");



      DateTime BirthDate = GetNextBirthDate();

      if (State.Equals("FL")) {
        BirthDate = BirthDate.AddYears(-21);
      }
      if (State.Equals("AZ")) {
        BirthDate = BirthDate.AddYears(-12);
      }

      if (State.Equals("NM")) {
        BirthDate = BirthDate.AddYears(-9);
      }
      if (State.Equals("TX")) {
        BirthDate = BirthDate.AddYears(-7);
      }


      if (Gender.Equals("F")) {
        BirthDate = BirthDate.AddYears(-3);
      }


      List<InvoiceDetailData> invoiceDetails = new List<InvoiceDetailData>();

      int ItemCount = WingtipRandom.Next(1, 4);
      double InvoiceAmount = 0;

      for (int index = 0; index < ItemCount; index++) {

        int productId = GetProductId();
        ProductData product = Products[productId - 1];
        int quantity = WingtipRandom.Next(1, 10);
        if (productId == 14) {
          int[] quantitySizes = { 10, 25, 25, 25, 100, 100, 100, 100, 100, 250, 250, 250, 500, 1000, 1000, 1000, 1000, 2500 };
          int selection = WingtipRandom.Next(0, quantitySizes.Length - 1);
          quantity = quantitySizes[selection];
        }
        double price = quantity * product.ListPrice;
        InvoiceAmount += price;
        invoiceDetails.Add(new InvoiceDetailData { ProductId = productId, Quantity = quantity, Price = price });

      }




      InvoiceData FirstInvoice = new InvoiceData {
        InvoiceAmount = InvoiceAmount,
        InvoiceType = invoiceType,
        InvoiceDetails = invoiceDetails
      };

      CustomerData newCustomer = new CustomerData {
        FirstName = FirstName,
        LastName = LastName,
        Company = Company,
        EmailAddress = EmailAddress,
        WorkPhone = WorkPhoneNumber,
        HomePhone = HomePhoneNumber,
        Address = Address,
        City = City,
        State = State,
        ZipCode = ZipCode,
        Gender = Gender,
        BirthDate = BirthDate,
        FirstInvoice = FirstInvoice
      };

      customerCount += 1;

      return newCustomer;

    }
    public static InvoiceData GetNextInvoice() {

      int customerId = WingtipRandom.Next(1, customerCount);

      List<InvoiceDetailData> invoiceDetails = new List<InvoiceDetailData>();

      int ItemCount = WingtipRandom.Next(1, 4);
      double InvoiceAmount = 0;

      for (int index = 0; index < ItemCount; index++) {

        int productId = GetProductId();
        ProductData product = Products[productId - 1];
        int quantity = WingtipRandom.Next(1, 10);
        double price = quantity * product.ListPrice;
        InvoiceAmount += price;
        invoiceDetails.Add(new InvoiceDetailData { ProductId = productId, Quantity = quantity, Price = price });

      }

      string invoiceType = "InPerson";

      switch (CustomerGrowthPhase) {
        case 1: // phase 1
          if (WingtipRandom.Next(1, 100) > 90) { invoiceType = "MailOrder"; }
          break;

        case 2: // phase 2
          if (WingtipRandom.Next(1, 100) > 95) { invoiceType = "MailOrder"; }
          if (WingtipRandom.Next(1, 100) > 50) { invoiceType = "Online"; }
          break;

        case 3: // phase 3
          if (WingtipRandom.Next(1, 100) > 98) { invoiceType = "MailOrder"; }
          if (WingtipRandom.Next(1, 100) > 35) { invoiceType = "Online"; }
          break;

        case 4: // phase 4
          if (WingtipRandom.Next(1, 100) > 99) { invoiceType = "MailOrder"; }
          if (WingtipRandom.Next(1, 100) > 24) { invoiceType = "Online"; }
          break;
      }
      
      InvoiceData newInvoice = new InvoiceData {
        InvoiceAmount = InvoiceAmount,
        InvoiceType = invoiceType,
        InvoiceDetails = invoiceDetails
      };

      return newInvoice;
    }

    #region " static fields with arrays of field values"


    private static ProductData[] Products = new ProductData[] {
      new ProductData { ProductCode="WP0001", Title="Batman Action Figure", UnitCost=6.85, ListPrice=14.95, ProductCategory="Action Figures > Tough Guys", ProductDescription="A super hero who sometimes plays the role of a dark knight." , MinimumAge=7, MaximumAge=12, Color="Black" },
      new ProductData { ProductCode="WP0002", Title="Captain America Action Figure", UnitCost=7.05, ListPrice=12.95 , ProductCategory="Action Figures > Tough Guys", ProductDescription="A super action figure that protects freedom and the American way of life.", MinimumAge=7, MaximumAge=12, Color="Red,White,Blue" },
      new ProductData { ProductCode="WP0003", Title="GI Joe Action Figure", UnitCost=6.10, ListPrice=14.95 , ProductCategory="Action Figures > Tough Guys", ProductDescription="A classic action figure from the 1970s.", MinimumAge=null, MaximumAge=null, Color="Green" },
      new ProductData { ProductCode="WP0004", Title="Green Hulk Action Figure", UnitCost=2.85, ListPrice=9.95 , ProductCategory="Action Figures > Tough Guys", ProductDescription="An overly muscular action figure that strips naked when angry.", MinimumAge=7, MaximumAge=12, Color="Green" },
      new ProductData { ProductCode="WP0005", Title="Red Hulk Alter Ego Action Figure", UnitCost=2.85, ListPrice=9.95 , ProductCategory="Action Figures > Tough Guys", ProductDescription="A case of anabolic steroids with a most unfortunate outcome.", MinimumAge=7, MaximumAge=12, Color="Red" },
      new ProductData { ProductCode="WP0006", Title="Godzilla Action Figure", UnitCost=14.25,  ListPrice=19.95 , ProductCategory="Action Figures > Tough Guys", ProductDescription="The classic and adorable action figure from those old Japanese movies.", MinimumAge=10, MaximumAge=null, Color="Green" },
      new ProductData { ProductCode="WP0007", Title="Perry the Platypus Action Figure", UnitCost=12.00,  ListPrice=21.95 , ProductCategory="Action Figures > Cute and Huggable", ProductDescription="A platypus who plays an overly intelligent detective sleuth on TV.", MinimumAge=null, MaximumAge=null, Color="Green,Yellow" },
      new ProductData { ProductCode="WP0008", Title="Green Angry Bird Action Figure",  UnitCost=2.10, ListPrice=4.95 , ProductCategory="Action Figures > Cute and Huggable", ProductDescription="A funny looking green bird that really hates pigs.", MinimumAge=5, MaximumAge=10, Color="Green" },
      new ProductData { ProductCode="WP0009", Title="Red Angry Bird Action Figure",  UnitCost=2.10, ListPrice=14.95 , ProductCategory="Action Figures > Cute and Huggable", ProductDescription="A funny looking red bird that also hates pigs.", MinimumAge=5, MaximumAge=10, Color="Red" },
      new ProductData { ProductCode="WP0010", Title="Phineas and Ferb Action Figure Set",  UnitCost=12.25, ListPrice=19.95 , ProductCategory="Action Figures > Cute and Huggable", ProductDescription="The dynamic duo of the younger generation.", MinimumAge=5, MaximumAge=51, Color="Green,Red" },
      new ProductData { ProductCode="WP0011", Title="Black Power Ranger Action Figure",  UnitCost=6.15, ListPrice=7.50 , ProductCategory="Action Figures > Cute and Huggable", ProductDescription="A particularly violent action figure for violent children.", MinimumAge=8, MaximumAge=12, Color="Black,White" },
      new ProductData { ProductCode="WP0012", Title="Woody Action Figure",  UnitCost=7.10, ListPrice=9.95 , ProductCategory="Action Figures > Cute and Huggable", ProductDescription="The lovable, soft-spoken cowboy from Toy Story.", MinimumAge=null, MaximumAge=12, Color="Blue,Yellow" },
      new ProductData { ProductCode="WP0013", Title="Spiderman Action Figure",  UnitCost=10.40, ListPrice=12.95 , ProductCategory="Action Figures > Tough Guys", ProductDescription="The classic superhero who is quite the swinger.", MinimumAge=8, MaximumAge=12, Color="Red,Blue" },
      new ProductData { ProductCode="WP0014", Title="Twitter Follower Action Figure",  UnitCost=.08, ListPrice=1.00 , ProductCategory="Action Figures > Cute and Huggable", ProductDescription="An inexpensive action figure you can never have too many of.", MinimumAge=12, MaximumAge=null, Color="Yellow,Blue" },
      new ProductData { ProductCode="WP0015", Title="Crayloa Crayon Set",  UnitCost=1.20, ListPrice=2.49 , ProductCategory="Arts and Crafts > Drawing", ProductDescription="A very fun set of crayons in every color.", MinimumAge=10, MaximumAge=null, Color="Blue,Red,Green,Yellow" },
      new ProductData { ProductCode="WP0016", Title="Sponge Bob Coloring Book",  UnitCost=0.85, ListPrice=2.95 , ProductCategory="Arts and Crafts > Drawing", ProductDescription="A drawing extravaganza based on America's most recognizable celebrity.", MinimumAge=7, MaximumAge=12, Color="Yellow" },
      new ProductData { ProductCode="WP0017", Title="Easel with Supply Trays",  UnitCost=12.10, ListPrice=49.95 , ProductCategory="Arts and Crafts > Painting", ProductDescription="A serious easel for serious young artists.", MinimumAge=null, MaximumAge=12, Color="White" },
      new ProductData { ProductCode="WP0018", Title="Crate o' Crayons",  UnitCost=10.50, ListPrice=14.95 , ProductCategory="Arts and Crafts > Drawing", ProductDescription="More crayons that you can shake a stick at.", MinimumAge=7, MaximumAge=12, Color="Blue,Red,Green,Yellow" },
      new ProductData { ProductCode="WP0019", Title="Etch A Sketch",  UnitCost=7.25, ListPrice=12.95 , ProductCategory="Arts and Crafts > Drawing", ProductDescription="A strategic planning tool for the Romney campaign.", MinimumAge=7, MaximumAge=null, Color="Red" },
      new ProductData { ProductCode="WP0020", Title="Green Hornet",  UnitCost=18.25, ListPrice=24.95 , ProductCategory="Remote Control Vehicles > Cars", ProductDescription="A fast car for crusin' the strip at night.", MinimumAge=10, MaximumAge=null, Color="Green" },
      new ProductData { ProductCode="WP0021", Title="Red Wacky Stud Bumper",  UnitCost=12.60, ListPrice=24.95 , ProductCategory="Remote Control Vehicles > Trucks", ProductDescription="A great little vehicle for off road fun.", MinimumAge=10, MaximumAge=null, Color="Red" },
      new ProductData { ProductCode="WP0022", Title="Red Stomper Bully",  UnitCost=21.50, ListPrice=29.95 , ProductCategory="Remote Control Vehicles > Trucks", ProductDescription="A great toy that can crush and destroy all your other toys.", MinimumAge=10, MaximumAge=null, Color="Red" },
      new ProductData { ProductCode="WP0023", Title="Green Stomper Bully",  UnitCost=14.50, ListPrice=24.95 , ProductCategory="Remote Control Vehicles > Trucks", ProductDescription="A green alternative to crush and destroy the Red Stomper Bully.", MinimumAge=10, MaximumAge=null, Color="Green" },
      new ProductData { ProductCode="WP0024", Title="Indy Race Car",  UnitCost=12.00, ListPrice=19.95 , ProductCategory="Remote Control Vehicles > Cars", ProductDescription="The fastest remote control race car on the market today.", MinimumAge=10, MaximumAge=null, Color="Black" },
      new ProductData { ProductCode="WP0025", Title="Turbo-boost Speedboat", UnitCost=12.50,  ListPrice=32.95 , ProductCategory="Remote Control Vehicles > Boats", ProductDescription="The preferred water vehicle of gun runners and drug kingpins.", MinimumAge=21, MaximumAge=null, Color="Red" },
      new ProductData { ProductCode="WP0026", Title="Sandpiper Prop Plane", UnitCost=16.50,  ListPrice=24.95 , ProductCategory="Remote Control Vehicles > Planes", ProductDescription="A simple RC prop plane for younger pilots.", MinimumAge=15, MaximumAge=null, Color="White" },
      new ProductData { ProductCode="WP0027", Title="Flying Badger", UnitCost=20.50,  ListPrice=27.95 , ProductCategory="Remote Control Vehicles > Planes", ProductDescription="A tough fighter plane to root out evil anywhere it lives.", MinimumAge=15, MaximumAge=null, Color="Blue" },
      new ProductData { ProductCode="WP0028", Title="Red Barron von Richthofen", UnitCost=22.50,  ListPrice=32.95 , ProductCategory="Remote Control Vehicles > Planes", ProductDescription="A classic RC plane to hunt down and take out Snoopy.", MinimumAge=15, MaximumAge=null, Color="Red" },
      new ProductData { ProductCode="WP0029", Title="Flying Squirrel", UnitCost=24.00,  ListPrice=69.95 , ProductCategory="Remote Control Vehicles > Planes", ProductDescription="A stealthy remote control plane that flies on the down-low and under the radar.", MinimumAge=18, MaximumAge=null, Color="Grey" },
      new ProductData { ProductCode="WP0030", Title="FOX News Chopper", UnitCost=12.00,  ListPrice=29.95 , ProductCategory="Remote Control Vehicles > Planes", ProductDescription="A new chopper which can generate new events on demand.", MinimumAge=18, MaximumAge=null, Color="Blue" },
      new ProductData { ProductCode="WP0031", Title="Seal Team 6 Helicopter", UnitCost=35.40,  ListPrice=59.95 , ProductCategory="Remote Control Vehicles > Helicopter", ProductDescription="A serious helicopter that can open up a can of whoop-ass when required.", MinimumAge=18, MaximumAge=null, Color="Green" },
      new ProductData { ProductCode="WP0032", Title="Personal Commuter Chopper",  UnitCost=65.75, ListPrice=99.95 , ProductCategory="Remote Control Vehicles > Helicopter", ProductDescription="A partially-tested remote control device that can actually carry real people.", MinimumAge=18, MaximumAge=null, Color="Red" }
    };

    private static CustomerLocationData[] CustomerLocations = new CustomerLocationData[]{
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new CustomerLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new CustomerLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97205", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97220", AreaCode="971" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new CustomerLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new CustomerLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new CustomerLocationData{ City="Issaquah", State="WA", ZipCode="98027", AreaCode="425" },
      new CustomerLocationData{ City="Spokane", State="WA", ZipCode="99218", AreaCode="509" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new CustomerLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" },

      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85044", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85018", AreaCode="602" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85022", AreaCode="602" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85266", AreaCode="480" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85250", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85042", AreaCode="602" },
      new CustomerLocationData{ City="Surprise", State="AZ", ZipCode="85374", AreaCode="623" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85281", AreaCode="480" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85283", AreaCode="480" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85711", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85716", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85715", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85741", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85705", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85748", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85714", AreaCode="520" },
      new CustomerLocationData{ City="Alameda", State="CA", ZipCode="94501", AreaCode="510" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92808", AreaCode="714" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92802", AreaCode="714" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93304", AreaCode="661" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93306", AreaCode="661" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93312", AreaCode="661" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93311", AreaCode="661" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92111", AreaCode="858" },
      new CustomerLocationData{ City="Burbank", State="CA", ZipCode="91504", AreaCode="818" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90022", AreaCode="323" },
      new CustomerLocationData{ City="Compton", State="CA", ZipCode="90220", AreaCode="310" },
      new CustomerLocationData{ City="Corona", State="CA", ZipCode="92881", AreaCode="951" },
      new CustomerLocationData{ City="Cupertino", State="CA", ZipCode="95014", AreaCode="408" },
      new CustomerLocationData{ City="Eureka", State="CA", ZipCode="95501", AreaCode="707" },
      new CustomerLocationData{ City="Folsom", State="CA", ZipCode="95630", AreaCode="916" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93710", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93722", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93726", AreaCode="559" },
      new CustomerLocationData{ City="Huntington Beach", State="CA", ZipCode="92646", AreaCode="714" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92602", AreaCode="714" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92606", AreaCode="949" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92618", AreaCode="949" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90048", AreaCode="323" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90017", AreaCode="213" },
      new CustomerLocationData{ City="Manhattan Beach", State="CA", ZipCode="90266", AreaCode="310" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92126", AreaCode="858" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94558", AreaCode="707" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94559", AreaCode="707" },
      new CustomerLocationData{ City="North Hollywood", State="CA", ZipCode="91606", AreaCode="818" },
      new CustomerLocationData{ City="Rancho Cucamonga", State="CA", ZipCode="91730", AreaCode="909" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95825", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95834", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95133", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95125", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95110", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95121", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95132", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95134", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95123", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95123", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95122", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95124", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95129", AreaCode="408" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Boulder", State="CO", ZipCode="80301", AreaCode="303" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80922", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80924", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80918", AreaCode="719" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80231", AreaCode="303" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80238", AreaCode="303" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Glenwood Springs", State="CO", ZipCode="81601", AreaCode="970" },
      new CustomerLocationData{ City="Grand Junction", State="CO", ZipCode="81505", AreaCode="970" },
      new CustomerLocationData{ City="Pueblo", State="CO", ZipCode="81008", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Westminster", State="CO", ZipCode="80023", AreaCode="303" },
      new CustomerLocationData{ City="Westminster", State="CO", ZipCode="80021", AreaCode="303" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87112", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87113", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87114", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87110", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87111", AreaCode="505" },
      new CustomerLocationData{ City="Rio Rancho", State="NM", ZipCode="87124", AreaCode="505" },
      new CustomerLocationData{ City="Roswell", State="NM", ZipCode="88201", AreaCode="575" },
      new CustomerLocationData{ City="Santa Fe", State="NM", ZipCode="87507", AreaCode="505" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new CustomerLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new CustomerLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97205", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97220", AreaCode="971" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new CustomerLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new CustomerLocationData{ City="Springfield", State="OR", ZipCode="97477", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97006", AreaCode="503" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78209", AreaCode="210" },
      new CustomerLocationData{ City="Amarillo", State="TX", ZipCode="79121", AreaCode="806" },
      new CustomerLocationData{ City="Arlington", State="TX", ZipCode="76015", AreaCode="817" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78759", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78723", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78753", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78717", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78758", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78749", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78704", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78748", AreaCode="512" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78232", AreaCode="210" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76132", AreaCode="817" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75231", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75237", AreaCode="469" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76120", AreaCode="817" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79925", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79912", AreaCode="915" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78730", AreaCode="512" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77007", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77082", AreaCode="281" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77024", AreaCode="713" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75220", AreaCode="214" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79423", AreaCode="806" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79407", AreaCode="806" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78253", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78250", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78245", AreaCode="210" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77042", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77063", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77069", AreaCode="281" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84121", AreaCode="801" },
      new CustomerLocationData{ City="Layton", State="UT", ZipCode="84041", AreaCode="801" },
      new CustomerLocationData{ City="Riverdale", State="UT", ZipCode="84405", AreaCode="801" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84101", AreaCode="801" },
      new CustomerLocationData{ City="Charlottesville", State="VA", ZipCode="22911", AreaCode="434" },
      new CustomerLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new CustomerLocationData{ City="Issaquah", State="WA", ZipCode="98027", AreaCode="425" },
      new CustomerLocationData{ City="Spokane", State="WA", ZipCode="99218", AreaCode="509" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new CustomerLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" }
    };

    private static CustomerLocationData[] CustomerLocations2 = new CustomerLocationData[]{      
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85044", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85018", AreaCode="602" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85022", AreaCode="602" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85266", AreaCode="480" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85250", AreaCode="480" },
      new CustomerLocationData{ City="Alameda", State="CA", ZipCode="94501", AreaCode="510" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92111", AreaCode="858" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92606", AreaCode="949" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87112", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87113", AreaCode="505" },
      new CustomerLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new CustomerLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new CustomerLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97205", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97220", AreaCode="971" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new CustomerLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new CustomerLocationData{ City="Springfield", State="OR", ZipCode="97477", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97006", AreaCode="503" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78209", AreaCode="210" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78753", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78717", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78758", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78749", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78704", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78748", AreaCode="512" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78232", AreaCode="210" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76132", AreaCode="817" },
      new CustomerLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" },
      new CustomerLocationData{ City="Mobile", State="AL", ZipCode="36695", AreaCode="251" },
      new CustomerLocationData{ City="Mobile", State="AL", ZipCode="36606", AreaCode="251" },
      new CustomerLocationData{ City="Tuscaloosa", State="AL", ZipCode="35404", AreaCode="205" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85044", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85018", AreaCode="602" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85022", AreaCode="602" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85266", AreaCode="480" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85250", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85042", AreaCode="602" },
      new CustomerLocationData{ City="Surprise", State="AZ", ZipCode="85374", AreaCode="623" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85281", AreaCode="480" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85283", AreaCode="480" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85711", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85716", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85715", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85741", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85705", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85748", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85714", AreaCode="520" },
      new CustomerLocationData{ City="Alameda", State="CA", ZipCode="94501", AreaCode="510" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92808", AreaCode="714" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92802", AreaCode="714" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93304", AreaCode="661" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93311", AreaCode="661" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92111", AreaCode="858" },
      new CustomerLocationData{ City="Burbank", State="CA", ZipCode="91504", AreaCode="818" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90022", AreaCode="323" },
      new CustomerLocationData{ City="Compton", State="CA", ZipCode="90220", AreaCode="310" },
      new CustomerLocationData{ City="Corona", State="CA", ZipCode="92881", AreaCode="951" },
      new CustomerLocationData{ City="Cupertino", State="CA", ZipCode="95014", AreaCode="408" },
      new CustomerLocationData{ City="Eureka", State="CA", ZipCode="95501", AreaCode="707" },
      new CustomerLocationData{ City="Folsom", State="CA", ZipCode="95630", AreaCode="916" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93710", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93722", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93726", AreaCode="559" },
      new CustomerLocationData{ City="Huntington Beach", State="CA", ZipCode="92646", AreaCode="714" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92602", AreaCode="714" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92606", AreaCode="949" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92618", AreaCode="949" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90048", AreaCode="323" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90024", AreaCode="310" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90041", AreaCode="323" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90016", AreaCode="310" },
      new CustomerLocationData{ City="Manhattan Beach", State="CA", ZipCode="90266", AreaCode="310" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92126", AreaCode="858" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94558", AreaCode="707" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94559", AreaCode="707" },
      new CustomerLocationData{ City="North Hollywood", State="CA", ZipCode="91606", AreaCode="818" },
      new CustomerLocationData{ City="Rancho Cucamonga", State="CA", ZipCode="91730", AreaCode="909" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95825", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95133", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95125", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95110", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95121", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95129", AreaCode="408" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Boulder", State="CO", ZipCode="80301", AreaCode="303" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80922", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80924", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80918", AreaCode="719" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80231", AreaCode="303" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80238", AreaCode="303" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Glenwood Springs", State="CO", ZipCode="81601", AreaCode="970" },
      new CustomerLocationData{ City="Grand Junction", State="CO", ZipCode="81505", AreaCode="970" },
      new CustomerLocationData{ City="Pueblo", State="CO", ZipCode="81008", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Westminster", State="CO", ZipCode="80023", AreaCode="303" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new CustomerLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new CustomerLocationData{ City="Waterbury", State="CT", ZipCode="06704", AreaCode="203" },
      new CustomerLocationData{ City="Waterford", State="CT", ZipCode="06385", AreaCode="860" },
      new CustomerLocationData{ City="Riverview", State="FL", ZipCode="33578", AreaCode="813" },
      new CustomerLocationData{ City="Cape Coral", State="FL", ZipCode="33909", AreaCode="239" },
      new CustomerLocationData{ City="Clearwater", State="FL", ZipCode="33759", AreaCode="727" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33189", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33156", AreaCode="305" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32803", AreaCode="407" },
      new CustomerLocationData{ City="Fort Lauderdale", State="FL", ZipCode="33306", AreaCode="954" },
      new CustomerLocationData{ City="Gainesville", State="FL", ZipCode="32608", AreaCode="352" },
      new CustomerLocationData{ City="Tampa", State="FL", ZipCode="33611", AreaCode="813" },
      new CustomerLocationData{ City="Greenacres", State="FL", ZipCode="33463", AreaCode="561" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32837", AreaCode="407" },
      new CustomerLocationData{ City="Jacksonville Beach", State="FL", ZipCode="32250", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32224", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32222", AreaCode="904" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33196", AreaCode="305" },
      new CustomerLocationData{ City="Naples", State="FL", ZipCode="34109", AreaCode="239" },
      new CustomerLocationData{ City="Sarasota", State="FL", ZipCode="34232", AreaCode="941" },
      new CustomerLocationData{ City="Kissimmee", State="FL", ZipCode="34747", AreaCode="321" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32514", AreaCode="850" },
      new CustomerLocationData{ City="Venice", State="FL", ZipCode="34293", AreaCode="941" },
      new CustomerLocationData{ City="Vero Beach", State="FL", ZipCode="32966", AreaCode="772" },
      new CustomerLocationData{ City="Athens", State="GA", ZipCode="30606", AreaCode="706" },
      new CustomerLocationData{ City="Athens", State="GA", ZipCode="30606", AreaCode="706" },
      new CustomerLocationData{ City="Athens", State="GA", ZipCode="30606", AreaCode="706" },
      new CustomerLocationData{ City="Athens", State="GA", ZipCode="30606", AreaCode="706" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30307", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30363", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30346", AreaCode="678" },
      new CustomerLocationData{ City="Augusta", State="GA", ZipCode="30909", AreaCode="706" },
      new CustomerLocationData{ City="Austell", State="GA", ZipCode="30106", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30326", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30324", AreaCode="404" },
      new CustomerLocationData{ City="Columbus", State="GA", ZipCode="31904", AreaCode="706" },
      new CustomerLocationData{ City="Fayetteville", State="GA", ZipCode="30214", AreaCode="770" },
      new CustomerLocationData{ City="Norcross", State="GA", ZipCode="30092", AreaCode="770" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30329", AreaCode="404" },
      new CustomerLocationData{ City="Savannah", State="GA", ZipCode="31404", AreaCode="912" },
      new CustomerLocationData{ City="Savannah", State="GA", ZipCode="31419", AreaCode="912" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70809", AreaCode="225" },
      new CustomerLocationData{ City="Lafayette", State="LA", ZipCode="70508", AreaCode="337" },
      new CustomerLocationData{ City="Lake Charles", State="LA", ZipCode="70601", AreaCode="337" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87112", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87113", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87114", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87110", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87111", AreaCode="505" },
      new CustomerLocationData{ City="Rio Rancho", State="NM", ZipCode="87124", AreaCode="505" },
      new CustomerLocationData{ City="Roswell", State="NM", ZipCode="88201", AreaCode="575" },
      new CustomerLocationData{ City="Santa Fe", State="NM", ZipCode="87507", AreaCode="505" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11217", AreaCode="718" },
      new CustomerLocationData{ City="Bronx", State="NY", ZipCode="10451", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11210", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11239", AreaCode="718" },
      new CustomerLocationData{ City="New York", State="NY", ZipCode="10035", AreaCode="212" },
      new CustomerLocationData{ City="Bronx", State="NY", ZipCode="10463", AreaCode="718" },
      new CustomerLocationData{ City="White Plains", State="NY", ZipCode="10601", AreaCode="914" },
      new CustomerLocationData{ City="Cary", State="NC", ZipCode="27519", AreaCode="919" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28227", AreaCode="704" },
      new CustomerLocationData{ City="Durham", State="NC", ZipCode="27713", AreaCode="919" },
      new CustomerLocationData{ City="Durham", State="NC", ZipCode="27707", AreaCode="919" },
      new CustomerLocationData{ City="Greensboro", State="NC", ZipCode="27408", AreaCode="336" },
      new CustomerLocationData{ City="Monroe", State="NC", ZipCode="28110", AreaCode="704" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27609", AreaCode="919" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27613", AreaCode="919" },
      new CustomerLocationData{ City="Toledo", State="OH", ZipCode="43612", AreaCode="419" },
      new CustomerLocationData{ City="Toledo", State="OH", ZipCode="43623", AreaCode="419" },
      new CustomerLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new CustomerLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new CustomerLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new CustomerLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new CustomerLocationData{ City="Allentown", State="PA", ZipCode="18104", AreaCode="610" },
      new CustomerLocationData{ City="Altoona", State="PA", ZipCode="16601", AreaCode="814" },
      new CustomerLocationData{ City="Pittsburgh", State="PA", ZipCode="15238", AreaCode="412" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19148", AreaCode="215" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19131", AreaCode="267" },
      new CustomerLocationData{ City="Pottstown", State="PA", ZipCode="19464", AreaCode="484" },
      new CustomerLocationData{ City="Lincoln", State="RI", ZipCode="02865", AreaCode="401" },
      new CustomerLocationData{ City="Smithfield", State="RI", ZipCode="02917", AreaCode="401" },
      new CustomerLocationData{ City="Columbia", State="SC", ZipCode="29229", AreaCode="803" },
      new CustomerLocationData{ City="Brentwood", State="TN", ZipCode="37027", AreaCode="615" },
      new CustomerLocationData{ City="Chattanooga", State="TN", ZipCode="37421", AreaCode="423" },
      new CustomerLocationData{ City="Clarksville", State="TN", ZipCode="37040", AreaCode="931" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37934", AreaCode="865" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37912", AreaCode="865" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37918", AreaCode="865" },
      new CustomerLocationData{ City="Memphis", State="TN", ZipCode="38125", AreaCode="901" },
      new CustomerLocationData{ City="Murfreesboro", State="TN", ZipCode="37129", AreaCode="615" },
      new CustomerLocationData{ City="Nashville", State="TN", ZipCode="37214", AreaCode="615" },
      new CustomerLocationData{ City="Nashville", State="TN", ZipCode="37209", AreaCode="615" },
      new CustomerLocationData{ City="Nashville", State="TN", ZipCode="37205", AreaCode="615" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78723", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78753", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78704", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78748", AreaCode="512" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78232", AreaCode="210" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76132", AreaCode="817" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75231", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75237", AreaCode="469" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76120", AreaCode="817" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79925", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79912", AreaCode="915" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78730", AreaCode="512" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77007", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77082", AreaCode="281" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77024", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77096", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77040", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77025", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77094", AreaCode="281" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75220", AreaCode="214" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79423", AreaCode="806" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79407", AreaCode="806" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78253", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78244", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78258", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78223", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78250", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78245", AreaCode="210" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77042", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77063", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77069", AreaCode="281" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84121", AreaCode="801" },
      new CustomerLocationData{ City="Layton", State="UT", ZipCode="84041", AreaCode="801" },
      new CustomerLocationData{ City="Riverdale", State="UT", ZipCode="84405", AreaCode="801" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84101", AreaCode="801" },
      new CustomerLocationData{ City="Charlottesville", State="VA", ZipCode="22911", AreaCode="434" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23320", AreaCode="757" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23322", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23462", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23454", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23453", AreaCode="757" },
      new CustomerLocationData{ City="Glen Allen", State="VA", ZipCode="23059", AreaCode="804" },
      new CustomerLocationData{ City="Williamsburg", State="VA", ZipCode="23185", AreaCode="757" },
      new CustomerLocationData{ City="Williamsburg", State="VA", ZipCode="23188", AreaCode="757" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new CustomerLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" }
    };

    private static CustomerLocationData[] CustomerLocations3 = new CustomerLocationData[]{
      new CustomerLocationData{ City="Mobile", State="AL", ZipCode="36695", AreaCode="251" },
      new CustomerLocationData{ City="Mobile", State="AL", ZipCode="36606", AreaCode="251" },
      new CustomerLocationData{ City="Birmingham", State="AL", ZipCode="35242", AreaCode="205" },
      new CustomerLocationData{ City="Birmingham", State="AL", ZipCode="35226", AreaCode="205" },
      new CustomerLocationData{ City="Tuscaloosa", State="AL", ZipCode="35404", AreaCode="205" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85044", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85018", AreaCode="602" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85022", AreaCode="602" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85266", AreaCode="480" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85250", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85042", AreaCode="602" },
      new CustomerLocationData{ City="Surprise", State="AZ", ZipCode="85374", AreaCode="623" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85281", AreaCode="480" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85283", AreaCode="480" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85711", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85716", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85715", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85741", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85705", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85748", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85714", AreaCode="520" },
      new CustomerLocationData{ City="Alameda", State="CA", ZipCode="94501", AreaCode="510" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92808", AreaCode="714" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92802", AreaCode="714" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93304", AreaCode="661" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93306", AreaCode="661" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93312", AreaCode="661" },
      new CustomerLocationData{ City="Bakersfield", State="CA", ZipCode="93311", AreaCode="661" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92111", AreaCode="858" },
      new CustomerLocationData{ City="Burbank", State="CA", ZipCode="91504", AreaCode="818" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90022", AreaCode="323" },
      new CustomerLocationData{ City="Compton", State="CA", ZipCode="90220", AreaCode="310" },
      new CustomerLocationData{ City="Corona", State="CA", ZipCode="92881", AreaCode="951" },
      new CustomerLocationData{ City="Cupertino", State="CA", ZipCode="95014", AreaCode="408" },
      new CustomerLocationData{ City="Eureka", State="CA", ZipCode="95501", AreaCode="707" },
      new CustomerLocationData{ City="Folsom", State="CA", ZipCode="95630", AreaCode="916" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93710", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93722", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93726", AreaCode="559" },
      new CustomerLocationData{ City="Huntington Beach", State="CA", ZipCode="92646", AreaCode="714" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92602", AreaCode="714" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92606", AreaCode="949" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92618", AreaCode="949" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90048", AreaCode="323" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90017", AreaCode="213" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90024", AreaCode="310" },
      new CustomerLocationData{ City="Long Beach", State="CA", ZipCode="90815", AreaCode="562" },
      new CustomerLocationData{ City="Long Beach", State="CA", ZipCode="90805", AreaCode="562" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90041", AreaCode="323" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90016", AreaCode="310" },
      new CustomerLocationData{ City="Manhattan Beach", State="CA", ZipCode="90266", AreaCode="310" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92126", AreaCode="858" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94558", AreaCode="707" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94559", AreaCode="707" },
      new CustomerLocationData{ City="North Hollywood", State="CA", ZipCode="91606", AreaCode="818" },
      new CustomerLocationData{ City="Rancho Cucamonga", State="CA", ZipCode="91730", AreaCode="909" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95825", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95817", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95841", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95834", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95133", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95125", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95110", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95121", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95132", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95134", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95123", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95123", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95122", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95124", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95129", AreaCode="408" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Boulder", State="CO", ZipCode="80301", AreaCode="303" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80922", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80924", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80918", AreaCode="719" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80231", AreaCode="303" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80238", AreaCode="303" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Glenwood Springs", State="CO", ZipCode="81601", AreaCode="970" },
      new CustomerLocationData{ City="Grand Junction", State="CO", ZipCode="81505", AreaCode="970" },
      new CustomerLocationData{ City="Pueblo", State="CO", ZipCode="81008", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Westminster", State="CO", ZipCode="80023", AreaCode="303" },
      new CustomerLocationData{ City="Westminster", State="CO", ZipCode="80021", AreaCode="303" },
      new CustomerLocationData{ City="New Britain", State="CT", ZipCode="06053", AreaCode="860" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="North Haven", State="CT", ZipCode="06473", AreaCode="203" },
      new CustomerLocationData{ City="Stamford", State="CT", ZipCode="06901", AreaCode="203" },
      new CustomerLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new CustomerLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new CustomerLocationData{ City="Waterbury", State="CT", ZipCode="06704", AreaCode="203" },
      new CustomerLocationData{ City="Waterford", State="CT", ZipCode="06385", AreaCode="860" },
      new CustomerLocationData{ City="Windsor", State="CT", ZipCode="06095", AreaCode="860" },
      new CustomerLocationData{ City="Brandon", State="FL", ZipCode="33511", AreaCode="813" },
      new CustomerLocationData{ City="Riverview", State="FL", ZipCode="33578", AreaCode="813" },
      new CustomerLocationData{ City="Cape Coral", State="FL", ZipCode="33909", AreaCode="239" },
      new CustomerLocationData{ City="Cape Coral", State="FL", ZipCode="33914", AreaCode="239" },
      new CustomerLocationData{ City="Clearwater", State="FL", ZipCode="33759", AreaCode="727" },
      new CustomerLocationData{ City="Clermont", State="FL", ZipCode="34711", AreaCode="352" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33189", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33156", AreaCode="305" },
      new CustomerLocationData{ City="Daytona Beach", State="FL", ZipCode="32114", AreaCode="386" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32803", AreaCode="407" },
      new CustomerLocationData{ City="Fort Lauderdale", State="FL", ZipCode="33306", AreaCode="954" },
      new CustomerLocationData{ City="Gainesville", State="FL", ZipCode="32608", AreaCode="352" },
      new CustomerLocationData{ City="Tampa", State="FL", ZipCode="33611", AreaCode="813" },
      new CustomerLocationData{ City="Greenacres", State="FL", ZipCode="33463", AreaCode="561" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32837", AreaCode="407" },
      new CustomerLocationData{ City="Jacksonville Beach", State="FL", ZipCode="32250", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32224", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32257", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32246", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32222", AreaCode="904" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33196", AreaCode="305" },
      new CustomerLocationData{ City="Naples", State="FL", ZipCode="34119", AreaCode="239" },
      new CustomerLocationData{ City="Naples", State="FL", ZipCode="34109", AreaCode="239" },
      new CustomerLocationData{ City="Wesley Chapel", State="FL", ZipCode="33544", AreaCode="813" },
      new CustomerLocationData{ City="Tampa", State="FL", ZipCode="33618", AreaCode="813" },
      new CustomerLocationData{ City="Sarasota", State="FL", ZipCode="34232", AreaCode="941" },
      new CustomerLocationData{ City="Kissimmee", State="FL", ZipCode="34747", AreaCode="321" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32514", AreaCode="850" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32503", AreaCode="850" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32506", AreaCode="850" },
      new CustomerLocationData{ City="Tallahassee", State="FL", ZipCode="32309", AreaCode="850" },
      new CustomerLocationData{ City="Tallahassee", State="FL", ZipCode="32301", AreaCode="850" },
      new CustomerLocationData{ City="Venice", State="FL", ZipCode="34293", AreaCode="941" },
      new CustomerLocationData{ City="Vero Beach", State="FL", ZipCode="32966", AreaCode="772" },
      new CustomerLocationData{ City="Acworth", State="GA", ZipCode="30101", AreaCode="678" },
      new CustomerLocationData{ City="Athens", State="GA", ZipCode="30606", AreaCode="706" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30307", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30363", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30346", AreaCode="678" },
      new CustomerLocationData{ City="Augusta", State="GA", ZipCode="30909", AreaCode="706" },
      new CustomerLocationData{ City="Austell", State="GA", ZipCode="30106", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30326", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30324", AreaCode="404" },
      new CustomerLocationData{ City="Columbus", State="GA", ZipCode="31904", AreaCode="706" },
      new CustomerLocationData{ City="Fayetteville", State="GA", ZipCode="30214", AreaCode="770" },
      new CustomerLocationData{ City="Norcross", State="GA", ZipCode="30092", AreaCode="770" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30329", AreaCode="404" },
      new CustomerLocationData{ City="Savannah", State="GA", ZipCode="31404", AreaCode="912" },
      new CustomerLocationData{ City="Savannah", State="GA", ZipCode="31419", AreaCode="912" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70816", AreaCode="225" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70809", AreaCode="225" },
      new CustomerLocationData{ City="Covington", State="LA", ZipCode="70433", AreaCode="985" },
      new CustomerLocationData{ City="Lafayette", State="LA", ZipCode="70501", AreaCode="337" },
      new CustomerLocationData{ City="Lafayette", State="LA", ZipCode="70508", AreaCode="337" },
      new CustomerLocationData{ City="Lake Charles", State="LA", ZipCode="70601", AreaCode="337" },
      new CustomerLocationData{ City="Shreveport", State="LA", ZipCode="71105", AreaCode="318" },
      new CustomerLocationData{ City="Dorchester", State="MA", ZipCode="02125", AreaCode="617" },
      new CustomerLocationData{ City="Braintree", State="MA", ZipCode="02184", AreaCode="781" },
      new CustomerLocationData{ City="Hanover", State="MA", ZipCode="02339", AreaCode="781" },
      new CustomerLocationData{ City="Marlborough", State="MA", ZipCode="01752", AreaCode="508" },
      new CustomerLocationData{ City="Marlborough", State="MA", ZipCode="01752", AreaCode="508" },
      new CustomerLocationData{ City="North Attleboro", State="MA", ZipCode="02760", AreaCode="508" },
      new CustomerLocationData{ City="North Dartmouth", State="MA", ZipCode="02747", AreaCode="508" },
      new CustomerLocationData{ City="Revere", State="MA", ZipCode="02151", AreaCode="781" },
      new CustomerLocationData{ City="Saugus", State="MA", ZipCode="01906", AreaCode="781" },
      new CustomerLocationData{ City="Wareham", State="MA", ZipCode="02571", AreaCode="508" },
      new CustomerLocationData{ City="Worcester", State="MA", ZipCode="01605", AreaCode="508" },
      new CustomerLocationData{ City="Bedford", State="NH", ZipCode="03110", AreaCode="603" },
      new CustomerLocationData{ City="Concord", State="NH", ZipCode="03301", AreaCode="603" },
      new CustomerLocationData{ City="Nashua", State="NH", ZipCode="03063", AreaCode="603" },
      new CustomerLocationData{ City="Nashua", State="NH", ZipCode="03060", AreaCode="603" },
      new CustomerLocationData{ City="Burlington", State="NJ", ZipCode="08016", AreaCode="609" },
      new CustomerLocationData{ City="Cherry Hill", State="NJ", ZipCode="08002", AreaCode="856" },
      new CustomerLocationData{ City="Clark", State="NJ", ZipCode="07066", AreaCode="732" },
      new CustomerLocationData{ City="Edgewater", State="NJ", ZipCode="07020", AreaCode="201" },
      new CustomerLocationData{ City="Hackensack", State="NJ", ZipCode="07601", AreaCode="201" },
      new CustomerLocationData{ City="Jersey City", State="NJ", ZipCode="07310", AreaCode="201" },
      new CustomerLocationData{ City="Mays Landing", State="NJ", ZipCode="08330", AreaCode="609" },
      new CustomerLocationData{ City="Middletown", State="NJ", ZipCode="07748", AreaCode="732" },
      new CustomerLocationData{ City="Mount Laurel", State="NJ", ZipCode="08054", AreaCode="856" },
      new CustomerLocationData{ City="Paramus", State="NJ", ZipCode="07652", AreaCode="201" },
      new CustomerLocationData{ City="Princeton", State="NJ", ZipCode="08540", AreaCode="609" },
      new CustomerLocationData{ City="Riverdale", State="NJ", ZipCode="07457", AreaCode="973" },
      new CustomerLocationData{ City="Rockaway", State="NJ", ZipCode="07866", AreaCode="973" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87112", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87113", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87114", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87110", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87111", AreaCode="505" },
      new CustomerLocationData{ City="Rio Rancho", State="NM", ZipCode="87124", AreaCode="505" },
      new CustomerLocationData{ City="Roswell", State="NM", ZipCode="88201", AreaCode="575" },
      new CustomerLocationData{ City="Santa Fe", State="NM", ZipCode="87507", AreaCode="505" },
      new CustomerLocationData{ City="Amsterdam", State="NY", ZipCode="12010", AreaCode="518" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11217", AreaCode="718" },
      new CustomerLocationData{ City="Amherst", State="NY", ZipCode="14228", AreaCode="716" },
      new CustomerLocationData{ City="Bronx", State="NY", ZipCode="10451", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11210", AreaCode="718" },
      new CustomerLocationData{ City="Syracuse", State="NY", ZipCode="13219", AreaCode="315" },
      new CustomerLocationData{ City="Flushing", State="NY", ZipCode="11354", AreaCode="347" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11239", AreaCode="718" },
      new CustomerLocationData{ City="Schenectady", State="NY", ZipCode="12302", AreaCode="518" },
      new CustomerLocationData{ City="Rochester", State="NY", ZipCode="14626", AreaCode="585" },
      new CustomerLocationData{ City="New York", State="NY", ZipCode="10035", AreaCode="212" },
      new CustomerLocationData{ City="Mount Vernon", State="NY", ZipCode="10550", AreaCode="914" },
      new CustomerLocationData{ City="Schenectady", State="NY", ZipCode="12304", AreaCode="518" },
      new CustomerLocationData{ City="Buffalo", State="NY", ZipCode="14216", AreaCode="716" },
      new CustomerLocationData{ City="Bronx", State="NY", ZipCode="10463", AreaCode="718" },
      new CustomerLocationData{ City="Riverhead", State="NY", ZipCode="11901", AreaCode="631" },
      new CustomerLocationData{ City="White Plains", State="NY", ZipCode="10601", AreaCode="914" },
      new CustomerLocationData{ City="Asheville", State="NC", ZipCode="28805", AreaCode="828" },
      new CustomerLocationData{ City="Cary", State="NC", ZipCode="27518", AreaCode="919" },
      new CustomerLocationData{ City="Cary", State="NC", ZipCode="27519", AreaCode="919" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28227", AreaCode="704" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28277", AreaCode="704" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28204", AreaCode="704" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28216", AreaCode="704" },
      new CustomerLocationData{ City="Durham", State="NC", ZipCode="27713", AreaCode="919" },
      new CustomerLocationData{ City="Durham", State="NC", ZipCode="27707", AreaCode="919" },
      new CustomerLocationData{ City="Greensboro", State="NC", ZipCode="27408", AreaCode="336" },
      new CustomerLocationData{ City="Greensboro", State="NC", ZipCode="27407", AreaCode="336" },
      new CustomerLocationData{ City="Greensboro", State="NC", ZipCode="27410", AreaCode="336" },
      new CustomerLocationData{ City="Greenville", State="NC", ZipCode="27834", AreaCode="252" },
      new CustomerLocationData{ City="Hickory", State="NC", ZipCode="28602", AreaCode="828" },
      new CustomerLocationData{ City="Monroe", State="NC", ZipCode="28110", AreaCode="704" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27609", AreaCode="919" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27613", AreaCode="919" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27616", AreaCode="919" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27617", AreaCode="919" },
      new CustomerLocationData{ City="Wake Forest", State="NC", ZipCode="27587", AreaCode="919" },
      new CustomerLocationData{ City="Winston Salem", State="NC", ZipCode="27105", AreaCode="336" },
      new CustomerLocationData{ City="Winston Salem", State="NC", ZipCode="27103", AreaCode="336" },
      new CustomerLocationData{ City="Amherst", State="OH", ZipCode="44001", AreaCode="440" },
      new CustomerLocationData{ City="Beavercreek", State="OH", ZipCode="45431", AreaCode="937" },
      new CustomerLocationData{ City="Cincinnati", State="OH", ZipCode="45255", AreaCode="513" },
      new CustomerLocationData{ City="Cincinnati", State="OH", ZipCode="45209", AreaCode="513" },
      new CustomerLocationData{ City="Cleveland", State="OH", ZipCode="44109", AreaCode="216" },
      new CustomerLocationData{ City="Cleveland", State="OH", ZipCode="44111", AreaCode="216" },
      new CustomerLocationData{ City="Cincinnati", State="OH", ZipCode="45251", AreaCode="513" },
      new CustomerLocationData{ City="Columbus", State="OH", ZipCode="43212", AreaCode="614" },
      new CustomerLocationData{ City="Columbus", State="OH", ZipCode="43219", AreaCode="614" },
      new CustomerLocationData{ City="Akron", State="OH", ZipCode="44312", AreaCode="330" },
      new CustomerLocationData{ City="Columbus", State="OH", ZipCode="43240", AreaCode="614" },
      new CustomerLocationData{ City="Dayton", State="OH", ZipCode="45440", AreaCode="937" },
      new CustomerLocationData{ City="Toledo", State="OH", ZipCode="43612", AreaCode="419" },
      new CustomerLocationData{ City="Toledo", State="OH", ZipCode="43623", AreaCode="419" },
      new CustomerLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new CustomerLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new CustomerLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97205", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97220", AreaCode="971" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new CustomerLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new CustomerLocationData{ City="Springfield", State="OR", ZipCode="97477", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97006", AreaCode="503" },
      new CustomerLocationData{ City="Allentown", State="PA", ZipCode="18104", AreaCode="610" },
      new CustomerLocationData{ City="Altoona", State="PA", ZipCode="16601", AreaCode="814" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19150", AreaCode="267" },
      new CustomerLocationData{ City="Glen Mills", State="PA", ZipCode="19342", AreaCode="610" },
      new CustomerLocationData{ City="Erie", State="PA", ZipCode="16509", AreaCode="814" },
      new CustomerLocationData{ City="Reading", State="PA", ZipCode="19606", AreaCode="484" },
      new CustomerLocationData{ City="Allentown", State="PA", ZipCode="18109", AreaCode="610" },
      new CustomerLocationData{ City="Pittsburgh", State="PA", ZipCode="15238", AreaCode="412" },
      new CustomerLocationData{ City="Harrisburg", State="PA", ZipCode="17111", AreaCode="717" },
      new CustomerLocationData{ City="Harrisburg", State="PA", ZipCode="17112", AreaCode="717" },
      new CustomerLocationData{ City="Lancaster", State="PA", ZipCode="17602", AreaCode="717" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19134", AreaCode="215" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19152", AreaCode="267" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19116", AreaCode="215" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19148", AreaCode="215" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19131", AreaCode="267" },
      new CustomerLocationData{ City="Pottstown", State="PA", ZipCode="19464", AreaCode="484" },
      new CustomerLocationData{ City="Lincoln", State="RI", ZipCode="02865", AreaCode="401" },
      new CustomerLocationData{ City="Smithfield", State="RI", ZipCode="02917", AreaCode="401" },
      new CustomerLocationData{ City="Warwick", State="RI", ZipCode="02886", AreaCode="401" },
      new CustomerLocationData{ City="Warwick", State="RI", ZipCode="02886", AreaCode="401" },
      new CustomerLocationData{ City="Aiken", State="SC", ZipCode="29803", AreaCode="803" },
      new CustomerLocationData{ City="Charleston", State="SC", ZipCode="29407", AreaCode="843" },
      new CustomerLocationData{ City="Columbia", State="SC", ZipCode="29209", AreaCode="803" },
      new CustomerLocationData{ City="Columbia", State="SC", ZipCode="29229", AreaCode="803" },
      new CustomerLocationData{ City="Columbia", State="SC", ZipCode="29212", AreaCode="803" },
      new CustomerLocationData{ City="Florence", State="SC", ZipCode="29501", AreaCode="843" },
      new CustomerLocationData{ City="Myrtle Beach", State="SC", ZipCode="29577", AreaCode="843" },
      new CustomerLocationData{ City="Myrtle Beach", State="SC", ZipCode="29588", AreaCode="843" },
      new CustomerLocationData{ City="Brentwood", State="TN", ZipCode="37027", AreaCode="615" },
      new CustomerLocationData{ City="Chattanooga", State="TN", ZipCode="37421", AreaCode="423" },
      new CustomerLocationData{ City="Clarksville", State="TN", ZipCode="37040", AreaCode="931" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37934", AreaCode="865" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37912", AreaCode="865" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37918", AreaCode="865" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37922", AreaCode="865" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37919", AreaCode="865" },
      new CustomerLocationData{ City="Maryville", State="TN", ZipCode="37801", AreaCode="865" },
      new CustomerLocationData{ City="Memphis", State="TN", ZipCode="38117", AreaCode="901" },
      new CustomerLocationData{ City="Memphis", State="TN", ZipCode="38119", AreaCode="901" },
      new CustomerLocationData{ City="Memphis", State="TN", ZipCode="38133", AreaCode="901" },
      new CustomerLocationData{ City="Memphis", State="TN", ZipCode="38125", AreaCode="901" },
      new CustomerLocationData{ City="Murfreesboro", State="TN", ZipCode="37129", AreaCode="615" },
      new CustomerLocationData{ City="Nashville", State="TN", ZipCode="37214", AreaCode="615" },
      new CustomerLocationData{ City="Nashville", State="TN", ZipCode="37209", AreaCode="615" },
      new CustomerLocationData{ City="Nashville", State="TN", ZipCode="37205", AreaCode="615" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78209", AreaCode="210" },
      new CustomerLocationData{ City="Amarillo", State="TX", ZipCode="79121", AreaCode="806" },
      new CustomerLocationData{ City="Arlington", State="TX", ZipCode="76015", AreaCode="817" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78759", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78723", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78753", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78717", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78758", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78749", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78704", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78748", AreaCode="512" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78232", AreaCode="210" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76132", AreaCode="817" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75231", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75237", AreaCode="469" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76120", AreaCode="817" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79925", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79912", AreaCode="915" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78730", AreaCode="512" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77007", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77082", AreaCode="281" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77024", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77096", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77040", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77025", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77094", AreaCode="281" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75220", AreaCode="214" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79423", AreaCode="806" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79407", AreaCode="806" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78253", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78244", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78258", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78223", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78250", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78245", AreaCode="210" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77042", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77063", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77069", AreaCode="281" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84121", AreaCode="801" },
      new CustomerLocationData{ City="Layton", State="UT", ZipCode="84041", AreaCode="801" },
      new CustomerLocationData{ City="Riverdale", State="UT", ZipCode="84405", AreaCode="801" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84101", AreaCode="801" },
      new CustomerLocationData{ City="Charlottesville", State="VA", ZipCode="22911", AreaCode="434" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23320", AreaCode="757" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23322", AreaCode="757" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23321", AreaCode="757" },
      new CustomerLocationData{ City="Richmond", State="VA", ZipCode="23225", AreaCode="804" },
      new CustomerLocationData{ City="Fredericksburg", State="VA", ZipCode="22401", AreaCode="540" },
      new CustomerLocationData{ City="Fredericksburg", State="VA", ZipCode="22407", AreaCode="540" },
      new CustomerLocationData{ City="Richmond", State="VA", ZipCode="23230", AreaCode="804" },
      new CustomerLocationData{ City="Richmond", State="VA", ZipCode="23231", AreaCode="804" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23451", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23462", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23454", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23453", AreaCode="757" },
      new CustomerLocationData{ City="Glen Allen", State="VA", ZipCode="23059", AreaCode="804" },
      new CustomerLocationData{ City="Williamsburg", State="VA", ZipCode="23185", AreaCode="757" },
      new CustomerLocationData{ City="Williamsburg", State="VA", ZipCode="23188", AreaCode="757" },
      new CustomerLocationData{ City="Winchester", State="VA", ZipCode="22603", AreaCode="540" },
      new CustomerLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new CustomerLocationData{ City="Issaquah", State="WA", ZipCode="98027", AreaCode="425" },
      new CustomerLocationData{ City="Spokane", State="WA", ZipCode="99218", AreaCode="509" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new CustomerLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" }
    };

    private static CustomerLocationData[] CustomerLocations4 = new CustomerLocationData[]{
      new CustomerLocationData{ City="Mobile", State="AL", ZipCode="36695", AreaCode="251" },
      new CustomerLocationData{ City="Mobile", State="AL", ZipCode="36606", AreaCode="251" },
      new CustomerLocationData{ City="Birmingham", State="AL", ZipCode="35242", AreaCode="205" },
      new CustomerLocationData{ City="Birmingham", State="AL", ZipCode="35226", AreaCode="205" },
      new CustomerLocationData{ City="Tuscaloosa", State="AL", ZipCode="35404", AreaCode="205" },
      new CustomerLocationData{ City="Tuscaloosa", State="AL", ZipCode="35404", AreaCode="205" },
      new CustomerLocationData{ City="Tuscaloosa", State="AL", ZipCode="35404", AreaCode="205" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85044", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85018", AreaCode="602" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85022", AreaCode="602" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85266", AreaCode="480" },
      new CustomerLocationData{ City="Scottsdale", State="AZ", ZipCode="85250", AreaCode="480" },
      new CustomerLocationData{ City="Phoenix", State="AZ", ZipCode="85042", AreaCode="602" },
      new CustomerLocationData{ City="Surprise", State="AZ", ZipCode="85374", AreaCode="623" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85281", AreaCode="480" },
      new CustomerLocationData{ City="Tempe", State="AZ", ZipCode="85283", AreaCode="480" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85711", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85716", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85748", AreaCode="520" },
      new CustomerLocationData{ City="Tucson", State="AZ", ZipCode="85714", AreaCode="520" },
      new CustomerLocationData{ City="Alameda", State="CA", ZipCode="94501", AreaCode="510" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92808", AreaCode="714" },
      new CustomerLocationData{ City="Anaheim", State="CA", ZipCode="92802", AreaCode="714" },
      new CustomerLocationData{ City="San Diego", State="CA", ZipCode="92111", AreaCode="858" },
      new CustomerLocationData{ City="Burbank", State="CA", ZipCode="91504", AreaCode="818" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90022", AreaCode="323" },
      new CustomerLocationData{ City="Compton", State="CA", ZipCode="90220", AreaCode="310" },
      new CustomerLocationData{ City="Eureka", State="CA", ZipCode="95501", AreaCode="707" },
      new CustomerLocationData{ City="Folsom", State="CA", ZipCode="95630", AreaCode="916" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93710", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93722", AreaCode="559" },
      new CustomerLocationData{ City="Fresno", State="CA", ZipCode="93726", AreaCode="559" },
      new CustomerLocationData{ City="Huntington Beach", State="CA", ZipCode="92646", AreaCode="714" },
      new CustomerLocationData{ City="Irvine", State="CA", ZipCode="92602", AreaCode="714" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90048", AreaCode="323" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90017", AreaCode="213" },
      new CustomerLocationData{ City="Long Beach", State="CA", ZipCode="90815", AreaCode="562" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90041", AreaCode="323" },
      new CustomerLocationData{ City="Los Angeles", State="CA", ZipCode="90016", AreaCode="310" },
      new CustomerLocationData{ City="Manhattan Beach", State="CA", ZipCode="90266", AreaCode="310" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94558", AreaCode="707" },
      new CustomerLocationData{ City="Napa", State="CA", ZipCode="94559", AreaCode="707" },
      new CustomerLocationData{ City="Rancho Cucamonga", State="CA", ZipCode="91730", AreaCode="909" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95825", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new CustomerLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new CustomerLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95133", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95125", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95134", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95124", AreaCode="408" },
      new CustomerLocationData{ City="San Jose", State="CA", ZipCode="95129", AreaCode="408" },
      new CustomerLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new CustomerLocationData{ City="Boulder", State="CO", ZipCode="80301", AreaCode="303" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80918", AreaCode="719" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80231", AreaCode="303" },
      new CustomerLocationData{ City="Denver", State="CO", ZipCode="80238", AreaCode="303" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new CustomerLocationData{ City="Glenwood Springs", State="CO", ZipCode="81601", AreaCode="970" },
      new CustomerLocationData{ City="Grand Junction", State="CO", ZipCode="81505", AreaCode="970" },
      new CustomerLocationData{ City="Pueblo", State="CO", ZipCode="81008", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new CustomerLocationData{ City="Westminster", State="CO", ZipCode="80023", AreaCode="303" },
      new CustomerLocationData{ City="Westminster", State="CO", ZipCode="80021", AreaCode="303" },
      new CustomerLocationData{ City="New Britain", State="CT", ZipCode="06053", AreaCode="860" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new CustomerLocationData{ City="North Haven", State="CT", ZipCode="06473", AreaCode="203" },
      new CustomerLocationData{ City="Stamford", State="CT", ZipCode="06901", AreaCode="203" },
      new CustomerLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new CustomerLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new CustomerLocationData{ City="Waterbury", State="CT", ZipCode="06704", AreaCode="203" },
      new CustomerLocationData{ City="Waterford", State="CT", ZipCode="06385", AreaCode="860" },
      new CustomerLocationData{ City="Windsor", State="CT", ZipCode="06095", AreaCode="860" },
      new CustomerLocationData{ City="Brandon", State="FL", ZipCode="33511", AreaCode="813" },
      new CustomerLocationData{ City="Riverview", State="FL", ZipCode="33578", AreaCode="813" },
      new CustomerLocationData{ City="Cape Coral", State="FL", ZipCode="33909", AreaCode="239" },
      new CustomerLocationData{ City="Cape Coral", State="FL", ZipCode="33914", AreaCode="239" },
      new CustomerLocationData{ City="Clearwater", State="FL", ZipCode="33759", AreaCode="727" },
      new CustomerLocationData{ City="Clermont", State="FL", ZipCode="34711", AreaCode="352" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33189", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33156", AreaCode="305" },
      new CustomerLocationData{ City="Daytona Beach", State="FL", ZipCode="32114", AreaCode="386" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32803", AreaCode="407" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32803", AreaCode="407" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32803", AreaCode="407" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32803", AreaCode="407" },
      new CustomerLocationData{ City="Fort Lauderdale", State="FL", ZipCode="33306", AreaCode="954" },
      new CustomerLocationData{ City="Gainesville", State="FL", ZipCode="32608", AreaCode="352" },
      new CustomerLocationData{ City="Tampa", State="FL", ZipCode="33611", AreaCode="813" },
      new CustomerLocationData{ City="Greenacres", State="FL", ZipCode="33463", AreaCode="561" },
      new CustomerLocationData{ City="Orlando", State="FL", ZipCode="32837", AreaCode="407" },
      new CustomerLocationData{ City="Jacksonville Beach", State="FL", ZipCode="32250", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32224", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32257", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32246", AreaCode="904" },
      new CustomerLocationData{ City="Jacksonville", State="FL", ZipCode="32222", AreaCode="904" },
      new CustomerLocationData{ City="Miami", State="FL", ZipCode="33196", AreaCode="305" },
      new CustomerLocationData{ City="Naples", State="FL", ZipCode="34119", AreaCode="239" },
      new CustomerLocationData{ City="Naples", State="FL", ZipCode="34109", AreaCode="239" },
      new CustomerLocationData{ City="Wesley Chapel", State="FL", ZipCode="33544", AreaCode="813" },
      new CustomerLocationData{ City="Wesley Chapel", State="FL", ZipCode="33544", AreaCode="813" },
      new CustomerLocationData{ City="Wesley Chapel", State="FL", ZipCode="33544", AreaCode="813" },
      new CustomerLocationData{ City="Wesley Chapel", State="FL", ZipCode="33544", AreaCode="813" },
      new CustomerLocationData{ City="Tampa", State="FL", ZipCode="33618", AreaCode="813" },
      new CustomerLocationData{ City="Sarasota", State="FL", ZipCode="34232", AreaCode="941" },
      new CustomerLocationData{ City="Kissimmee", State="FL", ZipCode="34747", AreaCode="321" },
      new CustomerLocationData{ City="Kissimmee", State="FL", ZipCode="34747", AreaCode="321" },
      new CustomerLocationData{ City="Kissimmee", State="FL", ZipCode="34747", AreaCode="321" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32514", AreaCode="850" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32503", AreaCode="850" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32503", AreaCode="850" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32503", AreaCode="850" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32503", AreaCode="850" },
      new CustomerLocationData{ City="Pensacola", State="FL", ZipCode="32506", AreaCode="850" },
      new CustomerLocationData{ City="Tallahassee", State="FL", ZipCode="32309", AreaCode="850" },
      new CustomerLocationData{ City="Tallahassee", State="FL", ZipCode="32301", AreaCode="850" },
      new CustomerLocationData{ City="Venice", State="FL", ZipCode="34293", AreaCode="941" },
      new CustomerLocationData{ City="Venice", State="FL", ZipCode="34293", AreaCode="941" },
      new CustomerLocationData{ City="Venice", State="FL", ZipCode="34293", AreaCode="941" },
      new CustomerLocationData{ City="Venice", State="FL", ZipCode="34293", AreaCode="941" },
      new CustomerLocationData{ City="Venice", State="FL", ZipCode="34292", AreaCode="941" },
      new CustomerLocationData{ City="Vero Beach", State="FL", ZipCode="32966", AreaCode="772" },
      new CustomerLocationData{ City="Acworth", State="GA", ZipCode="30101", AreaCode="678" },
      new CustomerLocationData{ City="Athens", State="GA", ZipCode="30606", AreaCode="706" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30307", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30307", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30307", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30363", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30346", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30346", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30346", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30346", AreaCode="678" },
      new CustomerLocationData{ City="Augusta", State="GA", ZipCode="30909", AreaCode="706" },
      new CustomerLocationData{ City="Austell", State="GA", ZipCode="30106", AreaCode="678" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30326", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30326", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30326", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30326", AreaCode="404" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30324", AreaCode="404" },
      new CustomerLocationData{ City="Columbus", State="GA", ZipCode="31904", AreaCode="706" },
      new CustomerLocationData{ City="Fayetteville", State="GA", ZipCode="30214", AreaCode="770" },
      new CustomerLocationData{ City="Norcross", State="GA", ZipCode="30092", AreaCode="770" },
      new CustomerLocationData{ City="Atlanta", State="GA", ZipCode="30329", AreaCode="404" },
      new CustomerLocationData{ City="Savannah", State="GA", ZipCode="31404", AreaCode="912" },
      new CustomerLocationData{ City="Savannah", State="GA", ZipCode="31404", AreaCode="912" },
      new CustomerLocationData{ City="Savannah", State="GA", ZipCode="31419", AreaCode="912" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70816", AreaCode="225" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70809", AreaCode="225" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70809", AreaCode="225" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70809", AreaCode="225" },
      new CustomerLocationData{ City="Baton Rouge", State="LA", ZipCode="70809", AreaCode="225" },
      new CustomerLocationData{ City="Covington", State="LA", ZipCode="70433", AreaCode="985" },
      new CustomerLocationData{ City="Lafayette", State="LA", ZipCode="70501", AreaCode="337" },
      new CustomerLocationData{ City="Lafayette", State="LA", ZipCode="70508", AreaCode="337" },
      new CustomerLocationData{ City="Lake Charles", State="LA", ZipCode="70601", AreaCode="337" },
      new CustomerLocationData{ City="Shreveport", State="LA", ZipCode="71105", AreaCode="318" },
      new CustomerLocationData{ City="Dorchester", State="MA", ZipCode="02125", AreaCode="617" },
      new CustomerLocationData{ City="Dorchester", State="MA", ZipCode="02125", AreaCode="617" },
      new CustomerLocationData{ City="Dorchester", State="MA", ZipCode="02125", AreaCode="617" },
      new CustomerLocationData{ City="Dorchester", State="MA", ZipCode="02125", AreaCode="617" },
      new CustomerLocationData{ City="Braintree", State="MA", ZipCode="02184", AreaCode="781" },
      new CustomerLocationData{ City="Hanover", State="MA", ZipCode="02339", AreaCode="781" },
      new CustomerLocationData{ City="Marlborough", State="MA", ZipCode="01752", AreaCode="508" },
      new CustomerLocationData{ City="Marlborough", State="MA", ZipCode="01752", AreaCode="508" },
      new CustomerLocationData{ City="North Attleboro", State="MA", ZipCode="02760", AreaCode="508" },
      new CustomerLocationData{ City="North Dartmouth", State="MA", ZipCode="02747", AreaCode="508" },
      new CustomerLocationData{ City="Revere", State="MA", ZipCode="02151", AreaCode="781" },
      new CustomerLocationData{ City="Saugus", State="MA", ZipCode="01906", AreaCode="781" },
      new CustomerLocationData{ City="Wareham", State="MA", ZipCode="02571", AreaCode="508" },
      new CustomerLocationData{ City="Worcester", State="MA", ZipCode="01605", AreaCode="508" },
      new CustomerLocationData{ City="Bedford", State="NH", ZipCode="03110", AreaCode="603" },
      new CustomerLocationData{ City="Bedford", State="NH", ZipCode="03110", AreaCode="603" },
      new CustomerLocationData{ City="Concord", State="NH", ZipCode="03301", AreaCode="603" },
      new CustomerLocationData{ City="Nashua", State="NH", ZipCode="03063", AreaCode="603" },
      new CustomerLocationData{ City="Nashua", State="NH", ZipCode="03060", AreaCode="603" },
      new CustomerLocationData{ City="Burlington", State="NJ", ZipCode="08016", AreaCode="609" },
      new CustomerLocationData{ City="Cherry Hill", State="NJ", ZipCode="08002", AreaCode="856" },
      new CustomerLocationData{ City="Clark", State="NJ", ZipCode="07066", AreaCode="732" },
      new CustomerLocationData{ City="Edgewater", State="NJ", ZipCode="07020", AreaCode="201" },
      new CustomerLocationData{ City="Hackensack", State="NJ", ZipCode="07601", AreaCode="201" },
      new CustomerLocationData{ City="Jersey City", State="NJ", ZipCode="07310", AreaCode="201" },
      new CustomerLocationData{ City="Mount Laurel", State="NJ", ZipCode="08054", AreaCode="856" },
      new CustomerLocationData{ City="Paramus", State="NJ", ZipCode="07652", AreaCode="201" },
      new CustomerLocationData{ City="Princeton", State="NJ", ZipCode="08540", AreaCode="609" },
      new CustomerLocationData{ City="Riverdale", State="NJ", ZipCode="07457", AreaCode="973" },
      new CustomerLocationData{ City="Rockaway", State="NJ", ZipCode="07866", AreaCode="973" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87112", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87110", AreaCode="505" },
      new CustomerLocationData{ City="Albuquerque", State="NM", ZipCode="87111", AreaCode="505" },
      new CustomerLocationData{ City="Rio Rancho", State="NM", ZipCode="87124", AreaCode="505" },
      new CustomerLocationData{ City="Roswell", State="NM", ZipCode="88201", AreaCode="575" },
      new CustomerLocationData{ City="Santa Fe", State="NM", ZipCode="87507", AreaCode="505" },
      new CustomerLocationData{ City="Amsterdam", State="NY", ZipCode="12010", AreaCode="518" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11217", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11217", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11217", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11218", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11217", AreaCode="718" },
      new CustomerLocationData{ City="Amherst", State="NY", ZipCode="14228", AreaCode="716" },
      new CustomerLocationData{ City="Bronx", State="NY", ZipCode="10451", AreaCode="718" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11210", AreaCode="718" },
      new CustomerLocationData{ City="Syracuse", State="NY", ZipCode="13219", AreaCode="315" },
      new CustomerLocationData{ City="Syracuse", State="NY", ZipCode="13219", AreaCode="315" },
      new CustomerLocationData{ City="Flushing", State="NY", ZipCode="11354", AreaCode="347" },
      new CustomerLocationData{ City="Brooklyn", State="NY", ZipCode="11239", AreaCode="718" },
      new CustomerLocationData{ City="Schenectady", State="NY", ZipCode="12302", AreaCode="518" },
      new CustomerLocationData{ City="Rochester", State="NY", ZipCode="14626", AreaCode="585" },
      new CustomerLocationData{ City="Rochester", State="NY", ZipCode="14626", AreaCode="585" },
      new CustomerLocationData{ City="New York", State="NY", ZipCode="10035", AreaCode="212" },
      new CustomerLocationData{ City="Mount Vernon", State="NY", ZipCode="10550", AreaCode="914" },
      new CustomerLocationData{ City="Schenectady", State="NY", ZipCode="12304", AreaCode="518" },
      new CustomerLocationData{ City="Schenectady", State="NY", ZipCode="12304", AreaCode="518" },
      new CustomerLocationData{ City="Schenectady", State="NY", ZipCode="12304", AreaCode="518" },
      new CustomerLocationData{ City="Buffalo", State="NY", ZipCode="14216", AreaCode="716" },
      new CustomerLocationData{ City="Bronx", State="NY", ZipCode="10463", AreaCode="718" },
      new CustomerLocationData{ City="Bronx", State="NY", ZipCode="10463", AreaCode="718" },
      new CustomerLocationData{ City="Riverhead", State="NY", ZipCode="11901", AreaCode="631" },
      new CustomerLocationData{ City="White Plains", State="NY", ZipCode="10601", AreaCode="914" },
      new CustomerLocationData{ City="Asheville", State="NC", ZipCode="28805", AreaCode="828" },
      new CustomerLocationData{ City="Asheville", State="NC", ZipCode="28805", AreaCode="828" },
      new CustomerLocationData{ City="Asheville", State="NC", ZipCode="28805", AreaCode="828" },
      new CustomerLocationData{ City="Asheville", State="NC", ZipCode="28805", AreaCode="828" },
      new CustomerLocationData{ City="Asheville", State="NC", ZipCode="28805", AreaCode="828" },
      new CustomerLocationData{ City="Cary", State="NC", ZipCode="27518", AreaCode="919" },
      new CustomerLocationData{ City="Cary", State="NC", ZipCode="27519", AreaCode="919" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28227", AreaCode="704" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28277", AreaCode="704" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28204", AreaCode="704" },
      new CustomerLocationData{ City="Charlotte", State="NC", ZipCode="28216", AreaCode="704" },
      new CustomerLocationData{ City="Durham", State="NC", ZipCode="27713", AreaCode="919" },
      new CustomerLocationData{ City="Durham", State="NC", ZipCode="27707", AreaCode="919" },
      new CustomerLocationData{ City="Greensboro", State="NC", ZipCode="27408", AreaCode="336" },
      new CustomerLocationData{ City="Greensboro", State="NC", ZipCode="27407", AreaCode="336" },
      new CustomerLocationData{ City="Greensboro", State="NC", ZipCode="27410", AreaCode="336" },
      new CustomerLocationData{ City="Greenville", State="NC", ZipCode="27834", AreaCode="252" },
      new CustomerLocationData{ City="Hickory", State="NC", ZipCode="28602", AreaCode="828" },
      new CustomerLocationData{ City="Monroe", State="NC", ZipCode="28110", AreaCode="704" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27609", AreaCode="919" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27613", AreaCode="919" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27616", AreaCode="919" },
      new CustomerLocationData{ City="Raleigh", State="NC", ZipCode="27617", AreaCode="919" },
      new CustomerLocationData{ City="Wake Forest", State="NC", ZipCode="27587", AreaCode="919" },
      new CustomerLocationData{ City="Winston Salem", State="NC", ZipCode="27105", AreaCode="336" },
      new CustomerLocationData{ City="Winston Salem", State="NC", ZipCode="27103", AreaCode="336" },
      new CustomerLocationData{ City="Amherst", State="OH", ZipCode="44001", AreaCode="440" },
      new CustomerLocationData{ City="Beavercreek", State="OH", ZipCode="45431", AreaCode="937" },
      new CustomerLocationData{ City="Cincinnati", State="OH", ZipCode="45255", AreaCode="513" },
      new CustomerLocationData{ City="Cleveland", State="OH", ZipCode="44111", AreaCode="216" },
      new CustomerLocationData{ City="Cincinnati", State="OH", ZipCode="45251", AreaCode="513" },
      new CustomerLocationData{ City="Columbus", State="OH", ZipCode="43219", AreaCode="614" },
      new CustomerLocationData{ City="Columbus", State="OH", ZipCode="43240", AreaCode="614" },
      new CustomerLocationData{ City="Dayton", State="OH", ZipCode="45440", AreaCode="937" },
      new CustomerLocationData{ City="Toledo", State="OH", ZipCode="43623", AreaCode="419" },
      new CustomerLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new CustomerLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new CustomerLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new CustomerLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new CustomerLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new CustomerLocationData{ City="Springfield", State="OR", ZipCode="97477", AreaCode="541" },
      new CustomerLocationData{ City="Beaverton", State="OR", ZipCode="97006", AreaCode="503" },
      new CustomerLocationData{ City="Allentown", State="PA", ZipCode="18104", AreaCode="610" },
      new CustomerLocationData{ City="Altoona", State="PA", ZipCode="16601", AreaCode="814" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19150", AreaCode="267" },
      new CustomerLocationData{ City="Glen Mills", State="PA", ZipCode="19342", AreaCode="610" },
      new CustomerLocationData{ City="Erie", State="PA", ZipCode="16509", AreaCode="814" },
      new CustomerLocationData{ City="Reading", State="PA", ZipCode="19606", AreaCode="484" },
      new CustomerLocationData{ City="Allentown", State="PA", ZipCode="18109", AreaCode="610" },
      new CustomerLocationData{ City="Pittsburgh", State="PA", ZipCode="15238", AreaCode="412" },
      new CustomerLocationData{ City="Harrisburg", State="PA", ZipCode="17111", AreaCode="717" },
      new CustomerLocationData{ City="Harrisburg", State="PA", ZipCode="17112", AreaCode="717" },
      new CustomerLocationData{ City="Lancaster", State="PA", ZipCode="17602", AreaCode="717" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19134", AreaCode="215" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19152", AreaCode="267" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19116", AreaCode="215" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19148", AreaCode="215" },
      new CustomerLocationData{ City="Philadelphia", State="PA", ZipCode="19131", AreaCode="267" },
      new CustomerLocationData{ City="Pottstown", State="PA", ZipCode="19464", AreaCode="484" },
      new CustomerLocationData{ City="Lincoln", State="RI", ZipCode="02865", AreaCode="401" },
      new CustomerLocationData{ City="Smithfield", State="RI", ZipCode="02917", AreaCode="401" },
      new CustomerLocationData{ City="Warwick", State="RI", ZipCode="02886", AreaCode="401" },
      new CustomerLocationData{ City="Warwick", State="RI", ZipCode="02886", AreaCode="401" },
      new CustomerLocationData{ City="Aiken", State="SC", ZipCode="29803", AreaCode="803" },
      new CustomerLocationData{ City="Charleston", State="SC", ZipCode="29407", AreaCode="843" },
      new CustomerLocationData{ City="Columbia", State="SC", ZipCode="29209", AreaCode="803" },
      new CustomerLocationData{ City="Columbia", State="SC", ZipCode="29229", AreaCode="803" },
      new CustomerLocationData{ City="Columbia", State="SC", ZipCode="29212", AreaCode="803" },
      new CustomerLocationData{ City="Florence", State="SC", ZipCode="29501", AreaCode="843" },
      new CustomerLocationData{ City="Myrtle Beach", State="SC", ZipCode="29577", AreaCode="843" },
      new CustomerLocationData{ City="Myrtle Beach", State="SC", ZipCode="29588", AreaCode="843" },
      new CustomerLocationData{ City="Brentwood", State="TN", ZipCode="37027", AreaCode="615" },
      new CustomerLocationData{ City="Chattanooga", State="TN", ZipCode="37421", AreaCode="423" },
      new CustomerLocationData{ City="Clarksville", State="TN", ZipCode="37040", AreaCode="931" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37934", AreaCode="865" },
      new CustomerLocationData{ City="Knoxville", State="TN", ZipCode="37919", AreaCode="865" },
      new CustomerLocationData{ City="Maryville", State="TN", ZipCode="37801", AreaCode="865" },
      new CustomerLocationData{ City="Memphis", State="TN", ZipCode="38117", AreaCode="901" },
      new CustomerLocationData{ City="Memphis", State="TN", ZipCode="38119", AreaCode="901" },
      new CustomerLocationData{ City="Murfreesboro", State="TN", ZipCode="37129", AreaCode="615" },
      new CustomerLocationData{ City="Nashville", State="TN", ZipCode="37214", AreaCode="615" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78209", AreaCode="210" },
      new CustomerLocationData{ City="Amarillo", State="TX", ZipCode="79121", AreaCode="806" },
      new CustomerLocationData{ City="Arlington", State="TX", ZipCode="76015", AreaCode="817" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78759", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78723", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78758", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78749", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78704", AreaCode="512" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78748", AreaCode="512" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78232", AreaCode="210" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76132", AreaCode="817" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75231", AreaCode="214" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75237", AreaCode="469" },
      new CustomerLocationData{ City="Fort Worth", State="TX", ZipCode="76120", AreaCode="817" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79925", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new CustomerLocationData{ City="El Paso", State="TX", ZipCode="79912", AreaCode="915" },
      new CustomerLocationData{ City="Austin", State="TX", ZipCode="78730", AreaCode="512" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77007", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77082", AreaCode="281" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77024", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77096", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77040", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77025", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77094", AreaCode="281" },
      new CustomerLocationData{ City="Dallas", State="TX", ZipCode="75220", AreaCode="214" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79423", AreaCode="806" },
      new CustomerLocationData{ City="Lubbock", State="TX", ZipCode="79407", AreaCode="806" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78253", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78253", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78253", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78244", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78258", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78223", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78250", AreaCode="210" },
      new CustomerLocationData{ City="San Antonio", State="TX", ZipCode="78245", AreaCode="210" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77042", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77063", AreaCode="713" },
      new CustomerLocationData{ City="Houston", State="TX", ZipCode="77069", AreaCode="281" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84121", AreaCode="801" },
      new CustomerLocationData{ City="Layton", State="UT", ZipCode="84041", AreaCode="801" },
      new CustomerLocationData{ City="Riverdale", State="UT", ZipCode="84405", AreaCode="801" },
      new CustomerLocationData{ City="Salt Lake City", State="UT", ZipCode="84101", AreaCode="801" },
      new CustomerLocationData{ City="Charlottesville", State="VA", ZipCode="22911", AreaCode="434" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23320", AreaCode="757" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23322", AreaCode="757" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23322", AreaCode="757" },
      new CustomerLocationData{ City="Chesapeake", State="VA", ZipCode="23321", AreaCode="757" },
      new CustomerLocationData{ City="Richmond", State="VA", ZipCode="23225", AreaCode="804" },
      new CustomerLocationData{ City="Richmond", State="VA", ZipCode="23225", AreaCode="804" },
      new CustomerLocationData{ City="Fredericksburg", State="VA", ZipCode="22401", AreaCode="540" },
      new CustomerLocationData{ City="Fredericksburg", State="VA", ZipCode="22407", AreaCode="540" },
      new CustomerLocationData{ City="Richmond", State="VA", ZipCode="23230", AreaCode="804" },
      new CustomerLocationData{ City="Richmond", State="VA", ZipCode="23231", AreaCode="804" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23451", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23462", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23454", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23454", AreaCode="757" },
      new CustomerLocationData{ City="Virginia Beach", State="VA", ZipCode="23453", AreaCode="757" },
      new CustomerLocationData{ City="Glen Allen", State="VA", ZipCode="23059", AreaCode="804" },
      new CustomerLocationData{ City="Glen Allen", State="VA", ZipCode="23059", AreaCode="804" },
      new CustomerLocationData{ City="Williamsburg", State="VA", ZipCode="23185", AreaCode="757" },
      new CustomerLocationData{ City="Williamsburg", State="VA", ZipCode="23188", AreaCode="757" },
      new CustomerLocationData{ City="Winchester", State="VA", ZipCode="22603", AreaCode="540" },
      new CustomerLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new CustomerLocationData{ City="Issaquah", State="WA", ZipCode="98027", AreaCode="425" },
      new CustomerLocationData{ City="Spokane", State="WA", ZipCode="99218", AreaCode="509" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new CustomerLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new CustomerLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new CustomerLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" }
    };

    private static string[] CompanyNames = new string[] {
        "Acme Corp", "Ajax", "ARCAM Corporation", "Arlesdale Railway", "Astromech", "Benthic Petroleum", "Biffco", "Binford", "Black Mesa Research Facility", "Blaidd Dwrg Nuclear Power Plant", "Blue Sun Corporation", "Bluth Company", "Brown Streak Railroad", "Central Perk", "ComTron", "Contoso",
        "Crudgington Brewery", "Culdee Fell Railway", "Cyberdyne Systems", "Daystrom Data Concepts", "Deon International", "DHARMA Initiative", "Digivation Industries", "Dinoco", "Dirk Gently's Holistic Detective Agency", "Doublemeat Palace", "Duff Beer", "Dunder Mifflin", "Ecumena", "Ewing Oil", "Ewing Oil", "Fabrikam",
        "FrobozzCo International - Zork ", "Global Dynamics", "Grand Trunk Semaphore Company", "Grayson Sky Domes, Ltd.", "Grim Reaper Airways", "Groovy Smoothie", "Hanso Foundation", "Hishii Industries", "Incom Corporation", "InGen", "Initech", "Itex", "Izon", "Jupiter Mining Corporation", "Khumalo", "KrebStarLexCorp",
        "Krusty Burger", "Kwik-E-Mart", "Liandri Mining Corporation", "LuthorCorp", "Medical Mechanica", "Mel's Diner", "Metacortex", "Michael Scott Paper Company", "Milliways", "Mishima ZaibatsuRAMJAC Corporation", "Muffin Buffalo", "Nordyne Defense Dynamics", "North Western Railway", "Oceanic Airlines", "Office of Scientific Intelligence (OSI)", "Onion Pacific Railroad",
        "Peach Pit", "Porter Automobiles", "Prescott Pharmaceuticals", "Rekall", "Rovers Return", "Roxxon", "Roxxon", "Scavo's Pizzeria", "Scrooge McDuck's", "Sheinhardt Wig Company", "Shelbyville Nuclear Power Plant", "Shinra Electric Power Company", "Shinra Electric Power Companyworld, Final Fantasy VII", "Sirius Cybernetics Corporation", "Slate Rock and Gravel Company", "Soar Airlines",
        "Soylent Corporation", "Springfield Nuclear Power Plant", "Strickland Propane", "Tagruato", "The Crab Shack", "The Hanso Foundation", "The Regal Beagle", "Total Bastard Airlines", "Trade Federation", "Tricell", "Trioptimum Corporation", "Tyrell Corporation", "Umbrella Corporation", "Union Aerospace Corporation", "Uplink Corporation", "Vandelay Industries",
        "VersaLife Corporation", "Vol\x00e9e Airlines", "W.C. Boggs & Co.", "Wallaby Airlines", "WarioWare, Inc.", "Wayne Enterprises", "Yoyodyne Propulsion Systems", "Zorg Industries", "Zorin Industries"
     };
    private static string[] FemaleFirstNames = new string[] {
        "Abby", "Abigail", "Ada", "Addie", "Adela", "Adele", "Adeline", "Adrian", "Adriana", "Adrienne", "Agnes", "Aida", "Aileen", "Aimee", "Aisha", "Alana",
        "Alba", "Alberta", "Alejandra", "Alexandra", "Alexandria", "Alexis", "Alfreda", "Alice", "Alicia", "Aline", "Alisa", "Alisha", "Alison", "Alissa", "Allie", "Allison",
        "Allyson", "Alma", "Alta", "Althea", "Alyce", "Alyson", "Alyssa", "Amalia", "Amanda", "Amber", "Amelia", "Amie", "Amparo", "Amy", "Ana", "Anastasia",
        "Andrea", "Angel", "Angela", "Angelia", "Angelica", "Angelina", "Angeline", "Angelique", "Angelita", "Angie", "Anita", "Ann", "Anna", "Annabelle", "Anne", "Annette",
        "Annie", "Annmarie", "Antoinette", "Antonia", "April", "Araceli", "Arlene", "Arline", "Ashlee", "Ashley", "Audra", "Audrey", "Augusta", "Aurelia", "Aurora", "Autumn",
        "Ava", "Avis", "Barbara", "Barbra", "Beatrice", "Beatriz", "Becky", "Belinda", "Benita", "Bernadette", "Bernadine", "Bernice", "Berta", "Bertha", "Bertie", "Beryl",
        "Bessie", "Beth", "Bethany", "Betsy", "Bette", "Bettie", "Betty", "Bettye", "Beulah", "Beverley", "Beverly", "Bianca", "Billie", "Blanca", "Blanche", "Bobbi",
        "Bobbie", "Bonita", "Bonnie", "Brandi", "Brandie", "Brandy", "Brenda", "Briana", "Brianna", "Bridget", "Bridgett", "Bridgette", "Brigitte", "Britney", "Brittany", "Brittney",
        "Brooke", "Caitlin", "Callie", "Camille", "Candace", "Candice", "Candy", "Cara", "Carey", "Carissa", "Carla", "Carlene", "Carly", "Carmela", "Carmella", "Carmen",
        "Carol", "Carole", "Carolina", "Caroline", "Carolyn", "Carrie", "Casandra", "Casey", "Cassandra", "Cassie", "Catalina", "Catherine", "Cathleen", "Cathryn", "Cathy", "Cecelia",
        "Cecile", "Cecilia", "Celeste", "Celia", "Celina", "Chandra", "Charity", "Charlene", "Charlotte", "Charmaine", "Chasity", "Chelsea", "Cheri", "Cherie", "Cherry", "Cheryl",
        "Chris", "Christa", "Christi", "Christian", "Christie", "Christina", "Christine", "Christy", "Chrystal", "Cindy", "Claire", "Clara", "Clare", "Clarice", "Clarissa", "Claudette",
        "Claudia", "Claudine", "Cleo", "Coleen", "Colette", "Colleen", "Concepcion", "Concetta", "Connie", "Constance", "Consuelo", "Cora", "Corina", "Corine", "Corinne", "Cornelia",
        "Corrine", "Courtney", "Cristina", "Crystal", "Cynthia", "Daisy", "Dale", "Dana", "Danielle", "Daphne", "Darcy", "Darla", "Darlene", "Dawn", "Deana", "Deann",
        "Deanna", "Deanne", "Debbie", "Debora", "Deborah", "Debra", "Dee", "Deena", "Deidre", "Deirdre", "Delia", "Della", "Delores", "Deloris", "Dena", "Denise",
        "Desiree", "Diana", "Diane", "Diann", "Dianna", "Dianne", "Dina", "Dionne", "Dixie", "Dollie", "Dolly", "Dolores", "Dominique", "Dona", "Donna", "Dora",
        "Doreen", "Doris", "Dorothea", "Dorothy", "Dorthy", "Earlene", "Earline", "Earnestine", "Ebony", "Eddie", "Edith", "Edna", "Edwina", "Effie", "Eileen", "Elaine",
        "Elba", "Eleanor", "Elena", "Elinor", "Elisa", "Elisabeth", "Elise", "Eliza", "Elizabeth", "Ella", "Ellen", "Elma", "Elnora", "Eloise", "Elsa", "Elsie",
        "Elva", "Elvia", "Elvira", "Emilia", "Emily", "Emma", "Enid", "Erica", "Ericka", "Erika", "Erin", "Erma", "Erna", "Ernestine", "Esmeralda", "Esperanza",
        "Essie", "Estela", "Estella", "Estelle", "Ester", "Esther", "Ethel", "Etta", "Eugenia", "Eula", "Eunice", "Eva", "Evangelina", "Evangeline", "Eve", "Evelyn",
        "Faith", "Fannie", "Fanny", "Fay", "Faye", "Felecia", "Felicia", "Fern", "Flora", "Florence", "Florine", "Flossie", "Fran", "Frances", "Francesca", "Francine",
        "Francis", "Francisca", "Frankie", "Freda", "Freida", "Frieda", "Gabriela", "Gabrielle", "Gail", "Gale", "Gay", "Gayle", "Gena", "Geneva", "Genevieve", "Georgette",
        "Georgia", "Georgina", "Geraldine", "Gertrude", "Gilda", "Gina", "Ginger", "Gladys", "Glenda", "Glenna", "Gloria", "Goldie", "Grace", "Gracie", "Graciela", "Greta",
        "Gretchen", "Guadalupe", "Gwen", "Gwendolyn", "Haley", "Hallie", "Hannah", "Harriet", "Harriett", "Hattie", "Hazel", "Heather", "Heidi", "Helen", "Helena", "Helene",
        "Helga", "Henrietta", "Herminia", "Hester", "Hilary", "Hilda", "Hillary", "Hollie", "Holly", "Hope", "Ida", "Ila", "Ilene", "Imelda", "Imogene", "Ina",
        "Ines", "Inez", "Ingrid", "Irene", "Iris", "Irma", "Isabel", "Isabella", "Isabelle", "Iva", "Ivy", "Jackie", "Jacklyn", "Jaclyn", "Jacqueline", "Jacquelyn",
        "Jaime", "James", "Jami", "Jamie", "Jan", "Jana", "Jane", "Janell", "Janelle", "Janet", "Janette", "Janice", "Janie", "Janine", "Janis", "Janna",
        "Jannie", "Jasmine", "Jayne", "Jean", "Jeanette", "Jeanie", "Jeanine", "Jeanne", "Jeannette", "Jeannie", "Jeannine", "Jenifer", "Jenna", "Jennie", "Jennifer", "Jenny",
        "Jeri", "Jerri", "Jerry", "Jessica", "Jessie", "Jewel", "Jewell", "Jill", "Jillian", "Jimmie", "Jo", "Joan", "Joann", "Joanna", "Joanne", "Jocelyn",
        "Jodi", "Jodie", "Jody", "Johanna", "John", "Johnnie", "Jolene", "Joni", "Jordan", "Josefa", "Josefina", "Josephine", "Josie", "Joy", "Joyce", "Juana",
        "Juanita", "Judith", "Judy", "Julia", "Juliana", "Julianne", "Julie", "Juliet", "Juliette", "June", "Justine", "Kaitlin", "Kara", "Karen", "Kari", "Karin",
        "Karina", "Karla", "Karyn", "Kasey", "Kate", "Katelyn", "Katharine", "Katherine", "Katheryn", "Kathie", "Kathleen", "Kathrine", "Kathryn", "Kathy", "Katie", "Katina",
        "Katrina", "Katy", "Kay", "Kaye", "Kayla", "Keisha", "Kelley", "Kelli", "Kellie", "Kelly", "Kelsey", "Kendra", "Kenya", "Keri", "Kerri", "Kerry",
        "Kim", "Kimberley", "Kimberly", "Kirsten", "Kitty", "Kris", "Krista", "Kristen", "Kristi", "Kristie", "Kristin", "Kristina", "Kristine", "Kristy", "Krystal", "Lacey",
        "Lacy", "Ladonna", "Lakeisha", "Lakisha", "Lana", "Lara", "Latasha", "Latisha", "Latonya", "Latoya", "Laura", "Laurel", "Lauren", "Lauri", "Laurie", "Laverne",
        "Lavonne", "Lawanda", "Lea", "Leah", "Leann", "Leanna", "Leanne", "Lee", "Leigh", "Leila", "Lela", "Lelia", "Lena", "Lenora", "Lenore", "Leola",
        "Leona", "Leonor", "Lesa", "Lesley", "Leslie", "Lessie", "Leta", "Letha", "Leticia", "Letitia", "Lidia", "Lila", "Lilia", "Lilian", "Liliana", "Lillian",
        "Lillie", "Lilly", "Lily", "Lina", "Linda", "Lindsay", "Lindsey", "Lisa", "Liz", "Liza", "Lizzie", "Lois", "Lola", "Lolita", "Lora", "Loraine",
        "Lorena", "Lorene", "Loretta", "Lori", "Lorie", "Lorna", "Lorraine", "Lorrie", "Lottie", "Lou", "Louella", "Louisa", "Louise", "Lourdes", "Luann", "Lucia",
        "Lucile", "Lucille", "Lucinda", "Lucy", "Luella", "Luisa", "Lula", "Lupe", "Luz", "Lydia", "Lynda", "Lynette", "Lynn", "Lynne", "Lynnette", "Mabel",
        "Mable", "Madeleine", "Madeline", "Madelyn", "Madge", "Mae", "Magdalena", "Maggie", "Mai", "Malinda", "Mallory", "Mamie", "Mandy", "Manuela", "Mara", "Marcella",
        "Marci", "Marcia", "Marcie", "Marcy", "Margaret", "Margarita", "Margery", "Margie", "Margo", "Margret", "Marguerite", "Mari", "Maria", "Marian", "Mariana", "Marianne",
        "Maribel", "Maricela", "Marie", "Marietta", "Marilyn", "Marina", "Marion", "Marisa", "Marisol", "Marissa", "Maritza", "Marjorie", "Marla", "Marlene", "Marquita", "Marsha",
        "Marta", "Martha", "Martina", "Marva", "Mary", "Maryann", "Maryanne", "Maryellen", "Marylou", "Matilda", "Mattie", "Maude", "Maura", "Maureen", "Mavis", "Maxine",
        "May", "Mayra", "Meagan", "Megan", "Meghan", "Melanie", "Melba", "Melinda", "Melisa", "Melissa", "Melody", "Melva", "Mercedes", "Meredith", "Merle", "Mia",
        "Michael", "Michele", "Michelle", "Milagros", "Mildred", "Millicent", "Millie", "Mindy", "Minerva", "Minnie", "Miranda", "Miriam", "Misty", "Mitzi", "Mollie", "Molly",
        "Mona", "Monica", "Monique", "Morgan", "Muriel", "Myra", "Myrna", "Myrtle", "Nadia", "Nadine", "Nancy", "Nanette", "Nannie", "Naomi", "Natalia", "Natalie",
        "Natasha", "Nelda", "Nell", "Nellie", "Nettie", "Neva", "Nichole", "Nicole", "Nikki", "Nina", "Nita", "Noelle", "Noemi", "Nola", "Nona", "Nora",
        "Noreen", "Norma", "Odessa", "Ofelia", "Ola", "Olga", "Olive", "Olivia", "Ollie", "Opal", "Ophelia", "Ora", "Paige", "Pam", "Pamela", "Pansy",
        "Pat", "Patrica", "Patrice", "Patricia", "Patsy", "Patti", "Patty", "Paula", "Paulette", "Pauline", "Pearl", "Pearlie", "Peggy", "Penelope", "Penny", "Petra",
        "Phoebe", "Phyllis", "Polly", "Priscilla", "Queen", "Rachael", "Rachel", "Rachelle", "Rae", "Ramona", "Randi", "Raquel", "Reba", "Rebecca", "Rebekah", "Regina",
        "Rena", "Rene", "Renee", "Reva", "Reyna", "Rhea", "Rhoda", "Rhonda", "Rita", "Robbie", "Robert", "Roberta", "Robin", "Robyn", "Rochelle", "Ronda",
        "Rosa", "Rosalie", "Rosalind", "Rosalinda", "Rosalyn", "Rosanna", "Rosanne", "Rosario", "Rose", "Roseann", "Rosella", "Rosemarie", "Rosemary", "Rosetta", "Rosie", "Roslyn",
        "Rowena", "Roxanne", "Roxie", "Ruby", "Ruth", "Ruthie", "Sabrina", "Sadie", "Sallie", "Sally", "Samantha", "Sandra", "Sandy", "Sara", "Sarah", "Sasha",
        "Saundra", "Savannah", "Selena", "Selma", "Serena", "Shana", "Shanna", "Shannon", "Shari", "Sharlene", "Sharon", "Sharron", "Shauna", "Shawn", "Shawna", "Sheena",
        "Sheila", "Shelby", "Shelia", "Shelley", "Shelly", "Sheree", "Sheri", "Sherri", "Sherrie", "Sherry", "Sheryl", "Shirley", "Silvia", "Simone", "Socorro", "Sofia",
        "Sondra", "Sonia", "Sonja", "Sonya", "Sophia", "Sophie", "Stacey", "Staci", "Stacie", "Stacy", "Stefanie", "Stella", "Stephanie", "Sue", "Summer", "Susan",
        "Susana", "Susanna", "Susanne", "Susie", "Suzanne", "Suzette", "Sybil", "Sylvia", "Tabatha", "Tabitha", "Tamara", "Tameka", "Tamera", "Tami", "Tamika", "Tammi",
        "Tammie", "Tammy", "Tamra", "Tania", "Tanisha", "Tanya", "Tara", "Tasha", "Taylor", "Teresa", "Teri", "Terra", "Terri", "Terrie", "Terry", "Tessa",
        "Thelma", "Theresa", "Therese", "Tia", "Tiffany", "Tina", "Tisha", "Tommie", "Toni", "Tonia", "Tonya", "Tracey", "Traci", "Tracie", "Tracy", "Tricia",
        "Trina", "Trisha", "Trudy", "Twila", "Ursula", "Valarie", "Valeria", "Valerie", "Vanessa", "Velma", "Vera", "Verna", "Veronica", "Vicki", "Vickie", "Vicky",
        "Victoria", "Vilma", "Viola", "Violet", "Virgie", "Virginia", "Vivian", "Vonda", "Wanda", "Wendi", "Wendy", "Whitney", "Wilda", "Willa", "Willie", "Wilma",
        "Winifred", "Winnie", "Yesenia", "Yolanda", "Young", "Yvette", "Yvonne", "Zelma"
    };
    private static string[] MaleFirstNames = new string[] {

        "Aaron", "Abdul", "Abe", "Abel", "Abraham", "Abram", "Adam", "Adolfo",
        "Adrian", "Ahmed", "Al", "Alan", "Albert", "Alberto", "Alden", "Alec", "Alejandro", "Alex", "Alexander", "Alexis", "Alfonzo", "Alfred", "Allan", "Alonso",
        "Alonzo", "Alphonse", "Alphonso", "Alton", "Alva", "Alvaro", "Alvin", "Amado", "Ambrose", "Amos", "Anderson", "Andre", "Andrea", "Andres", "Andrew", "Andy",
        "Angel", "Angelo", "Anibal", "Anthony", "Antione", "Antoine", "Anton", "Antone", "Antonia", "Antonio", "Antony", "Antwan", "Archie", "Arden", "Ariel", "Arlen",
        "Arlie", "Armand", "Armando", "Arnold", "Arnoldo", "Arnulfo", "Aron", "Arron", "Art", "Arthur", "Arturo", "Asa", "Ashley", "Aubrey", "August", "Augustine",
        "Augustus", "Aurelio", "Austin", "Avery", "Barney", "Barrett", "Barry", "Bart", "Barton", "Basil", "Beau", "Ben", "Benedict", "Benito", "Benjamin", "Bennett",
        "Bennie", "Benny", "Benton", "Bernard", "Bernardo", "Bernie", "Berry", "Bert", "Bertram", "Bill", "Billie", "Billy", "Blaine", "Blair", "Blake", "Bo",
        "Bob", "Bob", "Bob", "Bob", "Bob", "Bob", "Bob", "Bob", "Bob", "Bobbie", "Bobby", "Booker", "Boris", "Boyce", "Boyd", "Brad",
        "Bradford", "Bradley", "Bradly", "Brady", "Brain", "Branden", "Brandon", "Brant", "Brendan", "Brendon", "Brent", "Brenton", "Bret", "Brett", "Brian", "Brice",
        "Britt", "Brock", "Broderick", "Brooks", "Bruce", "Bruno", "Bryan", "Bryant", "Bryce", "Bryon", "Buck", "Bud", "Buddy", "Buford", "Burl", "Burt",
        "Burton", "Buster", "Byron", "Caleb", "Calvin", "Cameron", "Carey", "Carl", "Carlo", "Carlos", "Carlton", "Carmelo", "Carmen", "Carmine", "Carol", "Carrol",
        "Carroll", "Carson", "Carter", "Cary", "Casey", "Cecil", "Cedric", "Cedrick", "Cesar", "Chad", "Chadwick", "Chance", "Chang", "Charles", "Charley", "Charlie",
        "Chas", "Chase", "Chauncey", "Chester", "Chet", "Chi", "Chong", "Chris", "Christian", "Christoper", "Christopher", "Chuck", "Chung", "Clair", "Clarence", "Clark",
        "Claud", "Claude", "Claudio", "Clay", "Clayton", "Clement", "Clemente", "Cleo", "Cletus", "Cleveland", "Cliff", "Clifford", "Clifton", "Clint", "Clinton", "Clyde",
        "Cody", "Colby", "Cole", "Coleman", "Colin", "Collin", "Colton", "Columbus", "Connie", "Conrad", "Cordell", "Corey", "Cornelius", "Cornell", "Cortez", "Cory",
        "Courtney", "Coy", "Craig", "Cristobal", "Cristopher", "Cruz", "Curt", "Curtis", "Cyril", "Cyrus", "Dale", "Dallas", "Dalton", "Damian", "Damien", "Damion",
        "Damon", "Dan", "Dana", "Dane", "Danial", "Daniel", "Danilo", "Dannie", "Danny", "Dante", "Darell", "Daren", "Darin", "Dario", "Darius", "Darnell",
        "Daron", "Darrel", "Darrell", "Darren", "Darrick", "Darrin", "Darron", "Darryl", "Darwin", "Daryl", "Dave", "David", "Davis", "Dean", "Deandre", "Deangelo",
        "Dee", "Del", "Delbert", "Delmar", "Delmer", "Demarcus", "Demetrius", "Denis", "Dennis", "Denny", "Denver", "Deon", "Derek", "Derick", "Derrick", "Deshawn",
        "Desmond", "Devin", "Devon", "Dewayne", "Dewey", "Dewitt", "Dexter", "Dick", "Diego", "Dillon", "Dino", "Dion", "Dirk", "Domenic", "Domingo", "Dominic",
        "Dominick", "Dominique", "Don", "Donald", "Dong", "Donn", "Donnell", "Donnie", "Donny", "Donovan", "Donte", "Dorian", "Dorsey", "Doug", "Douglas", "Douglass",
        "Doyle", "Drew", "Duane", "Dudley", "Duncan", "Dustin", "Dusty", "Dwain", "Dwayne", "Dwight", "Dylan", "Earl", "Earle", "Earnest", "Ed", "Eddie",
        "Eddy", "Edgar", "Edgardo", "Edison", "Edmond", "Edmund", "Edmundo", "Eduardo", "Edward", "Edwardo", "Edwin", "Efrain", "Efren", "Elbert", "Elden", "Eldon",
        "Eldridge", "Eli", "Elias", "Elijah", "Eliseo", "Elisha", "Elliot", "Elliott", "Ellis", "Ellsworth", "Elmer", "Elmo", "Eloy", "Elroy", "Elton", "Elvin",
        "Elvis", "Elwood", "Emanuel", "Emerson", "Emery", "Emil", "Emile", "Emilio", "Emmanuel", "Emmett", "Emmitt", "Emory", "Enoch", "Enrique", "Erasmo", "Eric",
        "Erich", "Erick", "Erik", "Erin", "Ernest", "Ernesto", "Ernie", "Errol", "Ervin", "Erwin", "Esteban", "Ethan", "Eugene", "Eugenio", "Eusebio", "Evan",
        "Everett", "Everette", "Ezekiel", "Ezequiel", "Ezra", "Fabian", "Faustino", "Fausto", "Federico", "Felipe", "Felix", "Felton", "Ferdinand", "Fermin", "Fernando", "Fidel",
        "Filiberto", "Fletcher", "Florencio", "Florentino", "Floyd", "Forest", "Forrest", "Foster", "Frances", "Francesco", "Francis", "Francisco", "Frank", "Frankie", "Franklin", "Franklyn",
        "Fred", "Freddie", "Freddy", "Frederic", "Frederick", "Fredric", "Fredrick", "Freeman", "Fritz", "Gabriel", "Gail", "Gale", "Galen", "Garfield", "Garland", "Garret",
        "Garrett", "Garry", "Garth", "Gary", "Gaston", "Gavin", "Gayle", "Gaylord", "Genaro", "Gene", "Geoffrey", "George", "Gerald", "Geraldo", "Gerard", "Gerardo",
        "German", "Gerry", "Gil", "Gilbert", "Gilberto", "Gino", "Giovanni", "Giuseppe", "Glen", "Glenn", "Gonzalo", "Gordon", "Grady", "Graham", "Graig", "Grant",
        "Granville", "Greg", "Gregg", "Gregorio", "Gregory", "Grover", "Guadalupe", "Guillermo", "Gus", "Gustavo", "Guy", "Hai", "Hal", "Hank", "Hans", "Harlan",
        "Harland", "Harley", "Harold", "Harris", "Harrison", "Harry", "Harvey", "Hassan", "Hayden", "Haywood", "Heath", "Hector", "Henry", "Herb", "Herbert", "Heriberto",
        "Herman", "Herschel", "Hershel", "Hilario", "Hilton", "Hipolito", "Hiram", "Hobert", "Hollis", "Homer", "Hong", "Horace", "Horacio", "Hosea", "Houston", "Howard",
        "Hoyt", "Hubert", "Huey", "Hugh", "Hugo", "Humberto", "Hung", "Hunter", "Hyman", "Ian", "Ignacio", "Ike", "Ira", "Irvin", "Irving", "Irwin",
        "Isaac", "Isaiah", "Isaias", "Isiah", "Isidro", "Ismael", "Israel", "Isreal", "Issac", "Ivan", "Ivory", "Jacinto", "Jack", "Jackie", "Jackson", "Jacob",
        "Jacques", "Jae", "Jaime", "Jake", "Jamaal", "Jamal", "Jamar", "Jame", "Jamel", "James", "Jamey", "Jamie", "Jamison", "Jan", "Jared", "Jarod",
        "Jarred", "Jarrett", "Jarrod", "Jarvis", "Jason", "Jasper", "Javier", "Jay", "Jayson", "Jc", "Jean", "Jed", "Jeff", "Jefferey", "Jefferson", "Jeffery",
        "Jeffrey", "Jeffry", "Jerald", "Jeramy", "Jere", "Jeremiah", "Jeremy", "Jermaine", "Jerold", "Jerome", "Jeromy", "Jerrell", "Jerrod", "Jerrold", "Jerry", "Jess",
        "Jesse", "Jessie", "Jesus", "Jewel", "Jewell", "Jim", "Jimmie", "Jimmy", "Joan", "Joaquin", "Jody", "Joe", "Joel", "Joesph", "Joey", "John",
        "Johnathan", "Johnathon", "Johnie", "Johnnie", "Johnny", "Johnson", "Jon", "Jonah", "Jonas", "Jonathan", "Jonathon", "Jordan", "Jordon", "Jorge", "Jose", "Josef",
        "Joseph", "Josh", "Joshua", "Josiah", "Jospeh", "Josue", "Juan", "Jude", "Judson", "Jules", "Julian", "Julio", "Julius", "Junior", "Justin", "Kareem",
        "Karl", "Kasey", "Keenan", "Keith", "Kelley", "Kelly", "Kelvin", "Ken", "Kendall", "Kendrick", "Keneth", "Kenneth", "Kennith", "Kenny", "Kent", "Kenton",
        "Kermit", "Kerry", "Keven", "Kevin", "Kieth", "Kim", "King", "Kip", "Kirby", "Kirk", "Korey", "Kory", "Kraig", "Kris", "Kristofer", "Kristopher",
        "Kurt", "Kurtis", "Kyle", "Lacy", "Lamar", "Lamont", "Lance", "Landon", "Lane", "Lanny", "Larry", "Lauren", "Laurence", "Lavern", "Laverne", "Lawerence",
        "Lawrence", "Lazaro", "Leandro", "Lee", "Leif", "Leigh", "Leland", "Lemuel", "Len", "Lenard", "Lenny", "Leo", "Leon", "Leonard", "Leonardo", "Leonel",
        "Leopoldo", "Leroy", "Les", "Lesley", "Leslie", "Lester", "Levi", "Lewis", "Lincoln", "Lindsay", "Lindsey", "Lino", "Linwood", "Lionel", "Lloyd", "Logan",
        "Lon", "Long", "Lonnie", "Lonny", "Loren", "Lorenzo", "Lou", "Louie", "Louis", "Lowell", "Loyd", "Lucas", "Luciano", "Lucien", "Lucio", "Lucius",
        "Luigi", "Luis", "Luke", "Lupe", "Luther", "Lyle", "Lyman", "Lyndon", "Lynn", "Lynwood", "Mac", "Mack", "Major", "Malcolm", "Malcom", "Malik",
        "Man", "Manual", "Manuel", "Marc", "Marcel", "Marcelino", "Marcellus", "Marcelo", "Marco", "Marcos", "Marcus", "Margarito", "Maria", "Mariano", "Mario", "Marion",
        "Mark", "Markus", "Marlin", "Marlon", "Marquis", "Marshall", "Martin", "Marty", "Marvin", "Mary", "Mason", "Mathew", "Matt", "Matthew", "Maurice", "Mauricio",
        "Mauro", "Max", "Maximo", "Maxwell", "Maynard", "Mckinley", "Mel", "Melvin", "Merle", "Merlin", "Merrill", "Mervin", "Micah", "Michael", "Michal", "Michale",
        "Micheal", "Michel", "Mickey", "Miguel", "Mike", "Mikel", "Milan", "Miles", "Milford", "Millard", "Milo", "Milton", "Minh", "Miquel", "Mitch", "Mitchel",
        "Mitchell", "Modesto", "Mohamed", "Mohammad", "Mohammed", "Moises", "Monroe", "Monte", "Monty", "Morgan", "Morris", "Morton", "Mose", "Moses", "Moshe", "Murray",
        "Myles", "Myron", "Napoleon", "Nathan", "Nathanael", "Nathanial", "Nathaniel", "Neal", "Ned", "Neil", "Nelson", "Nestor", "Neville", "Newton", "Nicholas", "Nick",
        "Nickolas", "Nicky", "Nicolas", "Nigel", "Noah", "Noble", "Noe", "Noel", "Nolan", "Norbert", "Norberto", "Norman", "Normand", "Norris", "Numbers", "Octavio",
        "Odell", "Odis", "Olen", "Olin", "Oliver", "Ollie", "Omar", "Omer", "Oren", "Orlando", "Orval", "Orville", "Oscar", "Osvaldo", "Oswaldo", "Otha",
        "Otis", "Otto", "Owen", "Pablo", "Palmer", "Paris", "Parker", "Pasquale", "Pat", "Patricia", "Patrick", "Paul", "Pedro", "Percy", "Perry", "Pete",
        "Peter", "Phil", "Philip", "Phillip", "Pierre", "Porfirio", "Porter", "Preston", "Prince", "Quentin", "Quincy", "Quinn", "Quintin", "Quinton", "Rafael", "Raleigh",
        "Ralph", "Ramiro", "Ramon", "Randal", "Randall", "Randell", "Randolph", "Randy", "Raphael", "Rashad", "Raul", "Ray", "Rayford", "Raymon", "Raymond", "Raymundo",
        "Reed", "Refugio", "Reggie", "Reginald", "Reid", "Reinaldo", "Renaldo", "Renato", "Rene", "Reuben", "Rex", "Rey", "Reyes", "Reynaldo", "Rhett", "Ricardo",
        "Rich", "Richard", "Richie", "Rick", "Rickey", "Rickie", "Ricky", "Rico", "Rigoberto", "Riley", "Rob", "Robbie", "Robby", "Robert", "Roberto", "Robin",
        "Robt", "Rocco", "Rocky", "Rod", "Roderick", "Rodger", "Rodney", "Rodolfo", "Rodrick", "Rodrigo", "Rogelio", "Roger", "Roland", "Rolando", "Rolf", "Rolland",
        "Roman", "Romeo", "Ron", "Ronald", "Ronnie", "Ronny", "Roosevelt", "Rory", "Rosario", "Roscoe", "Rosendo", "Ross", "Roy", "Royal", "Royce", "Ruben",
        "Rubin", "Rudolf", "Rudolph", "Rudy", "Rueben", "Rufus", "Rupert", "Russ", "Russel", "Russell", "Rusty", "Ryan", "Sal", "Salvador", "Salvatore", "Sam",
        "Sammie", "Sammy", "Samual", "Samuel", "Sandy", "Sanford", "Sang", "Santiago", "Santo", "Santos", "Saul", "Scot", "Scott", "Scottie", "Scotty", "Sean",
        "Sebastian", "Sergio", "Seth", "Seymour", "Shad", "Shane", "Shannon", "Shaun", "Shawn", "Shayne", "Shelby", "Sheldon", "Shelton", "Sherman", "Sherwood", "Shirley",
        "Shon", "Sid", "Sidney", "Silas", "Simon", "Sol", "Solomon", "Son", "Sonny", "Spencer", "Stacey", "Stacy", "Stan", "Stanford", "Stanley", "Stanton",
        "Stefan", "Stephan", "Stephen", "Sterling", "Steve", "Steven", "Stevie", "Stewart", "Stuart", "Sung", "Sydney", "Sylvester", "Tad", "Tanner", "Taylor", "Ted",
        "Teddy", "Teodoro", "Terence", "Terrance", "Terrell", "Terrence", "Terry", "Thad", "Thaddeus", "Thanh", "Theo", "Theodore", "Theron", "Thomas", "Thurman", "Tim",
        "Timmy", "Timothy", "Titus", "Tobias", "Toby", "Tod", "Todd", "Tom", "Tomas", "Tommie", "Tommy", "Toney", "Tony", "Tory", "Tracey", "Tracy",
        "Travis", "Trent", "Trenton", "Trevor", "Trey", "Trinidad", "Tristan", "Troy", "Truman", "Tuan", "Ty", "Tyler", "Tyree", "Tyrell", "Tyron", "Tyrone",
        "Tyson", "Ulysses", "Val", "Valentin", "Valentine", "Van", "Vance", "Vaughn", "Vern", "Vernon", "Vicente", "Victor", "Vince", "Vincent", "Vincenzo", "Virgil",
        "Virgilio", "Vito", "Von", "Wade", "Waldo", "Walker", "Wallace", "Wally", "Walter", "Walton", "Ward", "Warner", "Warren", "Waylon", "Wayne", "Weldon",
        "Wendell", "Werner", "Wes", "Wesley", "Weston", "Whitney", "Wilber", "Wilbert", "Wilbur", "Wilburn", "Wiley", "Wilford", "Wilfred", "Wilfredo", "Will", "Willard",
        "William", "Williams", "Willian", "Willie", "Willis", "Willy", "Wilmer", "Wilson", "Wilton", "Winford", "Winfred", "Winston", "Wm", "Woodrow", "Wyatt", "Xavier",
        "Yong", "Young", "Zachariah", "Zachary", "Zachery", "Zack", "Zackary", "Zane"
     };

    private static string[] LastNames = new string[] {
        "Abbott", "Acosta", "Adams", "Adkins", "Aguilar", "Albert", "Alexander", "Alford", "Allen", "Alston", "Alvarado", "Alvarez", "Anderson", "Andrews", "Anthony", "Armstrong",
        "Arnold", "Ashley", "Atkins", "Atkinson", "Austin", "Avery", "Ayala", "Ayers", "Bailey", "Baird", "Baker", "Baldwin", "Ball", "Ballard", "Banks", "Barber",
        "Barker", "Barlow", "Barnes", "Barnett", "Barr", "Barrera", "Barrett", "Barron", "Barry", "Bartlett", "Barton", "Bass", "Bates", "Battle", "Bauer", "Baxter",
        "Beach", "Bean", "Beard", "Beasley", "Beck", "Becker", "Bell", "Bender", "Benjamin", "Bennett", "Benson", "Bentley", "Benton", "Berg", "Berger", "Bernard",
        "Berry", "Best", "Bird", "Bishop", "Black", "Blackburn", "Blackwell", "Blair", "Blake", "Blanchard", "Blankenship", "Blevins", "Bolton", "Bond", "Bonner", "Booker",
        "Boone", "Booth", "Bowen", "Bowers", "Bowman", "Boyd", "Boyer", "Boyle", "Bradford", "Bradley", "Bradshaw", "Brady", "Branch", "Bray", "Brennan", "Brewer",
        "Bridges", "Briggs", "Bright", "Britt", "Brock", "Brooks", "Brown", "Browning", "Bruce", "Bryan", "Bryant", "Buchanan", "Buck", "Buckley", "Buckner", "Bullock",
        "Burch", "Burgess", "Burke", "Burks", "Burnett", "Burns", "Burris", "Burt", "Burton", "Bush", "Butler", "Byers", "Byrd", "Cabrera", "Cain", "Calderon",
        "Caldwell", "Calhoun", "Callahan", "Camacho", "Cameron", "Campbell", "Campos", "Cannon", "Cantrell", "Cantu", "Cardenas", "Carey", "Carlson", "Carney", "Carpenter", "Carr",
        "Carrillo", "Carroll", "Carson", "Carter", "Carver", "Case", "Casey", "Cash", "Castaneda", "Castillo", "Castro", "Cervantes", "Chambers", "Chan", "Chandler", "Chaney",
        "Chang", "Chapman", "Charles", "Chase", "Chavez", "Chen", "Cherry", "Christensen", "Christian", "Church", "Clark", "Clarke", "Clay", "Clayton", "Clements", "Clemons",
        "Cleveland", "Cline", "Cobb", "Cochran", "Coffey", "Cohen", "Cole", "Coleman", "Collier", "Collins", "Colon", "Combs", "Compton", "Conley", "Conner", "Conrad",
        "Contreras", "Conway", "Cook", "Cooke", "Cooley", "Cooper", "Copeland", "Cortez", "Cote", "Cotton", "Cox", "Craft", "Craig", "Crane", "Crawford", "Crosby",
        "Cross", "Cruz", "Cummings", "Cunningham", "Curry", "Curtis", "Dale", "Dalton", "Daniel", "Daniels", "Daugherty", "Davenport", "David", "Davidson", "Davis", "Dawson",
        "Day", "Dean", "Decker", "Dejesus", "Delacruz", "Delaney", "Deleon", "Delgado", "Dennis", "Diaz", "Dickerson", "Dickson", "Dillard", "Dillon", "Dixon", "Dodson",
        "Dominguez", "Donaldson", "Donovan", "Dorsey", "Dotson", "Douglas", "Downs", "Doyle", "Drake", "Dudley", "Duffy", "Duke", "Duncan", "Dunlap", "Dunn", "Duran",
        "Durham", "Dyer", "Eaton", "Edwards", "Elliott", "Ellis", "Ellison", "Emerson", "England", "English", "Erickson", "Espinoza", "Estes", "Estrada", "Evans", "Everett",
        "Ewing", "Farley", "Farmer", "Farrell", "Faulkner", "Ferguson", "Fernandez", "Ferrell", "Fields", "Figueroa", "Finch", "Finley", "Fischer", "Fisher", "Fitzgerald", "Fitzpatrick",
        "Fleming", "Fletcher", "Flores", "Flowers", "Floyd", "Flynn", "Foley", "Forbes", "Ford", "Foreman", "Foster", "Fowler", "Fox", "Francis", "Franco", "Frank",
        "Franklin", "Franks", "Frazier", "Frederick", "Freeman", "French", "Frost", "Fry", "Frye", "Fuentes", "Fuller", "Fulton", "Gaines", "Gallagher", "Gallegos", "Galloway",
        "Gamble", "Garcia", "Gardner", "Garner", "Garrett", "Garrison", "Garza", "Gates", "Gay", "Gentry", "George", "Gibbs", "Gibson", "Gilbert", "Giles", "Gill",
        "Gillespie", "Gilliam", "Gilmore", "Glass", "Glenn", "Glover", "Goff", "Golden", "Gomez", "Gonzales", "Gonzalez", "Good", "Goodman", "Goodwin", "Gordon", "Gould",
        "Graham", "Grant", "Graves", "Gray", "Green", "Greene", "Greer", "Gregory", "Griffin", "Griffith", "Grimes", "Gross", "Guerra", "Guerrero", "Guthrie", "Gutierrez",
        "Guy", "Guzman", "Hahn", "Hale", "Haley", "Hall", "Hamilton", "Hammond", "Hampton", "Hancock", "Haney", "Hansen", "Hanson", "Hardin", "Harding", "Hardy",
        "Harmon", "Harper", "Harrell", "Harrington", "Harris", "Harrison", "Hart", "Hartman", "Harvey", "Hatfield", "Hawkins", "Hayden", "Hayes", "Haynes", "Hays", "Head",
        "Heath", "Hebert", "Henderson", "Hendricks", "Hendrix", "Henry", "Hensley", "Henson", "Herman", "Hernandez", "Herrera", "Herring", "Hess", "Hester", "Hewitt", "Hickman",
        "Hicks", "Higgins", "Hill", "Hines", "Hinton", "Hobbs", "Hodge", "Hodges", "Hoffman", "Hogan", "Holcomb", "Holden", "Holder", "Holland", "Holloway", "Holman",
        "Holmes", "Holt", "Hood", "Hooper", "Hoover", "Hopkins", "Hopper", "Horn", "Horne", "Horton", "House", "Houston", "Howard", "Howe", "Howell", "Hubbard",
        "Huber", "Hudson", "Huff", "Huffman", "Hughes", "Hull", "Humphrey", "Hunt", "Hunter", "Hurley", "Hurst", "Hutchinson", "Hyde", "Ingram", "Irwin", "Jackson",
        "Jacobs", "Jacobson", "James", "Jarvis", "Jefferson", "Jenkins", "Jennings", "Jensen", "Jimenez", "Johns", "Johnson", "Johnston", "Jones", "Jordan", "Joseph", "Joyce",
        "Joyner", "Juarez", "Justice", "Kane", "Kaufman", "Keith", "Keller", "Kelley", "Kelly", "Kemp", "Kennedy", "Kent", "Kerr", "Key", "Kidd", "Kim",
        "King", "Kinney", "Kirby", "Kirk", "Kirkland", "Klein", "Kline", "Knapp", "Knight", "Knowles", "Knox", "Koch", "Kramer", "Lamb", "Lambert", "Lancaster",
        "Landry", "Lane", "Lang", "Langley", "Lara", "Larsen", "Larson", "Lawrence", "Lawson", "Le", "Leach", "Leblanc", "Lee", "Leon", "Leonard", "Lester",
        "Levine", "Levy", "Lewis", "Lindsay", "Lindsey", "Little", "Livingston", "Lloyd", "Logan", "Long", "Lopez", "Lott", "Love", "Lowe", "Lowery", "Lucas",
        "Luna", "Lynch", "Lynn", "Lyons", "Macdonald", "Macias", "Mack", "Madden", "Maddox", "Maldonado", "Malone", "Mann", "Manning", "Marks", "Marquez", "Marsh",
        "Marshall", "Martin", "Martinez", "Mason", "Massey", "Mathews", "Mathis", "Matthews", "Maxwell", "May", "Mayer", "Maynard", "Mayo", "Mays", "McBride", "McCall",
        "McCarthy", "McCarty", "McClain", "McClure", "McConnell", "McCormick", "McCoy", "McCray", "McCullough", "McDaniel", "McDonald", "McDowell", "McFadden", "McFarland", "McGee", "McGowan",
        "McGuire", "McIntosh", "McIntyre", "McKay", "McKee", "McKenzie", "McKinney", "McKnight", "McLaughlin", "Mclean", "McLeod", "McMahon", "McMillan", "McNeil", "McPherson", "Meadows",
        "Medina", "Mejia", "Melendez", "Melton", "Mendez", "Mendoza", "Mercado", "Mercer", "Merrill", "Merritt", "Meyer", "Meyers", "Michael", "Middleton", "Miles", "Miller",
        "Mills", "Miranda", "Mitchell", "Molina", "Monroe", "Montgomery", "Montoya", "Moody", "Moon", "Mooney", "Moore", "Morales", "Moran", "Moreno", "Morgan", "Morin",
        "Morris", "Morrison", "Morrow", "Morse", "Morton", "Moses", "Mosley", "Moss", "Mueller", "Mullen", "Mullins", "Munoz", "Murphy", "Murray", "Myers", "Nash",
        "Navarro", "Neal", "Nelson", "Newman", "Newton", "Nguyen", "Nichols", "Nicholson", "Nielsen", "Nieves", "Nixon", "Noble", "Noel", "Nolan", "Norman", "Norris",
        "Norton", "Nunez", "OBrien", "Ochoa", "OConnor", "Odom", "Odonnell", "Oliver", "Olsen", "Olson", "Oneal", "Oneil", "Oneill", "Orr", "Ortega", "Ortiz",
        "Osborn", "Osborne", "Owen", "Owens", "Pace", "Pacheco", "Padilla", "Page", "Palmer", "Park", "Parker", "Parks", "Parrish", "Parsons", "Pate", "Patel",
        "Patrick", "Patterson", "Patton", "Paul", "Payne", "Pearson", "Peck", "Pena", "Pennington", "Perez", "Perkins", "Perry", "Peters", "Petersen", "Peterson", "Petty",
        "Phelps", "Phillips", "Pickett", "Pierce", "Pittman", "Pitts", "Pollard", "Poole", "Pope", "Porter", "Potter", "Potts", "Powell", "Powers", "Pratt", "Preston",
        "Price", "Prince", "Pruitt", "Puckett", "Pugh", "Quinn", "Ramirez", "Ramos", "Ramsey", "Randall", "Randolph", "Rasmussen", "Ratliff", "Ray", "Raymond", "Reed",
        "Reese", "Reeves", "Reid", "Reilly", "Reyes", "Reynolds", "Rhodes", "Rice", "Rich", "Richard", "Richards", "Richardson", "Richmond", "Riddle", "Riggs", "Riley",
        "Rios", "Rivas", "Rivera", "Rivers", "Roach", "Robbins", "Roberson", "Roberts", "Robertson", "Robinson", "Robles", "Rocha", "Rodgers", "Rodriguez", "Rodriquez", "Rogers",
        "Rojas", "Rollins", "Roman", "Romero", "Rosa", "Rosales", "Rosario", "Rose", "Ross", "Roth", "Rowe", "Rowland", "Roy", "Ruiz", "Rush", "Russell",
        "Russo", "Rutledge", "Ryan", "Salas", "Salazar", "Salinas", "Sampson", "Sanchez", "Sanders", "Sandoval", "Sanford", "Santana", "Santiago", "Santos", "Sargent", "Saunders",
        "Savage", "Sawyer", "Schmidt", "Schneider", "Schroeder", "Schultz", "Schwartz", "Scott", "Sears", "Sellers", "Serrano", "Sexton", "Shaffer", "Shannon", "Sharp", "Sharpe",
        "Shaw", "Shelton", "Shepard", "Shepherd", "Sheppard", "Sherman", "Shields", "Short", "Silva", "Simmons", "Simon", "Simpson", "Sims", "Singleton", "Skinner", "Slater",
        "Sloan", "Small", "Smith", "Snider", "Snow", "Snyder", "Solis", "Solomon", "Sosa", "Soto", "Sparks", "Spears", "Spence", "Spencer", "Stafford", "Stanley",
        "Stanton", "Stark", "Steele", "Stein", "Stephens", "Stephenson", "Stevens", "Stevenson", "Stewart", "Stokes", "Stone", "Stout", "Strickland", "Strong", "Stuart", "Suarez",
        "Sullivan", "Summers", "Sutton", "Swanson", "Sweeney", "Sweet", "Sykes", "Talley", "Tanner", "Tate", "Taylor", "Terrell", "Terry", "Thomas", "Thompson", "Thornton",
        "Tillman", "Todd", "Torres", "Townsend", "Tran", "Travis", "Trevino", "Trujillo", "Tucker", "Turner", "Tyler", "Tyson", "Underwood", "Valdez", "Valencia", "Valentine",
        "Valenzuela", "Vance", "Vang", "Vargas", "Vasquez", "Vaughan", "Vaughn", "Vazquez", "Vega", "Velasquez", "Velazquez", "Velez", "Villarreal", "Vincent", "Vinson", "Wade",
        "Wagner", "Walker", "Wall", "Wallace", "Waller", "Walls", "Walsh", "Walter", "Walters", "Walton", "Ward", "Ware", "Warner", "Warren", "Washington", "Waters",
        "Watkins", "Watson", "Watts", "Weaver", "Webb", "Weber", "Webster", "Weeks", "Weiss", "Welch", "Wells", "West", "Wheeler", "Whitaker", "White", "Whitehead",
        "Whitfield", "Whitley", "Whitney", "Wiggins", "Wilcox", "Wilder", "Wiley", "Wilkerson", "Wilkins", "Wilkinson", "William", "Williams", "Williamson", "Willis", "Wilson", "Winters",
        "Wise", "Witt", "Wolf", "Wolfe", "Wong", "Wood", "Woodard", "Woods", "Woodward", "Wooten", "Workman", "Wright", "Wyatt", "Wynn", "Yang", "Yates",
        "York", "Young", "Zamora", "Zimmerman"
     };

    private static string[] StreetNames = new string[] {
      "Main Street", "Church Street", "Main Street North", "High Street", "Main Street South",
      "Elm Street", "Washington Street", "Main Street West", "Main Street East", "Chestnut Street",
      "2nd Street", "Park Avenue", "Broad Street", "Walnut Street", "Maple Street", "Maple Avenue",
      "Water Street", "Center Street", "Pine Street", "Market Street", "Oak Street", "South Street",
      "Union Street", "North Street", "3rd Street", "River Road", "School Street", "Court Street",
      "Prospect Street", "Spring Street", "Washington Avenue", "Park Street", "Front Street",
      "Central Avenue", "Cherry Street", "Cedar Street", "4th Street", "Franklin Street", "Jefferson Street",
      "1st Street", "Highland Avenue", "Mill Street", "West Street", "Bridge Street", "Spruce Street",
      "Jackson Street", "Pleasant Street", "5th Street", "Academy Street", "Madison Avenue",
      "Pearl Street", "Park Place", "Pennsylvania Avenue", "State Street", "Adams Street",
      "East Street", "Madison Street", "Ridge Road", "Church Road", "Elizabeth Street",
      "Green Street", "Grove Street", "Hill Street", "Lincoln Avenue", "Locust Street",
      "Jefferson Avenue", "Lincoln Street", "11th Street", "Dogwood Drive", "Liberty Street",
      "River Street", "Route 30", "Vine Street", "12th Street", "2nd Avenue", "Hillside Avenue",
      "Route 1", "10th Street", "4th Street West", "6th Street", "7th Street", "Delaware Avenue",
      "Meadow Lane", "Winding Way", "3rd Street West", "5th Avenue", "9th Street", "Broadway",
      "Clinton Street", "Monroe Street", "New Street", "Railroad Street", "Route 6", "3rd Avenue",
      "Beech Street", "Cherry Lane", "Hickory Lane", "Lake Street", "2nd Street West", "Charles Street",
      "Colonial Drive", "Front Street North", "Laurel Lane", "Oak Lane", "Railroad Avenue", "Summit Avenue",
      "Valley Road", "Williams Street", "Willow Street", "13th Street", "1st Avenue", "7th Avenue", "8th Street",
      "Division Street", "Harrison Street", "King Street", "Mill Road", "Poplar Street", "Route 29", "Virginia Avenue",
      "Woodland Drive", "4th Avenue", "4th Street North", "Arch Street", "Brookside Drive", "Cambridge Court",
      "Canterbury Court", "College Street", "Creek Road", "Fairway Drive", "Heather Lane", "Highland Drive",
      "Holly Drive", "Mulberry Street", "Myrtle Avenue", "Penn Street", "Prospect Avenue", "Route 32", "Smith Street",
      "Sunset Drive", "5th Street North", "Bank Street", "Canal Street", "Cedar Lane", "Colonial Avenue", "Dogwood Lane",
      "Durham Road", "Grant Avenue", "Hamilton Street", "John Street", "Primrose Lane", "Riverside Drive", "Route 10",
      "Surrey Lane", "Valley View Drive", "5th Street West", "6th Street North", "6th Street West", "Beechwood Drive",
      "Buckingham Drive", "Cedar Avenue", "Circle Drive", "Clark Street", "Deerfield Drive", "Elm Avenue", "Essex Court",
      "Fairview Avenue", "Forest Drive", "Franklin Court", "Garden Street", "George Street", "Henry Street", "James Street",
      "Lafayette Avenue", "Lakeview Drive", "Laurel Street", "Lilac Lane", "Maple Lane", "Oak Avenue", "Oxford Court",
      "Ridge Avenue", "Route 11", "Route 70", "Taylor Street", "Walnut Avenue", "Warren Street", "Woodland Avenue",
      "2nd Street East", "2nd Street North", "Aspen Court", "Atlantic Avenue", "Church Street North", "Cottage Street",
      "Devon Road", "Franklin Avenue", "Garfield Avenue", "Glenwood Avenue", "Grant Street", "Hillside Drive", "Hilltop Road",
      "Lafayette Street", "Linden Street", "Locust Lane", "Olive Street", "Orange Street", "Orchard Street", "Park Drive",
      "Race Street", "Route 4", "Route 41", "Route 7", "Route 9", "Windsor Court", "York Road", "3rd Street East",
      "3rd Street North", "5th Street South", "6th Avenue", "Arlington Avenue", "Belmont Avenue", "Berkshire Drive",
      "Cedar Court", "Chapel Street", "Chestnut Avenue", "Clay Street", "College Avenue", "Creekside Drive", "Crescent Street",
      "Cypress Court", "Devonshire Drive", "Front Street South", "Fulton Street", "Grove Avenue", "Hillcrest Avenue",
      "Inverness Drive", "Jackson Avenue", "Laurel Drive", "Magnolia Avenue", "Magnolia Drive", "Mechanic Street", "Route 20",
      "Route 202", "Summit Street", "Tanglewood Drive", "Wall Street", "William Street", "Windsor Drive", "York Street",
      "8th Avenue", "8th Street South", "8th Street West", "Ann Street", "Brown Street", "Buttonwood Drive", "Cambridge Drive",
      "Cambridge Road", "Cardinal Drive", "Carriage Drive", "Cemetery Road", "Church Street South", "Cobblestone Court",
      "Columbia Street", "Cooper Street", "Depot Street", "Edgewood Drive", "Elmwood Avenue", "Evergreen Lane", "Fawn Lane",
      "Fieldstone Drive", "Forest Street", "Hawthorne Lane", "Heritage Drive", "Hickory Street", "Hillcrest Drive",
      "Howard Street", "Jefferson Court", "Lantern Lane", "Magnolia Court", "Meadow Street", "Pin Oak Drive", "Queen Street",
      "Redwood Drive", "Ridge Street", "Rose Street", "Route 100", "Route 44", "Sherman Street", "Strawberry Lane",
      "Street Road", "Sunset Avenue", "Sycamore Drive", "Valley Drive", "Westminster Drive", "Wood Street", "12th Street East",
      "9th Street West", "Augusta Drive", "Briarwood Drive", "Bridle Lane", "Brook Lane", "Canterbury Drive", "Catherine Street",
      "Cleveland Street", "Country Lane", "Durham Court", "Eagle Road", "Eagle Street", "Edgewood Road", "Euclid Avenue",
      "Forest Avenue", "Grand Avenue", "Hamilton Road", "Harrison Avenue", "Hartford Road", "Heather Court", "Holly Court",
      "Ivy Court", "Lake Avenue", "Lawrence Street", "Lexington Drive", "Madison Court", "Morris Street", "Mulberry Court",
      "Mulberry Lane", "Myrtle Street", "Old York Road", "Orchard Avenue", "Orchard Lane", "Pheasant Run", "Rosewood Drive",
      "Route 17", "Sheffield Drive", "Sherwood Drive", "Sycamore Lane", "Sycamore Street", "Victoria Court", "Warren Avenue",
      "West Avenue", "Woodland Road", "14th Street", "4th Street South", "5th Street East", "Adams Avenue", "Amherst Street",
      "Andover Court", "Ashley Court", "Aspen Drive", "B Street", "Bay Street", "Bayberry Drive", "Brandywine Drive", "Briarwood Court",
      "Bridle Court", "Broad Street West", "Canterbury Road", "Cleveland Avenue", "Country Club Drive", "Country Club Road", "Cross Street",
      "Devon Court", "East Avenue", "Evergreen Drive", "Fairview Road", "Fawn Court", "Glenwood Drive", "Hanover Court", "Hawthorne Avenue",
      "Homestead Drive", "Hudson Street", "Ivy Lane", "Jones Street", "Lexington Court", "Linda Lane", "Linden Avenue", "Maiden Lane", "Manor Drive",
      "Marshall Street", "Monroe Drive", "North Avenue", "Overlook Circle", "Oxford Road", "Parker Street", "Roberts Road", "Roosevelt Avenue",
      "Route 2", "Route 27", "Route 5", "Route 64", "Schoolhouse Lane", "Shady Lane", "Somerset Drive", "Spruce Avenue", "State Street East",
      "Summer Street", "Valley View Road", "Virginia Street", "White Street", "Willow Avenue", "Willow Drive", "Willow Lane"
    };

    #endregion


    private static Random WingtipRandom = new Random(7);

    // Methods

    private static int CustomerGrowthPhase = 1;

    public static void SetCustomerGrowthPhase(int value) {
      CustomerGrowthPhase = value;
    }

    private static int[] productIdsPhase1 = { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 4, 4, 4, 4, 4, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 11, 12, 12, 13, 13, 13, 13, 13, 13, 13, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 21, 21, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 24, 24, 24, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27 };
    private static int[] productIdsPhase2 = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 10, 10, 10, 10, 10, 10, 11, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 29, 29, 29, 29, 29, 29, 30, 30 };
    private static int[] productIdsPhase3 = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 30 };
    private static int[] productIdsPhase4 = { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 16, 16, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 30, 31, 31, 31, 31, 31, 31, 31, 31, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32 };
    private static int GetProductId() {

      int[] productIDs = productIdsPhase1;
      if (CustomerGrowthPhase == 2) {
        productIDs = productIdsPhase2;
      }
      if (CustomerGrowthPhase == 3) {
        productIDs = productIdsPhase3;
      }
      if (CustomerGrowthPhase == 4) {
        productIDs = productIdsPhase4;
      }

      return productIDs[WingtipRandom.Next(0, productIDs.Length - 1)];
    }

    public static IEnumerable<CustomerData> GetCustomerList() {
      return GetCustomerList(10);
    }

    public static IEnumerable<CustomerData> GetCustomerList(int CustomerCount) {
      return GetCustomerList(CustomerCount, true);
    }

    public static IEnumerable<CustomerData> GetCustomerList(int CustomerCount, bool Predictable) {
      if (Predictable) {
        WingtipRandom = new Random(714);
      }
      else {
        WingtipRandom = new Random(Guid.NewGuid().GetHashCode());
      }
      List<CustomerData> list = new List<CustomerData>(CustomerCount);
      for (int i = 1; i <= CustomerCount; i++) {
        list.Add(GetNextCustomer());
      }
      return list;
    }

    public static IEnumerable<CustomerData> GetCustomerList(int CustomerCount, int Seed) {
      WingtipRandom = new Random(Seed);
      List<CustomerData> list = new List<CustomerData>(CustomerCount);
      for (int i = 1; i <= CustomerCount; i++) {
        list.Add(GetNextCustomer());
      }
      return list;
    }

    private static CustomerLocationData GetNextCustomerLocation() {

      CustomerLocationData[] customerLocations;

      switch (CustomerGrowthPhase) {
        case 1:
          customerLocations = CustomerLocations;
          break;
        case 2:
          customerLocations = CustomerLocations2;
          break;
        case 3:
          customerLocations = CustomerLocations3;
          break;
        case 4:
          customerLocations = CustomerLocations4;
          break;
        default:
          customerLocations = CustomerLocations4;
          break;
      }
      int index = WingtipRandom.Next(0, customerLocations.Length);
      return customerLocations[index];
    }

    private static string GetNextCompany() {
      int index = WingtipRandom.Next(0, CompanyNames.Length);
      return CompanyNames[index];
    }

    private static string GetNextFemaleFirstName() {
      int index = WingtipRandom.Next(0, FemaleFirstNames.Length);
      return FemaleFirstNames[index];
    }

    private static string GetNextMaleFirstName() {
      int index = WingtipRandom.Next(0, MaleFirstNames.Length);
      return MaleFirstNames[index];
    }

    private static string GetNextLastName() {
      int index = WingtipRandom.Next(0, LastNames.Length);
      return LastNames[index];
    }

    private static string GetNextAddress() {

      int StreetNumberDigitCount = WingtipRandom.Next(2, 5);
      string StreetNumber = WingtipRandom.Next(14, Convert.ToInt32(Math.Pow(10, StreetNumberDigitCount))).ToString();
      string StreetName = StreetNames[WingtipRandom.Next(0, StreetNames.Length)];
      return StreetNumber + " " + StreetName;
    }

    private static string GetNextPhoneNumber() {
      return ("1(" + WingtipRandom.Next(2, 9).ToString() + WingtipRandom.Next(0, 9).ToString() + WingtipRandom.Next(0, 9).ToString() + ")" + WingtipRandom.Next(2, 9).ToString() + WingtipRandom.Next(0, 9).ToString() + WingtipRandom.Next(0, 9).ToString() + "-" + WingtipRandom.Next(0, 9).ToString() + WingtipRandom.Next(0, 9).ToString() + WingtipRandom.Next(0, 9).ToString() + WingtipRandom.Next(0, 9).ToString());
    }

    private static string GetNextPhoneNumber(string AreaCode) {

      string FirstDigit = WingtipRandom.Next(1, 9).ToString();
      string SecondDigit = WingtipRandom.Next(0, 9).ToString();

      return ("1(" + AreaCode + ")" +
              FirstDigit + FirstDigit + FirstDigit +
              "-" +
              SecondDigit + SecondDigit + SecondDigit + SecondDigit);
    }

    private static DateTime GetNextBirthDate() {
      return new DateTime(WingtipRandom.Next(1942, 1996), WingtipRandom.Next(1, 12), WingtipRandom.Next(1, 28));
    }

  }

}
