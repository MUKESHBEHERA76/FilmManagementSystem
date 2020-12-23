using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmManagementSystem.Entity;
using FilmManagementSystem.Exception;
using FilmManagementSystem.BusinessLogic;

namespace FilmManagementSystem.Presentation
{
    class FilmManagementSystemPresentation
    {
        public static FilmManagementSystemBusinessLogic filmManagementSystemBusinessLogic = new FilmManagementSystemBusinessLogic();
        static void Main(string[] args)
        {
            Console.WriteLine("******************************************");

            Console.WriteLine("******************************************");

            Console.WriteLine();

            Console.WriteLine(" FILM MANAGEMENT SYSTEM ");

            Console.WriteLine();

            Console.WriteLine("******************************************");

            Console.WriteLine("******************************************");

            Console.WriteLine();

            try

            {

                int choice;

                while (true)



                {

                    Console.WriteLine("1. Create Film (capture film info)");

                    Console.WriteLine("2. Modify Film info");

                    Console.WriteLine("3. Remove Film");

                    Console.WriteLine("4. View all Film (Film summary)");

                    Console.WriteLine("5. Search Film by name");

                    Console.WriteLine("6. Search Film by Actor");

                    Console.WriteLine("7. Search Film by Category");

                    Console.WriteLine("8. Search Film by Language");

                    Console.WriteLine("9. Search Film by Rating");

                    Console.WriteLine("0. Exit");

                    Console.WriteLine();

                    Console.WriteLine("Enter Your Choice");

                    Console.WriteLine();

                    choice = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    switch (choice)

                    {

                        case 1:

                            if (filmManagementSystemBusinessLogic.ValidateAndAddDetails(CreateFilmInformation()))

                            {

                                Console.WriteLine();

                                Console.WriteLine("Film Information Added Succesfully");

                                Console.WriteLine();

                            }

                            else

                            {

                                Console.WriteLine();

                                Console.WriteLine("Error In Adding Film Information !!!");

                                Console.WriteLine();

                            }

                            break;

                        case 2:
                            ModifyFilmDetails();

                            break;

                        case 3:

                            break;

                        case 4:

                            DispalyFilmInformation(filmManagementSystemBusinessLogic.DisplayAllDetails());

                            break;

                        case 5:

                            Console.WriteLine("Enter the Film Tittle that you want to Search");

                            string search = Console.ReadLine();

                            FilmManagementSystemEntity searchTittle = filmManagementSystemBusinessLogic.SearchByTittle(search);

                            if (searchTittle != null)

                            {

                                Console.WriteLine();

                                Console.WriteLine($"{searchTittle.FilmTittle} {searchTittle.FilmActor} {searchTittle.FilmCategory} {searchTittle.FilmDescription} {searchTittle.FilmLanguage} {searchTittle.FilmLength} {searchTittle.FilmRating}");

                                Console.WriteLine();

                            }

                            else

                            {

                                Console.WriteLine();

                                Console.WriteLine($"Film with the specified tittle:{search} not present");

                                Console.WriteLine();

                            }

                            break;

                        case 6:

                            SearchByActor();

                            break;

                        case 7:

                            Console.WriteLine();

                            Console.WriteLine("Enter the name of the Film Catagory You want to search");

                            string catagory = Console.ReadLine();

                            FilmManagementSystemEntity searchCatagory = filmManagementSystemBusinessLogic.SearchByCatagory(catagory);

                            if (searchCatagory != null)

                            {

                                Console.WriteLine();

                                Console.WriteLine($"{searchCatagory.FilmTittle} {searchCatagory.FilmActor} {searchCatagory.FilmCategory} {searchCatagory.FilmDescription} {searchCatagory.FilmLanguage} {searchCatagory.FilmLength} {searchCatagory.FilmRating}");

                                Console.WriteLine();

                            }

                            else

                            {

                                Console.WriteLine();

                                Console.WriteLine($"Film with the specified tittle:{catagory} not present");

                                Console.WriteLine();

                            }

                            break;

                        case 8:

                            Console.WriteLine();

                            Console.WriteLine("Enter the Language of the Film You want to search");

                            string language = Console.ReadLine();

                            FilmManagementSystemEntity searchLanguage = filmManagementSystemBusinessLogic.SearchByLanguage(language);

                            if (searchLanguage != null)

                            {

                                Console.WriteLine();

                                Console.WriteLine($"{searchLanguage.FilmTittle} {searchLanguage.FilmActor} {searchLanguage.FilmCategory} {searchLanguage.FilmDescription} {searchLanguage.FilmLanguage} {searchLanguage.FilmLength} {searchLanguage.FilmRating}");

                                Console.WriteLine();

                            }

                            else

                            {

                                Console.WriteLine();

                                Console.WriteLine($"Film with the specified tittle:{language} not present");

                                Console.WriteLine();

                            }

                            break;

                        case 9:

                            Console.WriteLine();

                            Console.WriteLine("Enter the IMDB rating of the Film You want to search");

                            int rating = Convert.ToInt32(Console.ReadLine());

                            FilmManagementSystemEntity searchRating = filmManagementSystemBusinessLogic.SearchByRating(rating);

                            if (searchRating != null)

                            {

                                Console.WriteLine();

                                Console.WriteLine($"{searchRating.FilmTittle} {searchRating.FilmActor} {searchRating.FilmCategory} {searchRating.FilmDescription} {searchRating.FilmLanguage} {searchRating.FilmLength} {searchRating.FilmRating}");

                                Console.WriteLine();

                            }

                            else

                            {

                                Console.WriteLine();

                                Console.WriteLine($"Film with the specified tittle:{rating} not present");

                                Console.WriteLine();

                            }

                            break;

                        case 0:

                            Environment.Exit(0);

                            break;



                        default:

                            Console.WriteLine("Enter a valid coice");

                            break;

                    }

                }

            }

            catch (FilmManagementSystemException filmException)

            {

                Console.WriteLine(filmException.Message);

            }

            catch (System.Exception e)

            {

                Console.WriteLine(e.Message);

            }

        }

        public static FilmManagementSystemEntity CreateFilmInformation()

        {

            FilmManagementSystemEntity add = new FilmManagementSystemEntity();

            try

            {

                Console.WriteLine("Enter the Film Title(Unique)");

                add.FilmTittle = Console.ReadLine();



                Console.WriteLine("Enter the name of the Film Actor");

                add.FilmActor = Console.ReadLine();



                Console.WriteLine("Enter the Film Catagory(Action/Horror/Romantic/Adventure)");

                add.FilmCategory = Console.ReadLine();



                Console.WriteLine("Enter the Film Language(Hindi/English/Odia/Marathi)");

                add.FilmLanguage = Console.ReadLine();



                Console.WriteLine("Enter the Film description");

                add.FilmDescription = Console.ReadLine();



                Console.WriteLine("Enter the Film Release year(1970-2020)");

                add.FilmReleaseYear = Convert.ToInt32(Console.ReadLine());



                Console.WriteLine("Enter the Film Rental duration(1-30)");

                add.FilmRentalDuration = Convert.ToSingle(Console.ReadLine());



                Console.WriteLine("Enter the Film Rental rate(300-400)");

                add.FilmRentalRate = Convert.ToSingle(Console.ReadLine());



                Console.WriteLine("Enter the Film Length(1-5)");

                add.FilmLength = Convert.ToSingle(Console.ReadLine());



                Console.WriteLine("Enter the Film Replacement cost(150-200)");

                add.FilmReplacementCost = Convert.ToSingle(Console.ReadLine());



                Console.WriteLine("Enter the Film Rating(1/10)");

                add.FilmRating = Convert.ToSingle(Console.ReadLine());

            }

            catch (FilmManagementSystemException filmManagementException)

            {

                Console.WriteLine(filmManagementException.Message);

            }

            catch (System.Exception exception)

            {

                Console.WriteLine(exception.Message);

            }

            return add;

        }

        public static void DispalyFilmInformation(List<FilmManagementSystemEntity> entityObject)

        {

            Console.WriteLine();

            Console.WriteLine("*********************************************************************************");

            Console.WriteLine("FilmTittle" + " " + "FilmActor" + " " + "Release Year" + " " + "Rating" + " " + "Catagory" + " " + "Language");

            Console.WriteLine("**********************************************************************************");

            Console.WriteLine();

            foreach (FilmManagementSystemEntity givelist in entityObject)

            {

                Console.WriteLine($"{givelist.FilmTittle} {givelist.FilmActor} {givelist.FilmReleaseYear} {givelist.FilmRating} {givelist.FilmCategory} {givelist.FilmLanguage}");

                Console.WriteLine("....................................................................");

            }

            Console.WriteLine();

        }

        public static void SearchByActor()

        {

            Console.WriteLine("Enter the film Actor Name you want to search");

            string searchByActor = Console.ReadLine();

            List<FilmManagementSystemEntity> actorDetails = filmManagementSystemBusinessLogic.SearchFilmByActor(searchByActor);

            Console.WriteLine("Tittle" + " " + "Actor" + " " + "Catagory" + " " + "Language" + " " + "Ratings");

            foreach (FilmManagementSystemEntity acceptDetails in actorDetails)

            {

                Console.WriteLine($"{acceptDetails.FilmTittle} {acceptDetails.FilmActor} {acceptDetails.FilmCategory} {acceptDetails.FilmLanguage} {acceptDetails.FilmRating}");

            }
        }
            public static void ModifyFilmDetails()
            {
                Console.WriteLine("Enter the Film Tittle");
                string FilmTittle = Console.ReadLine();
                Console.WriteLine("Enter your Choice that you want to upadte!!!!!!");
                Console.WriteLine();
                Console.WriteLine($"\n 1.Film Actor \n 2.Film Catagory \n 3.Film Language \n 4. Film Rating ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new Film Actor Name : ");
                        string newAcotr = Console.ReadLine();
                        if (filmManagementSystemBusinessLogic.ModifybyFilmTittle(FilmTittle, newAcotr))
                        {
                            Console.WriteLine("Insertion of new Actor is Succesfull");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter new Film Catagory");
                        var catagory = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Emter new Film Language");
                        string Language = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter new phone number");
                        int Rating = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice for updation");
                        break;

                }

            }
        


     }
    
}
