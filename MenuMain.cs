namespace mis_221_pa_5_jgswartwood
{
    public class MenuMain
    {

        private Menu myMenu;

        public MenuMain(Menu myMenu){
            this.myMenu = myMenu;
        }

        public void DisplayMenu(){
            Console.Clear();
            System.Console.WriteLine("Press 1 to Manage Trainer Data\nPress 2 to Manage Listing Data\nPress 3 to Manage Customer Booking Data\nPress 4 to Run Reports\nPress 5 to leave a review\nPress 6 to Exit");
            string userChoice = Console.ReadLine();
            if(IsValidChoice(userChoice)){
                myMenu.SetUserChoice(int.Parse(userChoice));
            }
            else{
                myMenu.SetUserChoice(0);
            }            
        }

        private bool IsValidChoice(string userInput){
            if(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6"){
                return true;
            }
                return false;
        }

        
    }
}