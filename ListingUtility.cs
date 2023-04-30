namespace mis_221_pa_5_jgswartwood
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings){
            this.listings = listings;
        }

        public void SetMaxListingID(){
            int max = listings[0].GetListingID();

            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetListingID() > max){
                    max = listings[i].GetListingID();
                }
            }
            Listing.SetMaxID(max);
        }

        public void GetAllListingsFromFile(){
            StreamReader inFile = new StreamReader("listings.txt");
            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split("#");
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), bool.Parse(temp[5]));
                line = inFile.ReadLine();
                Listing.IncCount();
            }
            
            SetMaxListingID();

            inFile.Close();
        }

        private int NewListingID(){
            int num = Listing.GetMaxID();
            num++;
            return num;
        }

        private void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();
        }

        public void AddListing(){
            Listing newListing = new Listing();
            newListing.SetListingID(NewListingID());
            System.Console.WriteLine("New Listing ID is: " + newListing.GetListingID());

            System.Console.WriteLine("Enter trainer name");
            newListing.SetTrainerName(Console.ReadLine());

            System.Console.WriteLine("Enter new listing date");
            newListing.SetSessionDate(Console.ReadLine());

            System.Console.WriteLine("Enter new listing time");
            newListing.SetSessionTime(Console.ReadLine());

            System.Console.WriteLine("Enter new listing cost");
            newListing.SetCost(double.Parse(Console.ReadLine()));

            newListing.Taken();

            listings[Listing.GetCount()] = newListing;
            Listing.IncCount();

            SetMaxListingID();

            Save();   

            GetAllListingsFromFile();         
        }

        public void EditAction(){
            DisplayEditMenu();

            string userInput = Console.ReadLine();
            while(userInput != "7"){
                if(userInput == "1"){
                    EditID();
                }
                else if(userInput == "2"){
                    EditTrainerName();
                }
                else if(userInput == "3"){
                    EditDate();
                }
                else if(userInput == "4"){
                    EditTime();
                }
                else if(userInput == "5"){
                    EditCost();
                }
                else if(userInput == "6"){
                    EditTaken();
                }
                else if(userInput != "7"){
                    Invalid();
                }
                Save();
                GetAllListingsFromFile();
                
                DisplayEditMenu();
                userInput = Console.ReadLine();
            }
        }

        private void DisplayEditMenu(){
            Console.Clear();
            System.Console.WriteLine("Press 1 to edit Listing ID\nPress 2 to edit trainer name\nPress 3 to edit date\nPress 4 to edit time\nPress 5 to edit cost\nPress 6 to edit taken\nPress 7 to return to listing menu");

        }
        private void Invalid(){
            System.Console.WriteLine("Invalid Selection, please try again");
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void EditID(){
            System.Console.WriteLine("Please enter the ID of the listing you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Listing not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to update the ID to?");
                int newID = int.Parse(Console.ReadLine());
                int checkValid = SearchID(newID);
                    if(checkValid == -1){
                        listings[id].SetListingID(newID);
                    }   
                    else{
                        System.Console.WriteLine("Invalid ID. ID already taken");
                        PauseAction();
                    }            
            }

        }

        private void EditTrainerName(){
            System.Console.WriteLine("Please enter the ID of the listing you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Listing not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to change the name to?");
                listings[id].SetTrainerName(Console.ReadLine());
            }

        }

        private void EditDate(){
            System.Console.WriteLine("Please enter the ID of the listing you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Listing not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to change the date to?");
                listings[id].SetSessionDate(Console.ReadLine());
            }
        }

        private void EditTime(){
            System.Console.WriteLine("Please enter the ID of the listing you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Listing not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to time the name to?");
                listings[id].SetSessionTime(Console.ReadLine());
            }

        }

        private void EditCost(){
            System.Console.WriteLine("Please enter the ID of the listing you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Listing not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to change the cost to?");
                listings[id].SetCost(int.Parse(Console.ReadLine()));
            }

        }

        private void EditTaken(){
            System.Console.WriteLine("Please enter the ID of the listing you would like to change status");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Listing not found");
                PauseAction();
            }
            else{
                listings[id].Taken();
                System.Console.WriteLine("Status changed!");
                PauseAction();
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

        private void PauseAction(){
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DeleteListing(){
            System.Console.WriteLine("Enter the ID of the listing you would like to delete: ");
            int id = int.Parse(Console.ReadLine());
            int num = SearchID(id);
            if(num == -1){
                System.Console.WriteLine("Error: Listing not found!");
            }
            else{
                Listing.DecCount();
                StreamWriter outFile = new StreamWriter("listings.txt");

                for(int i = 0; i < Listing.GetCount(); i++){
                    if(listings[i].GetListingID() != id){
                        outFile.WriteLine(listings[i].ToFile());
                    }
                }
                outFile.Close();
                GetAllListingsFromFile();

                System.Console.WriteLine("Listing Deleted!");
                PauseAction();

            }
        }
    }
}