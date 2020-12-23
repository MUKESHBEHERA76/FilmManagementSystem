using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmManagementSystem.Exception;
using FilmManagementSystem.Entity;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FilmManagementSystem.DataAccess
{
    public class FilmManagementSystemDataAccess
    {
        public static List<FilmManagementSystemEntity> filmManagementSystemEntityList = new List<FilmManagementSystemEntity>();



        public static void ListSerializer(FilmManagementSystemEntity filmdetailAdd)

        {



            //filmManagementSystemEntityList = ListDeserializer();

            filmManagementSystemEntityList.Add(filmdetailAdd);

            string path = @"C:\Users\MUKESH KUMAR BEHERA\Desktop\Film_Management_System\Result.txt";

            BinaryFormatter formatter = new BinaryFormatter();

            Stream stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);

            formatter.Serialize(stream, filmManagementSystemEntityList);

            stream.Close();

        }

        public static List<FilmManagementSystemEntity> ListDeserializer()

        {

            string path = @"C:\Users\MUKESH KUMAR BEHERA\Desktop\Film_Management_System\Result.txt";

            BinaryFormatter formatter = new BinaryFormatter();

            Stream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            List<FilmManagementSystemEntity> entityList = (List<FilmManagementSystemEntity>)formatter.Deserialize(stream);

            stream.Close();

            return entityList;

        }

        public bool VarifyFilmTittle(string tittle)

        {

            bool isCorrect = false;

            List<FilmManagementSystemEntity> filmEntity = (List<FilmManagementSystemEntity>)ListDeserializer();

            FilmManagementSystemEntity entity = new FilmManagementSystemEntity();

            foreach (FilmManagementSystemEntity systemEntity in filmEntity)

            {

                if (systemEntity.FilmTittle == tittle)

                {

                    isCorrect = true;

                }

            }

            return isCorrect;

        }

        public bool ModifyUsingFilmTittle(string Tittle, string Actor)

        {
            List<FilmManagementSystemEntity> SearchIdList =ListDeserializer();

            bool ismodified = false;
            for (int number = 0; number < SearchIdList.Count; number++)
            {
                if (SearchIdList[number].FilmTittle == Tittle)
                {
                    SearchIdList[number].FilmActor = Actor;                 
                    ListSerializer(SearchIdList[number]);
                    ismodified = true;
                    break;
                }
            }
            return ismodified;
        }
    }
}
