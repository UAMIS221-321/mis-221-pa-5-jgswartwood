namespace mis_221_pa_5_jgswartwood
{
    public class ReviewUtility
    {
        private CustomerReviews[] reviews;

        public ReviewUtility(CustomerReviews[] reviews){
            this.reviews = reviews;
        }

        public void GetReview(){
            CustomerReviews newReview = new CustomerReviews();
            System.Console.WriteLine("Thank you for leaving a review! Please enter your email to continue");
            newReview.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("Enter the ID of the trainer you would like to leave a reveiw on:");
            newReview.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Enter your rating on a scale of 1-5. (1 for worst, 5 for best)");
            newReview.SetRating(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please explain your rating:");
            newReview.SetComments(Console.ReadLine());

            reviews[CustomerReviews.GetCount()] = newReview;
            CustomerReviews.IncCount();  
            Save();          
        }

        public void Save(){
            StreamWriter outFile = new StreamWriter("reviews.txt");

            for(int i = 0; i < CustomerReviews.GetCount(); i++){
                outFile.WriteLine(reviews[i].ToFile());
            }
        }

        public void ShowReviews(){
            System.Console.WriteLine("Enter the id of the trainer you would like to see reviews on:");
            int id = int.Parse(Console.ReadLine());

            for(int i = 0; i < CustomerReviews.GetCount(); i++){
                if(reviews[i].GetTrainerID() == id){
                    reviews[i].ToString();
                }
            }
        }
    }
}