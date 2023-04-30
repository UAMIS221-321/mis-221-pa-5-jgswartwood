/* -----EXTRAS--------
Customers can leave reviews on trainers
Customers can view reviews left on individual trainers
Test logs
*/

//everytime program runs it will read in all trainers from file to start, 
//then static count will be good to use
//also need to find max id everytime program runs, might be different than count if a trainer has been deleted
//might need to initilize count to 0

//might be able to use menu class everytime i need to run a menu
//could add seperate displays to menu utility

//pass trainers + trainer utility into trainer menu
//pass all sub menus into main menu

//transaction file will start blank and be filled as transactions are made


using mis_221_pa_5_jgswartwood;

Menu myMenu = new Menu();

Trainer[] trainers = new Trainer[50];
TrainerUtility utility = new TrainerUtility(trainers);

Listing[] listings = new Listing[50];
ListingUtility listingUtility = new ListingUtility(listings);

Booking[] bookings = new Booking[50];
BookingUtility bookingUtility = new BookingUtility(bookings, listings, trainers);

CustomerReviews[] reviews = new CustomerReviews[50];
ReviewUtility reviewUtility = new ReviewUtility(reviews);

Report report = new Report(bookings, listings);

MenuTrainer menuTrainer = new MenuTrainer(myMenu);
MenuListing menuListing = new MenuListing(myMenu);
MenuBooking menuBooking = new MenuBooking(myMenu);
MenuReport menuReport = new MenuReport(myMenu);
MenuReview menuReview = new MenuReview(myMenu);

MenuMain mainMenu = new MenuMain(myMenu);

utility.GetAllTrainersFromFile();
listingUtility.GetAllListingsFromFile();

mainMenu.DisplayMenu();
int userChoice = myMenu.GetUserChoice();
while(userChoice != 6){
    
    if(userChoice == 1){
        menuTrainer.DisplayMenu();
        userChoice = myMenu.GetUserChoice();

        while(userChoice != 4){
            if(userChoice == 1){
                utility.AddTrainer();
            }
            else if(userChoice == 2){
                utility.EditAction();
            }
            else if(userChoice == 3){
                utility.DeleteTrainer();
            }
            else if(userChoice != 4){
                myMenu.Invalid();
            }
            menuTrainer.DisplayMenu();
            userChoice = myMenu.GetUserChoice();
        }
    }
    else if(userChoice == 2){
        menuListing.DisplayMenu();
        userChoice = myMenu.GetUserChoice();

        while(userChoice != 4){
            if(userChoice == 1){
                listingUtility.AddListing();
            }
            else if(userChoice == 2){
                listingUtility.EditAction();
            }
            else if(userChoice == 3){
                listingUtility.DeleteListing();
            }
            else if(userChoice != 4){
                myMenu.Invalid();
            }
            menuListing.DisplayMenu();
            userChoice = myMenu.GetUserChoice();
        }

    }
    else if(userChoice == 3){
        menuBooking.DisplayMenu();
        userChoice = myMenu.GetUserChoice();

        while(userChoice != 4){
            if(userChoice == 1){
                bookingUtility.SeeAvailableListings();
            }
            else if(userChoice == 2){
                bookingUtility.BookSession();
            }
            else if(userChoice == 3){
                bookingUtility.ConfirmOrCancel();
            }
            else if(userChoice != 4){
                myMenu.Invalid();
            }
            menuBooking.DisplayMenu();
            userChoice = myMenu.GetUserChoice();
        }

    }
    else if(userChoice == 4){
        menuReport.DisplayMenu();
        userChoice = myMenu.GetUserChoice();

        while(userChoice != 4){
            if(userChoice == 1){
                report.ShowIndividual();
            }
            else if(userChoice == 2){
                report.ShowAll();
            }
            else if(userChoice == 3){
                report.ShowRevenue();
            }
            else if(userChoice != 4){
                myMenu.Invalid();
            }
            menuReport.DisplayMenu();
            userChoice = myMenu.GetUserChoice();
        }

    }
    else if(userChoice == 5){
        menuReview.DisplayMenu();
        userChoice = myMenu.GetUserChoice();

        while(userChoice != 3){
            if(userChoice == 1){
                reviewUtility.GetReview();
            }
            else if(userChoice == 2){
                reviewUtility.ShowReviews();
            }
            else if(userChoice != 3){
                myMenu.Invalid();
            } 
            menuReview.DisplayMenu();
            userChoice = myMenu.GetUserChoice();
        }
    }
    else if(userChoice != 6){
        myMenu.Invalid();
    }
    mainMenu.DisplayMenu();
    userChoice = myMenu.GetUserChoice();
}





/*TRAINER
holds all trainer info
can be updated, edited, or deleted
*/

/*LISTING
holds all listing
can be updated, edited, or deleted
listing example on Listing.cs
*/

/*BOOKING
holds all booking data in file called transactions
Views listing that are not taken(taken or not is an attribute of Listing.cs)
Can book a listing(changes listing to taken, hold customer and trainer data in booking class??)
Can mark listing as completed or canceled
*/

/*REPORT
list specific customer listings--just need to search text files for completed bookings
list all customer listings
historical revenue -- search text file for completed bookings and get cost from listings
*/
