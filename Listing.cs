namespace mis_221_pa_5_jgswartwood
{
    
    public class Listing
    {
        private int listingID;

        private string trainerName;

        private string sessionDate;

        private string sessionTime;

        private double cost;

        private bool isTaken = true;

        static private int maxID;

        static private int count;

        public Listing(){

        }

        public Listing(int listingID, string trainerName, string sessionDate, string sessionTime, double cost, bool isTaken){
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.cost = cost;
            this.isTaken = isTaken;
        }

        public int GetListingID(){
            return listingID;
        }

        public void SetListingID(int listingID){
            this.listingID = listingID;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public string GetSessionDate(){
            return sessionDate;
        }

        public void SetSessionDate(string sessionDate){
            this.sessionDate = sessionDate;
        }

        public string GetSessionTime(){
            return sessionTime;
        }

        public void SetSessionTime(string sessionTime){
            this.sessionTime = sessionTime;
        }

        public double GetCost(){
            return cost;
        }

        public void SetCost(double cost){
            this.cost = cost;
        }

        public void Taken(){
            this.isTaken = !this.isTaken;
        }

        public bool GetTaken(){
            return isTaken;
        }

        static public void SetMaxID(int maxID){
            Listing.maxID = maxID;
        }

        static public int GetMaxID(){
            return Listing.maxID;
        }

        static public void IncCount(){
            Listing.count++;
        }
        
        static public void DecCount(){
            Listing.count--;
        }

        static public int GetCount(){
            return Listing.count;
        }

        static public void SetCount(int count){
            Listing.count = count;
        }

        public string ToFile(){
            return $"{listingID}#{trainerName}#{sessionDate}#{sessionTime}#{cost}#{isTaken}";
        }

        public override string ToString(){
            return $"ID: {listingID}, Trainer: {trainerName}, Date/Time: {sessionDate}/{sessionTime}, Cost: {cost}";
        }



        
    }
}