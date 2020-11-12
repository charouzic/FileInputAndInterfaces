using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileInputInterfaces
{
    public class Processor
    {
        public string PathToFile {
            get {
                return "/users/viki/desktop/c#/";
            }
        }

        public int CountFilmsByAwardStatus(bool awardStatus, List<FilmInfo> infos)
        {

            int totalFilms = 0;
            foreach(FilmInfo info in infos)
            {
                if(info.Awards == awardStatus)
                {
                    totalFilms++;
                }
            }

            return totalFilms;
        }

        
        public List<string> CountOfFilmsForEachSubject(List<FilmInfo> infos)
        {

            List<string> FilmSubjects = new List<string>();

            foreach (FilmInfo info in infos)
            {
                FilmSubjects.Add(info.Subject);
            }

            List<string> distinctValues = new List<string>();
            foreach (FilmInfo info in infos)
            {
                if(!distinctValues.Contains(info.Subject) && info.Subject.Length >= 1)
                    distinctValues.Add(info.Subject);
            }


            List<int> subjectCounts = new List<int>();
            // DONE: count how many films are under each subject
            foreach (string subject in distinctValues)
            {
                int count = FilmSubjects.Where(x => x.Equals(subject)).Count();
                subjectCounts.Add(count);
            }

            // creating pair values of the subject and number of movies with the specific subject
            var numbersAndWords = distinctValues.Zip(subjectCounts, (first, second) => first + ": " + second).ToList();


            return numbersAndWords;
        }

        public void ExportSearchResults(List<FilmInfo> films, string fullOutputFileName)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Here is the result list for matched movies");

            foreach(var film in films)
            {
                result.AppendLine(film.ToString());
            }

            File.WriteAllText(fullOutputFileName, result.ToString());
        }

        public void ExportUniqueActoressesList(List<string> listOfActoresses, string fullOutputFileName)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Here is the  list of unique actoresses");

            foreach (var s in listOfActoresses)
            {
                result.AppendLine(s);
            }

            File.WriteAllText(fullOutputFileName, result.ToString());
        }

        public void ExportUniqueActorsList(List<string> listOfActors, string fullOutputFileName)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Here is the  list of unique actoresses");

            foreach (var s in listOfActors)
            {
                result.AppendLine(s);
            }

            File.WriteAllText(fullOutputFileName, result.ToString());
        }

        public void ExportSubjectAndCounts(List<string> listOfSubjectsAndCounts, string fullOutputFileName)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Here is the list of Subjects and their Numbers (Subject : Count)");

            foreach (var s in listOfSubjectsAndCounts)
            {
                result.AppendLine(s);
            }

            File.WriteAllText(fullOutputFileName, result.ToString());
        }
            

        public void ExportSearchTitles(List<FilmInfo> films, string fullOutputFileName, string matchString)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Here is the result list for matched movies containing '{matchString}'");

            foreach (var film in films)
            {
                result.AppendLine(film.ToString());
            }

            File.WriteAllText(fullOutputFileName, result.ToString());
        }

        public void ExportActorsListAwardStatus(List<string> listOfActorsAwardStatus, string fullOutputFileName, bool awardStatus)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Here is the list of Actors with the Award status '{awardStatus}'");

            foreach (var s in listOfActorsAwardStatus)
            {
                result.AppendLine(s);
            }

            File.WriteAllText(fullOutputFileName, result.ToString());
        }

        public List<string> GetActorsWithAwardStatus(List<FilmInfo> infos, bool awardStatus)
        {
            List<string> actorList = new List<string>();
            

            foreach (FilmInfo info in infos)
            {
                if (info.Awards == awardStatus && !actorList.Contains(info.ActorName))
                {
                    actorList.Add(info.ActorName);
                }

            }
            return actorList;
        }


        //unique actoresses
        public List<string> GetUniqueActoressesList(List<FilmInfo> infos)
        {
            List<string> actoresses = new List<string>();

            foreach(FilmInfo info in infos)
            {
                if (!actoresses.Contains(info.ActoressName))
                    actoresses.Add(info.ActoressName);
            }

            return actoresses;

        }

        public List<string> GetUniqueActorsList(List<FilmInfo> infos)
        {
            List<string> actors = new List<string>();

            foreach (FilmInfo info in infos)
            {
                if (!actors.Contains(info.ActorName))
                    actors.Add(info.ActoressName);

            }

            return actors;
        }

        public List<FilmInfo> ImportFile(string filename)
        {
            List<FilmInfo> infos = new List<FilmInfo>();

            string fullFileName = $"{PathToFile}{filename}";
            string[] lines = File.ReadAllLines(fullFileName);

            for (int i = 2; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(';');
                FilmInfo info = new FilmInfo();
                info.ReleaseYear = int.Parse(line[0]);

                if (!string.IsNullOrWhiteSpace(line[1]))
                    info.FilmLength = int.Parse(line[1]);

                info.Title = line[2];
                info.Subject = line[3];
                info.ActorName = line[4];
                info.ActoressName = line[5];
                info.DirectorName = line[6];

                if (!string.IsNullOrWhiteSpace(line[7]))
                    info.Popularity = int.Parse(line[7]);

                if (line[8] == "Yes")
                {
                    info.Awards = true;
                }
                else
                {
                    info.Awards = false;
                }

                infos.Add(info);
            }

            return infos;

        }

        public void Process()
        {
            var filmInfos = ImportFile("film.csv");
                
                int totalFilmsByAwardStatus = CountFilmsByAwardStatus(true, filmInfos);
                Console.WriteLine($"The Total Films who won award are : {totalFilmsByAwardStatus}");

                var uniqueActorsList = GetUniqueActorsList(filmInfos);

                Console.WriteLine("Unique Actor List From whole file is as follows:");
                foreach(string actorName in uniqueActorsList)
                {
                    Console.WriteLine(actorName);
                }


                var uniqueActoressList = GetUniqueActoressesList(filmInfos);

                Console.WriteLine("Unique Actoress List From whole file is as follows:");
                foreach (string actoressName in uniqueActoressList)
                {
                    Console.WriteLine(actoressName);
                }

                string searchByKeyword = "life";
                List<FilmInfo> matchedTitles = SearchByTitleBegining(searchByKeyword, filmInfos);


                Console.WriteLine($"The search results for Title starting with {searchByKeyword}");

                foreach(FilmInfo title in matchedTitles)
                {
                    Console.WriteLine(title);
                }

                bool ChosenAwardStatus = true;
                List<string> ActorsByAwardStatus = GetActorsWithAwardStatus(filmInfos, ChosenAwardStatus);
                Console.WriteLine($"Printing Actors by award status '{ChosenAwardStatus}':");
                int counter = 0;
                foreach(string line in ActorsByAwardStatus)
                {
                    counter++;
                    Console.WriteLine($"{counter}) {line}");
                }

                string matchString = "ov";
                List<FilmInfo> collectedTitles = SearchTitles(matchString, filmInfos);
                Console.WriteLine($"The search results for Title containing  '{matchString}'");

                foreach (FilmInfo title in collectedTitles)
                {
                    Console.WriteLine(title);
                }


                List<string> filmsPerSubject = CountOfFilmsForEachSubject(filmInfos);
                Console.WriteLine("Printing subjects and their number:");
                foreach (var item in filmsPerSubject)
                {
                    Console.WriteLine($"Subject {item}");
                }

                // EXPORTS
                string fullFileNameForSearchMatched = $"{PathToFile}matchresult.csv";
                ExportSearchResults(matchedTitles, fullFileNameForSearchMatched);
                Console.WriteLine($"File successfully exported to the location:\n'{fullFileNameForSearchMatched}'");

                // saving csv with the search results based on defined string 

                string fullFileNameForSearchTitles = $"{PathToFile}stringMatchResults.csv";
                ExportSearchTitles(collectedTitles, fullFileNameForSearchTitles, matchString);
                Console.WriteLine($"File successfully exported to the location:\n'{fullFileNameForSearchTitles}'");

                // writing the data into csv
                bool awardStatus = false;
                List<string> ActorListAwardStatus = GetActorsWithAwardStatus(filmInfos, awardStatus);
                string fullFileNameForActorListAwardStatus = $"{PathToFile}ActorListAwardStatus.csv";
                ExportActorsListAwardStatus(ActorListAwardStatus, fullFileNameForActorListAwardStatus, awardStatus);
                Console.WriteLine($"File successfully exported to the location:\n'{fullFileNameForActorListAwardStatus}'");
                
                string fullFileNameForSubjectAndCount = $"{PathToFile}subjectAndCount.csv";
                ExportSubjectAndCounts(filmsPerSubject, fullFileNameForSubjectAndCount);
                Console.WriteLine($"File successfully exported to the location:\n'{fullFileNameForSubjectAndCount}'");
                
            }





            public List<FilmInfo> SearchByTitleBegining(string matchKey, List<FilmInfo> infos)
        {
            List<FilmInfo> filmsMatched = new List<FilmInfo>();

            foreach (FilmInfo i in infos)
            {
                if (i.Title.StartsWith(matchKey, StringComparison.CurrentCultureIgnoreCase)){
                    filmsMatched.Add(i);
                }
            }

            return filmsMatched;
        }

        public List<FilmInfo> SearchTitles(string keyWord, List<FilmInfo> infos)
        {
            List<FilmInfo> titlesMatched = new List<FilmInfo>();

            foreach (FilmInfo i in infos)
            {
                if (i.Title.Contains(keyWord))
                {
                    titlesMatched.Add(i);
                }
            }

            return titlesMatched;
        }
    }
}
