namespace mis_221_pa_5_jgswartwood
{
    public class Report
    {

        private Booking[] bookings;

        private Listing[] listings;

        public Report(Booking[] bookings, Listing[] listings){
            this.bookings = bookings;
            this.listings = listings;
        }
        public void ShowIndividual(){
            System.Console.WriteLine("What customer would you like to see sessions for?");
            string userInput = Console.ReadLine();
            
            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetCustomerEmail() == userInput){
                    bookings[i].ToString();
                }
            }
            
        }

        public void ShowAll(){
            for(int i = 0; i < Booking.GetCount(); i++){
                    bookings[i].ToString();
            }
        }

        public void ShowRevenue(){
            double num = 0;
            for(int i = 0; i < Booking.GetCount(); i++){
                    num = num + listings[i].GetCost();
            }
            System.Console.WriteLine("Total revenue: $" + num);
        }
    }
}