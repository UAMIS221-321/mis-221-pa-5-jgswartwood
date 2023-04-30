namespace mis_221_pa_5_jgswartwood
{
    public class Menu
    {

            
        private int userChoice;

        public Menu(){
            
        }


        public int GetUserChoice(){
            return userChoice;
        }

        public void SetUserChoice(int userChoice){
            this.userChoice = userChoice;
        }     

        public void Invalid(){

            System.Console.WriteLine("Invalid Selection, please try again");
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        
    }
}