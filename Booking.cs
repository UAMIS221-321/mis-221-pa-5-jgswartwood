namespace mis_221_pa_5_jgswartwood
{
    public class Booking
    {
        private int sessionID;

        private string customerName;

        private string customerEmail;

        private string date;

        private int trainerID;

        private string trainerName;

        private bool status = false;

        static private int maxID;

        static private int count;

        public Booking(){

        }

        public Booking(int sessionID, string customerName, string customerEmail, string date, int trainerID, string trainerName, bool status){
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.date = date;
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.status = status;
        }

        public int GetSessionID(){
            return sessionID;
        }

        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }

        public string GetCustomerName(){
            return customerName;
        }

        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }

        public string GetCustomerEmail(){
            return customerEmail;
        }

        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }

        public string GetDate(){
            return customerName;
        }

        public void SetDate(string date){
            this.date = date;
        }

        public int GetTrainerID(){
            return trainerID;
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }

        public string GetTrainerName(){
            return trainerName;
        }

        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }

        public void Status(){
            this.status = !this.status;
        }

        static public void SetMaxID(int maxID){
            Booking.maxID = maxID;
        }

        static public int GetMaxID(){
            return Booking.maxID;
        }

        static public void IncCount(){
            Booking.count++;
        }
        
        static public void DecCount(){
            Booking.count--;
        }

        static public int GetCount(){
            return Booking.count;
        }

        static public void SetCount(int count){
            Booking.count = count;
        }

        public string ToFile(){
            return $"{sessionID}#{customerName}#{customerEmail}#{date}#{trainerID}#{trainerName}#{status}";
        }

    }
}