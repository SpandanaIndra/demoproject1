namespace CurrentBill.Models
{
    public class BillModel
    {

        //   9.Electricity Bill(Model1)

        // Meter No:	1001

        // Customer Name: Ram
        // Previous Reading: 500

        // Current Reading : 700

        // Billed Units : ?   (cr - pr)

        // Unit Price : 2

        // Bill Amount : ?  (units * price)

        //  Surcharge: 2 %
        // NetBill : bill amount +surcharge

        public int MeterNo { get; set; }
        public string Name { get; set; }
        public int prevReading { get; set; }
        public int currReading { get; set; }
        public int billedUnits { get; set; }

        public double unitPrice { get; set; }
        public double billAmount { get; set; }
        public double surcharge { get; set; }
        public double netBill { get; set; }






    }
}
