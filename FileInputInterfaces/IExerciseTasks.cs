using System;
using System.Collections.Generic;

namespace FileInputInterfaces
{
    public interface IExerciseTasks

    /*
     GetActorsWithAwardStatus: A method that returns a unique list of Actors who either won/did not win an award (depending on the input)
     SearchTitles: A method that allows searching all the films with a string that can occur any where in the title (i.e. not only the starting text)
     CountOfFilmsForEachSubject: A method that returns a list of subjects and total films for each subject
     */
    {
        List<string> GetActorsWithAwardStatus(List<FilmInfo> infos, bool awardStatus);
        List<FilmInfo> SearchTitles(string keyWord, List<FilmInfo> infos);
        List<string> CountOfFilmsForEachSubject(List<FilmInfo> infos);
    }
}
