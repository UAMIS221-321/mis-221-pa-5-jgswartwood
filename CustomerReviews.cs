namespace mis_221_pa_5_jgswartwood
{
    public class CustomerReviews
    {
        private int rating;

        private int trainerID;

        private string customerEmail;

        private string comments;

        static private int count = 0;

        public CustomerReviews(){
        
        }

        public void SetRating(int rating){
            this.rating = rating;
        }
        public int GetRating(){
            return rating;
        }

        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public int GetTrainerID(){
            return trainerID;
        }

        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }

        public void SetComments(string comments){
            this.comments = comments;
        }

        public string GetComments(){
            return comments;
        }

        static public void IncCount(){
            CustomerReviews.count++;
        }

        static public int GetCount(){
            return CustomerReviews.count;
        }

        static public void SetCount(int count){
            CustomerReviews.count = count;
        }

        public string ToFile(){
            return $"{customerEmail}#{rating}#{comments}";
        }

        public override string ToString(){
            return $"Trainer: {trainerID} -- {comments} - left by {customerEmail}";
        }

        
    }
}