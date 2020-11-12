using System;
using System.Collections.Generic;

namespace FileInputInterfaces
{
    public interface IDescriptives
    {
        /*
                    ListOfUniqueActors: A method that returns a unique list of All the Actors
                     ListOfUniqueActoresses: A method that returns a unique list of actoresses
                     SearchTitlesStarttingWithCharacters: A method that returns list of Films that start with given characters
                     CountOfFilmsOnThebasisWhetherAwardWonOrNot: A method that takes a value for either award won or not and then returns a count
          */


        List<string> GetUniqueActorsList(List<FilmInfo> infos);

        List<string> GetUniqueActoressesList(List<FilmInfo> infos);

        List<FilmInfo> SearchByTitleBegining(string matchKey, List<FilmInfo> infos);

        int CountFilmsByAwardStatus(bool awardStatus, List<FilmInfo> infos);

    }
}
