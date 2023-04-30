namespace mis_221_pa_5_jgswartwood
{
    public class MenuReview
    {
        private Menu myMenu;

        public MenuReview(Menu myMenu){
            this.myMenu = myMenu;
        }
        public void DisplayMenu(){
            Console.Clear();
            System.Console.WriteLine("Press 1 to leave a review\nPress 2 see a review\nPress 3 to return to meun");
            string userChoice = Console.ReadLine();
            if(IsValidChoice(userChoice)){
                myMenu.SetUserChoice(int.Parse(userChoice));
            }
            else{
                myMenu.SetUserChoice(0);
            }          
              
        }

        private bool IsValidChoice(string userInput){
            if(userInput == "1" || userInput == "2" || userInput == "3"){
                return true;
            }
                return false;
        }
    }
}