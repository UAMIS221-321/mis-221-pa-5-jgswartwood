namespace mis_221_pa_5_jgswartwood
{
    public class MenuReport
    {

        private Menu myMenu;

        public MenuReport(Menu myMenu){
            this.myMenu = myMenu;
        }
        public void DisplayMenu(){
            Console.Clear();
            System.Console.WriteLine("Press 1 see customer sessions\nPress 2 see all sessions\nPress 3 to see revenue\nPress 4 to return to main menu");
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