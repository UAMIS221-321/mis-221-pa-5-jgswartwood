namespace mis_221_pa_5_jgswartwood
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }

        public void SetMaxTrainerID(){
            int max = trainers[0].GetTrainerID();

            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainers[i].GetTrainerID() > max){
                    max = trainers[i].GetTrainerID();
                }
            }
            Trainer.SetMaxID(max);
        }

        public void GetAllTrainersFromFile(){
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null){
                string[] temp = line.Split("#");
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                line = inFile.ReadLine();
                Trainer.IncCount();
            }
            
            SetMaxTrainerID();

            inFile.Close();
        }

        public void AddTrainer(){
            Trainer newTrainer = new Trainer();
            newTrainer.SetTrainerID(NewTrainerID());
            System.Console.WriteLine("New Trainer ID is: " + newTrainer.GetTrainerID());

            System.Console.WriteLine("Enter new trainer name");
            newTrainer.SetName(Console.ReadLine());

            System.Console.WriteLine("Enter new trainer mailing address");
            newTrainer.SetAddress(Console.ReadLine());

            System.Console.WriteLine("Enter new trainer email address");
            newTrainer.SetEmail(Console.ReadLine());

            trainers[Trainer.GetCount()] = newTrainer;
            Trainer.IncCount();

            SetMaxTrainerID();

            Save();  

            GetAllTrainersFromFile();          
        }

        private int NewTrainerID(){
            int num = Trainer.GetMaxID();
            num++;
            return num;
        }

        private void Save(){
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }

        public void EditAction(){
            DisplayEditMenu();

            string userInput = Console.ReadLine();
            while(userInput != "5"){
                if(userInput == "1"){
                    EditID();
                }
                else if(userInput == "2"){
                    EditName();
                }
                else if(userInput == "3"){
                    EditAddress();
                }
                else if(userInput == "4"){
                    EditEmail();
                }
                else if(userInput != "5"){
                    Invalid();
                }
                Save();
                GetAllTrainersFromFile();

                DisplayEditMenu();
                userInput = Console.ReadLine();
            }
        }
        
        private void EditID(){
            System.Console.WriteLine("Please enter the ID of the trainer you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Trainer not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to update the ID to?");
                int newID = int.Parse(Console.ReadLine());
                int checkValid = SearchID(newID);
                    if(checkValid == -1){
                        trainers[id].SetTrainerID(newID);
                    }   
                    else{
                        System.Console.WriteLine("Invalid ID. ID already taken");
                        PauseAction();
                    }            
            }
        }

        private void EditName(){
            System.Console.WriteLine("Please enter the ID of the trainer you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Trainer not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to change the name to?");
                trainers[id].SetName(Console.ReadLine());
            }

            
        }

        private void EditAddress(){
            System.Console.WriteLine("Please enter the ID of the trainer you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Trainer not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to change the address to?");
                trainers[id].SetAddress(Console.ReadLine());
            }
            
        }

        private void EditEmail(){
            System.Console.WriteLine("Please enter the ID of the trainer you would like to edit");
            int userInput = int.Parse(Console.ReadLine());

            int id = SearchID(userInput);
            if(id == -1){
                System.Console.WriteLine("Trainer not found");
                PauseAction();
            }
            else{
                System.Console.WriteLine("What would you like to change the email to?");
                trainers[id].SetEmail(Console.ReadLine());
            }
        }

        public void DeleteTrainer(){
            System.Console.WriteLine("Enter the ID of the trainer you would like to delete: ");
            int id = int.Parse(Console.ReadLine());
            int num = SearchID(id);
            if(num == -1){
                System.Console.WriteLine("Error: Trainer not found!");
            }
            else{
                Trainer.DecCount();
                StreamWriter outFile = new StreamWriter("trainers.txt");

                for(int i = 0; i < Trainer.GetCount(); i++){
                    if(trainers[i].GetTrainerID() != id){
                        outFile.WriteLine(trainers[i].ToFile());
                    }
                }
                outFile.Close();
                GetAllTrainersFromFile();

            }

            System.Console.WriteLine("Trainer Deleted!");
            PauseAction();

        }
        private void DisplayEditMenu(){
            Console.Clear();
            System.Console.WriteLine("Press 1 to edit Trainer ID\nPress 2 to edit trainer name\nPress 3 to edit trainer address\nPress 4 to edit trainer email\nPress 5 to return to Trainer menu");

        }
        private void Invalid(){
            System.Console.WriteLine("Invalid Selection, please try again");
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private int SearchID(int userInput){
            int num = -1;

            for(int i = 0; i < Trainer.GetCount(); i++){
                if(userInput == trainers[i].GetTrainerID()){
                    num = i;
                }
            }
            
            return num;
        }

        private void PauseAction(){
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}