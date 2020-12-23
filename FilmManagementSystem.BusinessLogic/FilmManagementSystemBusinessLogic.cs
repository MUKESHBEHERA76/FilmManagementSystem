using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using FilmManagementSystem.DataAccess;
using FilmManagementSystem.Entity;
using FilmManagementSystem.Exception;
using System.Text.RegularExpressions;

namespace FilmManagementSystem.BusinessLogic
{
    public class FilmManagementSystemBusinessLogic
    {
        FilmManagementSystemDataAccess dataAcces = new FilmManagementSystemDataAccess();

        public bool CheckFilmInfo(FilmManagementSystemEntity validate)

        {

            bool isCorrect = false;

            try
            {
                string regex = @"(^[a-zA-Z])";

                Regex re = new Regex(regex);

                if (re.IsMatch(validate.FilmActor) &&

                  (validate.FilmCategory.Equals("Horror") || validate.FilmCategory.Equals("Adventure") || validate.FilmCategory.Equals("Action") || validate.FilmCategory.Equals("Romantic")) &&

                  (validate.FilmLanguage.Equals("English") || validate.FilmLanguage.Equals("Hindi") || validate.FilmLanguage.Equals("Marathi") || validate.FilmLanguage.Equals("Odia")) &&

                   re.IsMatch(validate.FilmDescription) &&

                   (validate.FilmReleaseYear <= 2020 && validate.FilmReleaseYear > 1970) &&

                   (validate.FilmRentalDuration <= 30 && validate.FilmRentalDuration >= 1) &&

                   (validate.FilmRentalRate <= 400 && validate.FilmRentalRate >= 300) &&

                   (validate.FilmLength <= 5 && validate.FilmLength >= 1) &&

                   (validate.FilmReplacementCost <= 200 && validate.FilmReplacementCost >= 150) &&

                   (validate.FilmRating <= 10 && validate.FilmRating >= 1))

                {

                    isCorrect = true;

                }

            }

            catch (FilmManagementSystemException exception)

            {

                Console.WriteLine(exception.Message);

            }

            return isCorrect;

        }

        public bool CheckFilmTittle(FilmManagementSystemEntity filmManagementSystem)

        {

            bool isCorrect = false;

            try

            {

                if (dataAcces.VarifyFilmTittle(filmManagementSystem.FilmTittle).Equals(true))

                {

                    isCorrect = false;

                }

                else

                {

                    isCorrect = true;

                }

            }

            catch (FilmManagementSystemException exception)

            {

                Console.WriteLine(exception.Message);

            }

            catch (System.Exception exception)

            {

                Console.WriteLine(exception.Message);

            }

            return isCorrect;

        }

        public bool ValidateAndAddDetails(FilmManagementSystemEntity filmentity)

        {

            bool isCorrect = true;

            try

            {

                if (CheckFilmInfo(filmentity) && CheckFilmTittle(filmentity))

                {

                    FilmManagementSystemDataAccess.ListSerializer(filmentity);

                }

                else

                {

                    isCorrect = false;

                }

                return isCorrect;

            }

            catch (FilmManagementSystemException exception)

            {

                Console.WriteLine(exception.Message);

            }

            return isCorrect;

        }

        public List<FilmManagementSystemEntity> DisplayAllDetails()

        {

            return FilmManagementSystemDataAccess.ListDeserializer();

        }

        public FilmManagementSystemEntity SearchByTittle(string filmtittle)

        {

            List<FilmManagementSystemEntity> filmdata = FilmManagementSystemDataAccess.ListDeserializer();

            FilmManagementSystemEntity filmdatatittle = filmdata.Find(filmManagementSystem => filmManagementSystem.FilmTittle == filmtittle);

            return filmdatatittle;

        }

        public List<FilmManagementSystemEntity> SearchFilmByActor(string Actor)

        {

            List<FilmManagementSystemEntity> searchActor = FilmManagementSystemDataAccess.ListDeserializer();

            List<FilmManagementSystemEntity> searchactor = searchActor.FindAll(filmManagementSystem => filmManagementSystem.FilmActor == Actor);

            return searchactor;

        }

        public FilmManagementSystemEntity SearchByCatagory(string filmcatagory)

        {

            List<FilmManagementSystemEntity> filmCatagoryData = FilmManagementSystemDataAccess.ListDeserializer();

            FilmManagementSystemEntity filmdataCatagory = filmCatagoryData.Find(filmManagementSystem => filmManagementSystem.FilmCategory == filmcatagory);

            return filmdataCatagory;

        }

        public FilmManagementSystemEntity SearchByLanguage(string filmlanguage)

        {

            List<FilmManagementSystemEntity> filmLanguageData = FilmManagementSystemDataAccess.ListDeserializer();

            FilmManagementSystemEntity filmdataLanguage = filmLanguageData.Find(filmManagementSystem => filmManagementSystem.FilmLanguage == filmlanguage);

            return filmdataLanguage;

        }

        public FilmManagementSystemEntity SearchByRating(int filmrating)

        {

            List<FilmManagementSystemEntity> filmRatingData = FilmManagementSystemDataAccess.ListDeserializer();

            FilmManagementSystemEntity filmdataRating = filmRatingData.Find(filmManagementSystem => filmManagementSystem.FilmRating == filmrating);

            return filmdataRating;

        }
        public bool ModifybyFilmTittle(string tittle, string actor)
        {
            bool isCorrect = false;
            if (dataAcces.ModifyUsingFilmTittle(tittle, actor))
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}
