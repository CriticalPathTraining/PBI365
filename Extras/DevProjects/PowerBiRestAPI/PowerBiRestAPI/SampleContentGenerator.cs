using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerBiRestAPI {
  class SampleContentGenerator {
  }

  #region "Classes for generating sample data for wingtip sales model"

  public class DonationLocationData {
    public string AreaCode { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
  }

  public class DonationData {
    public int ID{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Gender { get; set; }
    public double Amount { get; set; }

  }


  #endregion

  public class DataFactory {


    private static int donarCount = 0;
    public static DonationData GetNextDonation() {

      DonationLocationData donarLocation = GetNextDonationLocation();

      int donarId = donarCount;
      donarCount++;

      string City = donarLocation.City;
      string State = donarLocation.State;
      string ZipCode = donarLocation.ZipCode;

   
      string Gender = "F";
   
      switch (DonationGrowthPhase) {
        case 1:

          // phase 1
          if (WingtipRandom.Next(1, 100) > 32) {
            Gender = "M";
          }

          break;
        case 2:
          // phase 2
          if (WingtipRandom.Next(1, 100) > 55) {
            Gender = "M";
          } 

          break;
        default:
          // phase 3
          if (WingtipRandom.Next(1, 100) > 70) {
            Gender = "M";
          }          
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

      DonationData newDonation = new DonationData {
        ID = donarId,
        FirstName = FirstName,
        LastName = LastName,
        City = City,
        State = State,
        ZipCode = ZipCode,
        Gender = Gender,
        Amount = GetNextContributionAmount()
      };

      
      return newDonation;

    }

    #region " static fields with arrays of field values"



    private static DonationLocationData[] DonationLocations = new DonationLocationData[]{
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new DonationLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new DonationLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new DonationLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new DonationLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new DonationLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new DonationLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new DonationLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new DonationLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97205", AreaCode="503" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97220", AreaCode="971" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new DonationLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new DonationLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new DonationLocationData{ City="Issaquah", State="WA", ZipCode="98027", AreaCode="425" },
      new DonationLocationData{ City="Spokane", State="WA", ZipCode="99218", AreaCode="509" },
      new DonationLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new DonationLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new DonationLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" }
    };

    private static DonationLocationData[] DonationLocations2 = new DonationLocationData[]{
      new DonationLocationData{ City="Phoenix", State="AZ", ZipCode="85044", AreaCode="480" },
      new DonationLocationData{ City="Phoenix", State="AZ", ZipCode="85018", AreaCode="602" },
      new DonationLocationData{ City="Phoenix", State="AZ", ZipCode="85022", AreaCode="602" },
      new DonationLocationData{ City="Scottsdale", State="AZ", ZipCode="85266", AreaCode="480" },
      new DonationLocationData{ City="Scottsdale", State="AZ", ZipCode="85250", AreaCode="480" },
      new DonationLocationData{ City="Alameda", State="CA", ZipCode="94501", AreaCode="510" },
      new DonationLocationData{ City="San Diego", State="CA", ZipCode="92111", AreaCode="858" },
      new DonationLocationData{ City="Irvine", State="CA", ZipCode="92606", AreaCode="949" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new DonationLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new DonationLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new DonationLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new DonationLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new DonationLocationData{ City="Albuquerque", State="NM", ZipCode="87112", AreaCode="505" },
      new DonationLocationData{ City="Albuquerque", State="NM", ZipCode="87113", AreaCode="505" },
      new DonationLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new DonationLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new DonationLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new DonationLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97205", AreaCode="503" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97220", AreaCode="971" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new DonationLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new DonationLocationData{ City="Springfield", State="OR", ZipCode="97477", AreaCode="541" },
      new DonationLocationData{ City="Beaverton", State="OR", ZipCode="97006", AreaCode="503" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78209", AreaCode="210" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78753", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78717", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78758", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78749", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78704", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78748", AreaCode="512" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78232", AreaCode="210" },
      new DonationLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new DonationLocationData{ City="Fort Worth", State="TX", ZipCode="76132", AreaCode="817" },
      new DonationLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new DonationLocationData{ City="Issaquah", State="WA", ZipCode="98027", AreaCode="425" },
      new DonationLocationData{ City="Spokane", State="WA", ZipCode="99218", AreaCode="509" },
      new DonationLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new DonationLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new DonationLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" }
    };

    private static DonationLocationData[] DonationLocations3 = new DonationLocationData[]{
      new DonationLocationData{ City="Mobile", State="AL", ZipCode="36695", AreaCode="251" },
      new DonationLocationData{ City="Mobile", State="AL", ZipCode="36606", AreaCode="251" },
      new DonationLocationData{ City="Birmingham", State="AL", ZipCode="35242", AreaCode="205" },
      new DonationLocationData{ City="Birmingham", State="AL", ZipCode="35226", AreaCode="205" },
      new DonationLocationData{ City="Tuscaloosa", State="AL", ZipCode="35404", AreaCode="205" },
      new DonationLocationData{ City="Phoenix", State="AZ", ZipCode="85044", AreaCode="480" },
      new DonationLocationData{ City="Phoenix", State="AZ", ZipCode="85018", AreaCode="602" },
      new DonationLocationData{ City="Phoenix", State="AZ", ZipCode="85022", AreaCode="602" },
      new DonationLocationData{ City="Scottsdale", State="AZ", ZipCode="85266", AreaCode="480" },
      new DonationLocationData{ City="Scottsdale", State="AZ", ZipCode="85250", AreaCode="480" },
      new DonationLocationData{ City="Phoenix", State="AZ", ZipCode="85042", AreaCode="602" },
      new DonationLocationData{ City="Surprise", State="AZ", ZipCode="85374", AreaCode="623" },
      new DonationLocationData{ City="Tempe", State="AZ", ZipCode="85281", AreaCode="480" },
      new DonationLocationData{ City="Tempe", State="AZ", ZipCode="85283", AreaCode="480" },
      new DonationLocationData{ City="Tucson", State="AZ", ZipCode="85711", AreaCode="520" },
      new DonationLocationData{ City="Tucson", State="AZ", ZipCode="85716", AreaCode="520" },
      new DonationLocationData{ City="Tucson", State="AZ", ZipCode="85715", AreaCode="520" },
      new DonationLocationData{ City="Tucson", State="AZ", ZipCode="85741", AreaCode="520" },
      new DonationLocationData{ City="Tucson", State="AZ", ZipCode="85705", AreaCode="520" },
      new DonationLocationData{ City="Tucson", State="AZ", ZipCode="85748", AreaCode="520" },
      new DonationLocationData{ City="Tucson", State="AZ", ZipCode="85714", AreaCode="520" },
      new DonationLocationData{ City="Alameda", State="CA", ZipCode="94501", AreaCode="510" },
      new DonationLocationData{ City="Anaheim", State="CA", ZipCode="92808", AreaCode="714" },
      new DonationLocationData{ City="Anaheim", State="CA", ZipCode="92802", AreaCode="714" },
      new DonationLocationData{ City="Bakersfield", State="CA", ZipCode="93304", AreaCode="661" },
      new DonationLocationData{ City="Bakersfield", State="CA", ZipCode="93306", AreaCode="661" },
      new DonationLocationData{ City="Bakersfield", State="CA", ZipCode="93312", AreaCode="661" },
      new DonationLocationData{ City="Bakersfield", State="CA", ZipCode="93311", AreaCode="661" },
      new DonationLocationData{ City="San Diego", State="CA", ZipCode="92111", AreaCode="858" },
      new DonationLocationData{ City="Burbank", State="CA", ZipCode="91504", AreaCode="818" },
      new DonationLocationData{ City="Los Angeles", State="CA", ZipCode="90022", AreaCode="323" },
      new DonationLocationData{ City="Compton", State="CA", ZipCode="90220", AreaCode="310" },
      new DonationLocationData{ City="Corona", State="CA", ZipCode="92881", AreaCode="951" },
      new DonationLocationData{ City="Cupertino", State="CA", ZipCode="95014", AreaCode="408" },
      new DonationLocationData{ City="Eureka", State="CA", ZipCode="95501", AreaCode="707" },
      new DonationLocationData{ City="Folsom", State="CA", ZipCode="95630", AreaCode="916" },
      new DonationLocationData{ City="Fresno", State="CA", ZipCode="93710", AreaCode="559" },
      new DonationLocationData{ City="Fresno", State="CA", ZipCode="93722", AreaCode="559" },
      new DonationLocationData{ City="Fresno", State="CA", ZipCode="93726", AreaCode="559" },
      new DonationLocationData{ City="Huntington Beach", State="CA", ZipCode="92646", AreaCode="714" },
      new DonationLocationData{ City="Irvine", State="CA", ZipCode="92602", AreaCode="714" },
      new DonationLocationData{ City="Irvine", State="CA", ZipCode="92606", AreaCode="949" },
      new DonationLocationData{ City="Irvine", State="CA", ZipCode="92618", AreaCode="949" },
      new DonationLocationData{ City="Los Angeles", State="CA", ZipCode="90048", AreaCode="323" },
      new DonationLocationData{ City="Los Angeles", State="CA", ZipCode="90017", AreaCode="213" },
      new DonationLocationData{ City="Los Angeles", State="CA", ZipCode="90024", AreaCode="310" },
      new DonationLocationData{ City="Long Beach", State="CA", ZipCode="90815", AreaCode="562" },
      new DonationLocationData{ City="Long Beach", State="CA", ZipCode="90805", AreaCode="562" },
      new DonationLocationData{ City="Los Angeles", State="CA", ZipCode="90041", AreaCode="323" },
      new DonationLocationData{ City="Los Angeles", State="CA", ZipCode="90016", AreaCode="310" },
      new DonationLocationData{ City="Manhattan Beach", State="CA", ZipCode="90266", AreaCode="310" },
      new DonationLocationData{ City="San Diego", State="CA", ZipCode="92126", AreaCode="858" },
      new DonationLocationData{ City="Napa", State="CA", ZipCode="94558", AreaCode="707" },
      new DonationLocationData{ City="Napa", State="CA", ZipCode="94559", AreaCode="707" },
      new DonationLocationData{ City="North Hollywood", State="CA", ZipCode="91606", AreaCode="818" },
      new DonationLocationData{ City="Rancho Cucamonga", State="CA", ZipCode="91730", AreaCode="909" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95825", AreaCode="916" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95817", AreaCode="916" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95841", AreaCode="916" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95834", AreaCode="916" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95818", AreaCode="916" },
      new DonationLocationData{ City="Sacramento", State="CA", ZipCode="95823", AreaCode="916" },
      new DonationLocationData{ City="San Francisco", State="CA", ZipCode="94103", AreaCode="415" },
      new DonationLocationData{ City="San Francisco", State="CA", ZipCode="94118", AreaCode="415" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95133", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95125", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95110", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95121", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95132", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95134", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95123", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95123", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95122", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95124", AreaCode="408" },
      new DonationLocationData{ City="San Jose", State="CA", ZipCode="95129", AreaCode="408" },
      new DonationLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new DonationLocationData{ City="Ventura", State="CA", ZipCode="93003", AreaCode="805" },
      new DonationLocationData{ City="Boulder", State="CO", ZipCode="80301", AreaCode="303" },
      new DonationLocationData{ City="Colorado Springs", State="CO", ZipCode="80922", AreaCode="719" },
      new DonationLocationData{ City="Colorado Springs", State="CO", ZipCode="80924", AreaCode="719" },
      new DonationLocationData{ City="Colorado Springs", State="CO", ZipCode="80918", AreaCode="719" },
      new DonationLocationData{ City="Denver", State="CO", ZipCode="80231", AreaCode="303" },
      new DonationLocationData{ City="Denver", State="CO", ZipCode="80238", AreaCode="303" },
      new DonationLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new DonationLocationData{ City="Fort Collins", State="CO", ZipCode="80525", AreaCode="970" },
      new DonationLocationData{ City="Glenwood Springs", State="CO", ZipCode="81601", AreaCode="970" },
      new DonationLocationData{ City="Grand Junction", State="CO", ZipCode="81505", AreaCode="970" },
      new DonationLocationData{ City="Pueblo", State="CO", ZipCode="81008", AreaCode="719" },
      new DonationLocationData{ City="Colorado Springs", State="CO", ZipCode="80906", AreaCode="719" },
      new DonationLocationData{ City="Westminster", State="CO", ZipCode="80023", AreaCode="303" },
      new DonationLocationData{ City="Westminster", State="CO", ZipCode="80021", AreaCode="303" },
      new DonationLocationData{ City="New Britain", State="CT", ZipCode="06053", AreaCode="860" },
      new DonationLocationData{ City="Greenwich", State="CT", ZipCode="06830", AreaCode="203" },
      new DonationLocationData{ City="North Haven", State="CT", ZipCode="06473", AreaCode="203" },
      new DonationLocationData{ City="Stamford", State="CT", ZipCode="06901", AreaCode="203" },
      new DonationLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new DonationLocationData{ City="Trumbull", State="CT", ZipCode="06611", AreaCode="203" },
      new DonationLocationData{ City="Waterbury", State="CT", ZipCode="06704", AreaCode="203" },
      new DonationLocationData{ City="Waterford", State="CT", ZipCode="06385", AreaCode="860" },
      new DonationLocationData{ City="Windsor", State="CT", ZipCode="06095", AreaCode="860" },
      new DonationLocationData{ City="Brandon", State="FL", ZipCode="33511", AreaCode="813" },
      new DonationLocationData{ City="Riverview", State="FL", ZipCode="33578", AreaCode="813" },
      new DonationLocationData{ City="Cape Coral", State="FL", ZipCode="33909", AreaCode="239" },
      new DonationLocationData{ City="Cape Coral", State="FL", ZipCode="33914", AreaCode="239" },
      new DonationLocationData{ City="Clearwater", State="FL", ZipCode="33759", AreaCode="727" },
      new DonationLocationData{ City="Clermont", State="FL", ZipCode="34711", AreaCode="352" },
      new DonationLocationData{ City="Miami", State="FL", ZipCode="33189", AreaCode="305" },
      new DonationLocationData{ City="Miami", State="FL", ZipCode="33143", AreaCode="305" },
      new DonationLocationData{ City="Miami", State="FL", ZipCode="33156", AreaCode="305" },
      new DonationLocationData{ City="Daytona Beach", State="FL", ZipCode="32114", AreaCode="386" },
      new DonationLocationData{ City="Orlando", State="FL", ZipCode="32803", AreaCode="407" },
      new DonationLocationData{ City="Fort Lauderdale", State="FL", ZipCode="33306", AreaCode="954" },
      new DonationLocationData{ City="Gainesville", State="FL", ZipCode="32608", AreaCode="352" },
      new DonationLocationData{ City="Tampa", State="FL", ZipCode="33611", AreaCode="813" },
      new DonationLocationData{ City="Greenacres", State="FL", ZipCode="33463", AreaCode="561" },
      new DonationLocationData{ City="Orlando", State="FL", ZipCode="32837", AreaCode="407" },
      new DonationLocationData{ City="Jacksonville Beach", State="FL", ZipCode="32250", AreaCode="904" },
      new DonationLocationData{ City="Jacksonville", State="FL", ZipCode="32224", AreaCode="904" },
      new DonationLocationData{ City="Jacksonville", State="FL", ZipCode="32257", AreaCode="904" },
      new DonationLocationData{ City="Jacksonville", State="FL", ZipCode="32246", AreaCode="904" },
      new DonationLocationData{ City="Jacksonville", State="FL", ZipCode="32222", AreaCode="904" },
      new DonationLocationData{ City="Miami", State="FL", ZipCode="33196", AreaCode="305" },
      new DonationLocationData{ City="Naples", State="FL", ZipCode="34119", AreaCode="239" },
      new DonationLocationData{ City="Naples", State="FL", ZipCode="34109", AreaCode="239" },
      new DonationLocationData{ City="Wesley Chapel", State="FL", ZipCode="33544", AreaCode="813" },
      new DonationLocationData{ City="Tampa", State="FL", ZipCode="33618", AreaCode="813" },
      new DonationLocationData{ City="Sarasota", State="FL", ZipCode="34232", AreaCode="941" },
      new DonationLocationData{ City="Kissimmee", State="FL", ZipCode="34747", AreaCode="321" },
      new DonationLocationData{ City="Pensacola", State="FL", ZipCode="32514", AreaCode="850" },
      new DonationLocationData{ City="Pensacola", State="FL", ZipCode="32503", AreaCode="850" },
      new DonationLocationData{ City="Pensacola", State="FL", ZipCode="32506", AreaCode="850" },
      new DonationLocationData{ City="Tallahassee", State="FL", ZipCode="32309", AreaCode="850" },
      new DonationLocationData{ City="Tallahassee", State="FL", ZipCode="32301", AreaCode="850" },
      new DonationLocationData{ City="Venice", State="FL", ZipCode="34293", AreaCode="941" },
      new DonationLocationData{ City="Vero Beach", State="FL", ZipCode="32966", AreaCode="772" },
      new DonationLocationData{ City="Acworth", State="GA", ZipCode="30101", AreaCode="678" },
      new DonationLocationData{ City="Athens", State="GA", ZipCode="30606", AreaCode="706" },
      new DonationLocationData{ City="Atlanta", State="GA", ZipCode="30307", AreaCode="404" },
      new DonationLocationData{ City="Atlanta", State="GA", ZipCode="30363", AreaCode="678" },
      new DonationLocationData{ City="Atlanta", State="GA", ZipCode="30346", AreaCode="678" },
      new DonationLocationData{ City="Augusta", State="GA", ZipCode="30909", AreaCode="706" },
      new DonationLocationData{ City="Austell", State="GA", ZipCode="30106", AreaCode="678" },
      new DonationLocationData{ City="Atlanta", State="GA", ZipCode="30326", AreaCode="404" },
      new DonationLocationData{ City="Atlanta", State="GA", ZipCode="30324", AreaCode="404" },
      new DonationLocationData{ City="Columbus", State="GA", ZipCode="31904", AreaCode="706" },
      new DonationLocationData{ City="Fayetteville", State="GA", ZipCode="30214", AreaCode="770" },
      new DonationLocationData{ City="Norcross", State="GA", ZipCode="30092", AreaCode="770" },
      new DonationLocationData{ City="Atlanta", State="GA", ZipCode="30329", AreaCode="404" },
      new DonationLocationData{ City="Savannah", State="GA", ZipCode="31404", AreaCode="912" },
      new DonationLocationData{ City="Savannah", State="GA", ZipCode="31419", AreaCode="912" },
      new DonationLocationData{ City="Baton Rouge", State="LA", ZipCode="70816", AreaCode="225" },
      new DonationLocationData{ City="Baton Rouge", State="LA", ZipCode="70809", AreaCode="225" },
      new DonationLocationData{ City="Covington", State="LA", ZipCode="70433", AreaCode="985" },
      new DonationLocationData{ City="Lafayette", State="LA", ZipCode="70501", AreaCode="337" },
      new DonationLocationData{ City="Lafayette", State="LA", ZipCode="70508", AreaCode="337" },
      new DonationLocationData{ City="Lake Charles", State="LA", ZipCode="70601", AreaCode="337" },
      new DonationLocationData{ City="Shreveport", State="LA", ZipCode="71105", AreaCode="318" },
      new DonationLocationData{ City="Dorchester", State="MA", ZipCode="02125", AreaCode="617" },
      new DonationLocationData{ City="Braintree", State="MA", ZipCode="02184", AreaCode="781" },
      new DonationLocationData{ City="Hanover", State="MA", ZipCode="02339", AreaCode="781" },
      new DonationLocationData{ City="Marlborough", State="MA", ZipCode="01752", AreaCode="508" },
      new DonationLocationData{ City="Marlborough", State="MA", ZipCode="01752", AreaCode="508" },
      new DonationLocationData{ City="North Attleboro", State="MA", ZipCode="02760", AreaCode="508" },
      new DonationLocationData{ City="North Dartmouth", State="MA", ZipCode="02747", AreaCode="508" },
      new DonationLocationData{ City="Revere", State="MA", ZipCode="02151", AreaCode="781" },
      new DonationLocationData{ City="Saugus", State="MA", ZipCode="01906", AreaCode="781" },
      new DonationLocationData{ City="Wareham", State="MA", ZipCode="02571", AreaCode="508" },
      new DonationLocationData{ City="Worcester", State="MA", ZipCode="01605", AreaCode="508" },
      new DonationLocationData{ City="Bedford", State="NH", ZipCode="03110", AreaCode="603" },
      new DonationLocationData{ City="Concord", State="NH", ZipCode="03301", AreaCode="603" },
      new DonationLocationData{ City="Nashua", State="NH", ZipCode="03063", AreaCode="603" },
      new DonationLocationData{ City="Nashua", State="NH", ZipCode="03060", AreaCode="603" },
      new DonationLocationData{ City="Burlington", State="NJ", ZipCode="08016", AreaCode="609" },
      new DonationLocationData{ City="Cherry Hill", State="NJ", ZipCode="08002", AreaCode="856" },
      new DonationLocationData{ City="Clark", State="NJ", ZipCode="07066", AreaCode="732" },
      new DonationLocationData{ City="Edgewater", State="NJ", ZipCode="07020", AreaCode="201" },
      new DonationLocationData{ City="Hackensack", State="NJ", ZipCode="07601", AreaCode="201" },
      new DonationLocationData{ City="Jersey City", State="NJ", ZipCode="07310", AreaCode="201" },
      new DonationLocationData{ City="Mays Landing", State="NJ", ZipCode="08330", AreaCode="609" },
      new DonationLocationData{ City="Middletown", State="NJ", ZipCode="07748", AreaCode="732" },
      new DonationLocationData{ City="Mount Laurel", State="NJ", ZipCode="08054", AreaCode="856" },
      new DonationLocationData{ City="Paramus", State="NJ", ZipCode="07652", AreaCode="201" },
      new DonationLocationData{ City="Princeton", State="NJ", ZipCode="08540", AreaCode="609" },
      new DonationLocationData{ City="Riverdale", State="NJ", ZipCode="07457", AreaCode="973" },
      new DonationLocationData{ City="Rockaway", State="NJ", ZipCode="07866", AreaCode="973" },
      new DonationLocationData{ City="Albuquerque", State="NM", ZipCode="87112", AreaCode="505" },
      new DonationLocationData{ City="Albuquerque", State="NM", ZipCode="87113", AreaCode="505" },
      new DonationLocationData{ City="Albuquerque", State="NM", ZipCode="87114", AreaCode="505" },
      new DonationLocationData{ City="Albuquerque", State="NM", ZipCode="87110", AreaCode="505" },
      new DonationLocationData{ City="Albuquerque", State="NM", ZipCode="87111", AreaCode="505" },
      new DonationLocationData{ City="Rio Rancho", State="NM", ZipCode="87124", AreaCode="505" },
      new DonationLocationData{ City="Roswell", State="NM", ZipCode="88201", AreaCode="575" },
      new DonationLocationData{ City="Santa Fe", State="NM", ZipCode="87507", AreaCode="505" },
      new DonationLocationData{ City="Amsterdam", State="NY", ZipCode="12010", AreaCode="518" },
      new DonationLocationData{ City="Brooklyn", State="NY", ZipCode="11217", AreaCode="718" },
      new DonationLocationData{ City="Amherst", State="NY", ZipCode="14228", AreaCode="716" },
      new DonationLocationData{ City="Bronx", State="NY", ZipCode="10451", AreaCode="718" },
      new DonationLocationData{ City="Brooklyn", State="NY", ZipCode="11210", AreaCode="718" },
      new DonationLocationData{ City="Syracuse", State="NY", ZipCode="13219", AreaCode="315" },
      new DonationLocationData{ City="Flushing", State="NY", ZipCode="11354", AreaCode="347" },
      new DonationLocationData{ City="Brooklyn", State="NY", ZipCode="11239", AreaCode="718" },
      new DonationLocationData{ City="Schenectady", State="NY", ZipCode="12302", AreaCode="518" },
      new DonationLocationData{ City="Rochester", State="NY", ZipCode="14626", AreaCode="585" },
      new DonationLocationData{ City="New York", State="NY", ZipCode="10035", AreaCode="212" },
      new DonationLocationData{ City="Mount Vernon", State="NY", ZipCode="10550", AreaCode="914" },
      new DonationLocationData{ City="Schenectady", State="NY", ZipCode="12304", AreaCode="518" },
      new DonationLocationData{ City="Buffalo", State="NY", ZipCode="14216", AreaCode="716" },
      new DonationLocationData{ City="Bronx", State="NY", ZipCode="10463", AreaCode="718" },
      new DonationLocationData{ City="Riverhead", State="NY", ZipCode="11901", AreaCode="631" },
      new DonationLocationData{ City="White Plains", State="NY", ZipCode="10601", AreaCode="914" },
      new DonationLocationData{ City="Asheville", State="NC", ZipCode="28805", AreaCode="828" },
      new DonationLocationData{ City="Cary", State="NC", ZipCode="27518", AreaCode="919" },
      new DonationLocationData{ City="Cary", State="NC", ZipCode="27519", AreaCode="919" },
      new DonationLocationData{ City="Charlotte", State="NC", ZipCode="28227", AreaCode="704" },
      new DonationLocationData{ City="Charlotte", State="NC", ZipCode="28277", AreaCode="704" },
      new DonationLocationData{ City="Charlotte", State="NC", ZipCode="28204", AreaCode="704" },
      new DonationLocationData{ City="Charlotte", State="NC", ZipCode="28216", AreaCode="704" },
      new DonationLocationData{ City="Durham", State="NC", ZipCode="27713", AreaCode="919" },
      new DonationLocationData{ City="Durham", State="NC", ZipCode="27707", AreaCode="919" },
      new DonationLocationData{ City="Greensboro", State="NC", ZipCode="27408", AreaCode="336" },
      new DonationLocationData{ City="Greensboro", State="NC", ZipCode="27407", AreaCode="336" },
      new DonationLocationData{ City="Greensboro", State="NC", ZipCode="27410", AreaCode="336" },
      new DonationLocationData{ City="Greenville", State="NC", ZipCode="27834", AreaCode="252" },
      new DonationLocationData{ City="Hickory", State="NC", ZipCode="28602", AreaCode="828" },
      new DonationLocationData{ City="Monroe", State="NC", ZipCode="28110", AreaCode="704" },
      new DonationLocationData{ City="Raleigh", State="NC", ZipCode="27609", AreaCode="919" },
      new DonationLocationData{ City="Raleigh", State="NC", ZipCode="27613", AreaCode="919" },
      new DonationLocationData{ City="Raleigh", State="NC", ZipCode="27616", AreaCode="919" },
      new DonationLocationData{ City="Raleigh", State="NC", ZipCode="27617", AreaCode="919" },
      new DonationLocationData{ City="Wake Forest", State="NC", ZipCode="27587", AreaCode="919" },
      new DonationLocationData{ City="Winston Salem", State="NC", ZipCode="27105", AreaCode="336" },
      new DonationLocationData{ City="Winston Salem", State="NC", ZipCode="27103", AreaCode="336" },
      new DonationLocationData{ City="Amherst", State="OH", ZipCode="44001", AreaCode="440" },
      new DonationLocationData{ City="Beavercreek", State="OH", ZipCode="45431", AreaCode="937" },
      new DonationLocationData{ City="Cincinnati", State="OH", ZipCode="45255", AreaCode="513" },
      new DonationLocationData{ City="Cincinnati", State="OH", ZipCode="45209", AreaCode="513" },
      new DonationLocationData{ City="Cleveland", State="OH", ZipCode="44109", AreaCode="216" },
      new DonationLocationData{ City="Cleveland", State="OH", ZipCode="44111", AreaCode="216" },
      new DonationLocationData{ City="Cincinnati", State="OH", ZipCode="45251", AreaCode="513" },
      new DonationLocationData{ City="Columbus", State="OH", ZipCode="43212", AreaCode="614" },
      new DonationLocationData{ City="Columbus", State="OH", ZipCode="43219", AreaCode="614" },
      new DonationLocationData{ City="Akron", State="OH", ZipCode="44312", AreaCode="330" },
      new DonationLocationData{ City="Columbus", State="OH", ZipCode="43240", AreaCode="614" },
      new DonationLocationData{ City="Dayton", State="OH", ZipCode="45440", AreaCode="937" },
      new DonationLocationData{ City="Toledo", State="OH", ZipCode="43612", AreaCode="419" },
      new DonationLocationData{ City="Toledo", State="OH", ZipCode="43623", AreaCode="419" },
      new DonationLocationData{ City="Albany", State="OR", ZipCode="97322", AreaCode="541" },
      new DonationLocationData{ City="Beaverton", State="OR", ZipCode="97005", AreaCode="503" },
      new DonationLocationData{ City="Bend", State="OR", ZipCode="97701", AreaCode="541" },
      new DonationLocationData{ City="Eugene", State="OR", ZipCode="97402", AreaCode="541" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97216", AreaCode="503" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97205", AreaCode="503" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97220", AreaCode="971" },
      new DonationLocationData{ City="Portland", State="OR", ZipCode="97217", AreaCode="503" },
      new DonationLocationData{ City="Salem", State="OR", ZipCode="97301", AreaCode="503" },
      new DonationLocationData{ City="Springfield", State="OR", ZipCode="97477", AreaCode="541" },
      new DonationLocationData{ City="Beaverton", State="OR", ZipCode="97006", AreaCode="503" },
      new DonationLocationData{ City="Allentown", State="PA", ZipCode="18104", AreaCode="610" },
      new DonationLocationData{ City="Altoona", State="PA", ZipCode="16601", AreaCode="814" },
      new DonationLocationData{ City="Philadelphia", State="PA", ZipCode="19150", AreaCode="267" },
      new DonationLocationData{ City="Glen Mills", State="PA", ZipCode="19342", AreaCode="610" },
      new DonationLocationData{ City="Erie", State="PA", ZipCode="16509", AreaCode="814" },
      new DonationLocationData{ City="Reading", State="PA", ZipCode="19606", AreaCode="484" },
      new DonationLocationData{ City="Allentown", State="PA", ZipCode="18109", AreaCode="610" },
      new DonationLocationData{ City="Pittsburgh", State="PA", ZipCode="15238", AreaCode="412" },
      new DonationLocationData{ City="Harrisburg", State="PA", ZipCode="17111", AreaCode="717" },
      new DonationLocationData{ City="Harrisburg", State="PA", ZipCode="17112", AreaCode="717" },
      new DonationLocationData{ City="Lancaster", State="PA", ZipCode="17602", AreaCode="717" },
      new DonationLocationData{ City="Philadelphia", State="PA", ZipCode="19134", AreaCode="215" },
      new DonationLocationData{ City="Philadelphia", State="PA", ZipCode="19152", AreaCode="267" },
      new DonationLocationData{ City="Philadelphia", State="PA", ZipCode="19116", AreaCode="215" },
      new DonationLocationData{ City="Philadelphia", State="PA", ZipCode="19148", AreaCode="215" },
      new DonationLocationData{ City="Philadelphia", State="PA", ZipCode="19131", AreaCode="267" },
      new DonationLocationData{ City="Pottstown", State="PA", ZipCode="19464", AreaCode="484" },
      new DonationLocationData{ City="Lincoln", State="RI", ZipCode="02865", AreaCode="401" },
      new DonationLocationData{ City="Smithfield", State="RI", ZipCode="02917", AreaCode="401" },
      new DonationLocationData{ City="Warwick", State="RI", ZipCode="02886", AreaCode="401" },
      new DonationLocationData{ City="Warwick", State="RI", ZipCode="02886", AreaCode="401" },
      new DonationLocationData{ City="Aiken", State="SC", ZipCode="29803", AreaCode="803" },
      new DonationLocationData{ City="Charleston", State="SC", ZipCode="29407", AreaCode="843" },
      new DonationLocationData{ City="Columbia", State="SC", ZipCode="29209", AreaCode="803" },
      new DonationLocationData{ City="Columbia", State="SC", ZipCode="29229", AreaCode="803" },
      new DonationLocationData{ City="Columbia", State="SC", ZipCode="29212", AreaCode="803" },
      new DonationLocationData{ City="Florence", State="SC", ZipCode="29501", AreaCode="843" },
      new DonationLocationData{ City="Myrtle Beach", State="SC", ZipCode="29577", AreaCode="843" },
      new DonationLocationData{ City="Myrtle Beach", State="SC", ZipCode="29588", AreaCode="843" },
      new DonationLocationData{ City="Brentwood", State="TN", ZipCode="37027", AreaCode="615" },
      new DonationLocationData{ City="Chattanooga", State="TN", ZipCode="37421", AreaCode="423" },
      new DonationLocationData{ City="Clarksville", State="TN", ZipCode="37040", AreaCode="931" },
      new DonationLocationData{ City="Knoxville", State="TN", ZipCode="37934", AreaCode="865" },
      new DonationLocationData{ City="Knoxville", State="TN", ZipCode="37912", AreaCode="865" },
      new DonationLocationData{ City="Knoxville", State="TN", ZipCode="37918", AreaCode="865" },
      new DonationLocationData{ City="Knoxville", State="TN", ZipCode="37922", AreaCode="865" },
      new DonationLocationData{ City="Knoxville", State="TN", ZipCode="37919", AreaCode="865" },
      new DonationLocationData{ City="Maryville", State="TN", ZipCode="37801", AreaCode="865" },
      new DonationLocationData{ City="Memphis", State="TN", ZipCode="38117", AreaCode="901" },
      new DonationLocationData{ City="Memphis", State="TN", ZipCode="38119", AreaCode="901" },
      new DonationLocationData{ City="Memphis", State="TN", ZipCode="38133", AreaCode="901" },
      new DonationLocationData{ City="Memphis", State="TN", ZipCode="38125", AreaCode="901" },
      new DonationLocationData{ City="Murfreesboro", State="TN", ZipCode="37129", AreaCode="615" },
      new DonationLocationData{ City="Nashville", State="TN", ZipCode="37214", AreaCode="615" },
      new DonationLocationData{ City="Nashville", State="TN", ZipCode="37209", AreaCode="615" },
      new DonationLocationData{ City="Nashville", State="TN", ZipCode="37205", AreaCode="615" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78209", AreaCode="210" },
      new DonationLocationData{ City="Amarillo", State="TX", ZipCode="79121", AreaCode="806" },
      new DonationLocationData{ City="Arlington", State="TX", ZipCode="76015", AreaCode="817" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78759", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78723", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78753", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78717", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78758", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78749", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78704", AreaCode="512" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78748", AreaCode="512" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78232", AreaCode="210" },
      new DonationLocationData{ City="Dallas", State="TX", ZipCode="75204", AreaCode="214" },
      new DonationLocationData{ City="Fort Worth", State="TX", ZipCode="76132", AreaCode="817" },
      new DonationLocationData{ City="Dallas", State="TX", ZipCode="75231", AreaCode="214" },
      new DonationLocationData{ City="Dallas", State="TX", ZipCode="75237", AreaCode="469" },
      new DonationLocationData{ City="Fort Worth", State="TX", ZipCode="76120", AreaCode="817" },
      new DonationLocationData{ City="El Paso", State="TX", ZipCode="79925", AreaCode="915" },
      new DonationLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new DonationLocationData{ City="El Paso", State="TX", ZipCode="79936", AreaCode="915" },
      new DonationLocationData{ City="El Paso", State="TX", ZipCode="79912", AreaCode="915" },
      new DonationLocationData{ City="Austin", State="TX", ZipCode="78730", AreaCode="512" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77007", AreaCode="713" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77082", AreaCode="281" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77024", AreaCode="713" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77096", AreaCode="713" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77040", AreaCode="713" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77025", AreaCode="713" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77094", AreaCode="281" },
      new DonationLocationData{ City="Dallas", State="TX", ZipCode="75220", AreaCode="214" },
      new DonationLocationData{ City="Lubbock", State="TX", ZipCode="79423", AreaCode="806" },
      new DonationLocationData{ City="Lubbock", State="TX", ZipCode="79407", AreaCode="806" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78253", AreaCode="210" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78244", AreaCode="210" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78258", AreaCode="210" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78223", AreaCode="210" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78250", AreaCode="210" },
      new DonationLocationData{ City="San Antonio", State="TX", ZipCode="78245", AreaCode="210" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77042", AreaCode="713" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77063", AreaCode="713" },
      new DonationLocationData{ City="Houston", State="TX", ZipCode="77069", AreaCode="281" },
      new DonationLocationData{ City="Salt Lake City", State="UT", ZipCode="84121", AreaCode="801" },
      new DonationLocationData{ City="Layton", State="UT", ZipCode="84041", AreaCode="801" },
      new DonationLocationData{ City="Riverdale", State="UT", ZipCode="84405", AreaCode="801" },
      new DonationLocationData{ City="Salt Lake City", State="UT", ZipCode="84101", AreaCode="801" },
      new DonationLocationData{ City="Charlottesville", State="VA", ZipCode="22911", AreaCode="434" },
      new DonationLocationData{ City="Chesapeake", State="VA", ZipCode="23320", AreaCode="757" },
      new DonationLocationData{ City="Chesapeake", State="VA", ZipCode="23322", AreaCode="757" },
      new DonationLocationData{ City="Chesapeake", State="VA", ZipCode="23321", AreaCode="757" },
      new DonationLocationData{ City="Richmond", State="VA", ZipCode="23225", AreaCode="804" },
      new DonationLocationData{ City="Fredericksburg", State="VA", ZipCode="22401", AreaCode="540" },
      new DonationLocationData{ City="Fredericksburg", State="VA", ZipCode="22407", AreaCode="540" },
      new DonationLocationData{ City="Richmond", State="VA", ZipCode="23230", AreaCode="804" },
      new DonationLocationData{ City="Richmond", State="VA", ZipCode="23231", AreaCode="804" },
      new DonationLocationData{ City="Virginia Beach", State="VA", ZipCode="23451", AreaCode="757" },
      new DonationLocationData{ City="Virginia Beach", State="VA", ZipCode="23462", AreaCode="757" },
      new DonationLocationData{ City="Virginia Beach", State="VA", ZipCode="23454", AreaCode="757" },
      new DonationLocationData{ City="Virginia Beach", State="VA", ZipCode="23453", AreaCode="757" },
      new DonationLocationData{ City="Glen Allen", State="VA", ZipCode="23059", AreaCode="804" },
      new DonationLocationData{ City="Williamsburg", State="VA", ZipCode="23185", AreaCode="757" },
      new DonationLocationData{ City="Williamsburg", State="VA", ZipCode="23188", AreaCode="757" },
      new DonationLocationData{ City="Winchester", State="VA", ZipCode="22603", AreaCode="540" },
      new DonationLocationData{ City="Bellevue", State="WA", ZipCode="98006", AreaCode="425" },
      new DonationLocationData{ City="Issaquah", State="WA", ZipCode="98027", AreaCode="425" },
      new DonationLocationData{ City="Spokane", State="WA", ZipCode="99218", AreaCode="509" },
      new DonationLocationData{ City="Seattle", State="WA", ZipCode="98125", AreaCode="206" },
      new DonationLocationData{ City="Redmond", State="WA", ZipCode="98052", AreaCode="425" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98684", AreaCode="360" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98665", AreaCode="360" },
      new DonationLocationData{ City="Vancouver", State="WA", ZipCode="98662", AreaCode="360" },
      new DonationLocationData{ City="Seattle", State="WA", ZipCode="98126", AreaCode="206" }
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

    private static double[] DonationAounts = new double[] {
      100, 100, 125, 150, 200, 200, 200
    };


    #endregion

    private static Random WingtipRandom = new Random(Guid.NewGuid().GetHashCode());

    // Methods

    private static int DonationGrowthPhase = 1;

    public static void SetDonationGrowthPhase(int value) {
      DonationGrowthPhase = value;
    } 

    public static IEnumerable<DonationData> GetDonationList() {
      return GetDonationList(10);
    }

    public static IEnumerable<DonationData> GetDonationList(int DonationCount) {
      return GetDonationList(DonationCount, false);
    }

    public static IEnumerable<DonationData> GetDonationList(int DonationCount, bool Predictable) {
      if (Predictable) {
        WingtipRandom = new Random(1962);
      }
      else {
        WingtipRandom = new Random(Guid.NewGuid().GetHashCode());
      }
      List<DonationData> list = new List<DonationData>(DonationCount);
      for (int i = 1; i <= DonationCount; i++) {
        list.Add(GetNextDonation());
      }
      return list;
    }

    public static IEnumerable<DonationData> GetDonationList(int DonationCount, int Seed) {
      WingtipRandom = new Random(Seed);
      List<DonationData> list = new List<DonationData>(DonationCount);
      for (int i = 1; i <= DonationCount; i++) {
        list.Add(GetNextDonation());
      }
      return list;
    }

    private static DonationLocationData GetNextDonationLocation() {

      DonationLocationData[] donarLocations;

      switch (DonationGrowthPhase) {
        case 1:
          donarLocations = DonationLocations;
          break;
        case 2:
          donarLocations = DonationLocations2;
          break;
        default:
          donarLocations = DonationLocations3;
          break;
      }
      int index = WingtipRandom.Next(0, donarLocations.Length);
      return donarLocations[index];
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

    private static double GetNextContributionAmount() {
      int index = WingtipRandom.Next(0, DonationAounts.Length);
      return DonationAounts[index];
    }

  }

}
