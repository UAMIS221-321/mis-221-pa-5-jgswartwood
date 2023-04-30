namespace mis_221_pa_5_jgswartwood
{
    public class MenuBooking
    {
        private Menu myMenu;

        public MenuBooking(Menu myMenu){
            this.myMenu = myMenu;
        }

        public void DisplayMenu(){
            Console.Clear();
            System.Console.WriteLine("Press 1 to see bookings\nPress 2 to new booking\nPress 3 to confirm or cancel\nPress 4 to return to main menu");
            string userChoice = Console.ReadLine();
            if(IsValidChoice(userChoice)){
                myMenu.SetUserChoice(int.Parse(userChoice));
            }
            else{
                myMenu.SetUserChoice(0);
            }          
              
        }

        private bool IsValidChoice(string userInput){
            if(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4"){
                return true;
            }
                return false;
        }
    }
}