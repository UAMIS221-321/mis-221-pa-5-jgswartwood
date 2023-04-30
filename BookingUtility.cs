namespace mis_221_pa_5_jgswartwood
{
    public class BookingUtility
    {
        private Booking[] bookings;
        private Listing[] listings;

        private Trainer[] trainers;

        public BookingUtility(Booking[] bookings, Listing[] listings, Trainer[] trainers){
            this.bookings = bookings;
            this.listings = listings;
            this.trainers = trainers;
        }

        public void SetMaxBookingID(){
            int max = bookings[0].GetSessionID();

            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetSessionID() > max){
                    max = bookings[i].GetSessionID();
                }
            }
            Booking.SetMaxID(max);
        }

        private int NewBookingID(){
            int num = Booking.GetMaxID();
            num++;
            return num;
        }

        public void GetAllBookingsFromFile(){
            StreamReader inFile = new StreamReader("transactions.txt");
            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split("#");
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], int.Parse(temp[4]), temp[5], bool.Parse(temp[6]));
                line = inFile.ReadLine();
                Booking.IncCount();
            }
            
            SetMaxBookingID();

            inFile.Close();
        }

        private void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }

            outFile.Close();
        }

        public void SeeAvailableListings(){
            System.Console.WriteLine("Available Listings:");          
            for(int i = 0; i < Booking.GetCount(); i++){
                if(listings[i].GetTaken() == false){
                    System.Console.WriteLine();
                    listings[i].ToString();
                }                
            }

        } 

        public void BookSession(){
            System.Console.WriteLine("Enter the ID of the session you would like to book");
            int userInput = int.Parse(Console.ReadLine());
            int num = SearchID(userInput);
            if(num == -1){
                System.Console.WriteLine("Invalid ID");
            }
            else{
            Booking newBooking = new Booking();
            newBooking.SetSessionID(userInput);
            System.Console.WriteLine("What is your name:");
            newBooking.SetCustomerName(Console.ReadLine());      
            System.Console.WriteLine("What is your email address:");
            newBooking.SetCustomerEmail(Console.ReadLine());
            
            newBooking.SetDate(listings[num].GetSessionDate());
            newBooking.SetTrainerName(listings[num].GetTrainerName());
            newBooking.SetTrainerID(trainers[num].GetTrainerID());

            bookings[Booking.GetCount()] = newBooking;

            StreamWriter inFile = new StreamWriter("transactions.txt");
            for(int i = 0; i < Booking.GetCount(); i++){
                bookings[i].ToFile();
            }
            inFile.Close(); 
            }

        }

        private int SearchID(int userInput){
            int num = -1;

            for(int i = 0; i < Listing.GetCount(); i++){
                if(userInput == listings[i].GetListingID()){
                    num = i;
                }
            }
            
            return num;
        }

        public void ConfirmOrCancel(){

        }
    }
}