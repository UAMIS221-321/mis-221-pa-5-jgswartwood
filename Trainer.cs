namespace mis_221_pa_5_jgswartwood
{
    public class Trainer
    {
        private int trainerID;

        private string name;

        private string address;

        private string email;

        static private int maxID;

        static private int count;
        
        public Trainer(){

        }
        
        public Trainer(int trainerID, string name, string address, string email){
            this.trainerID = trainerID;
            this.name = name;
            this.address = address;
            this.email = email;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public string GetName(){
            return name;
        }

        public void SetName(string name){
            this.name = name;
        }

        public string GetAddress(){
            return address;
        }

        public void SetAddress(string address){
            this.address = address;
        }

        public string GetEmail(){
            return email;
        }

        public void SetEmail(string email){
            this.email = email;
        }

        static public void SetMaxID(int maxID){
            Trainer.maxID = maxID;
        }

        static public int GetMaxID(){
            return Trainer.maxID;
        }

        static public void IncCount(){
            Trainer.count++;
        }
        
        static public void DecCount(){
            Trainer.count--;
        }

        static public int GetCount(){
            return Trainer.count;
        }

        static public void SetCount(int count){
            Trainer.count = count;
        }

        public override string ToString(){
            return $"Trainer ID: {trainerID}\nTrainer Name: {name}\nTrainer Mailing Address: {address}\nTrainer E-mail: {email}";
        }

        public string ToFile()
        {
            return $"{trainerID}#{name}#{address}#{email}";
        }
    }
}