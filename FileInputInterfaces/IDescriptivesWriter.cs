using System;
using System.Collections.Generic;

namespace FileInputInterfaces
{
    public interface IDescriptivesWriter
    {
        /*
        List<string> GetUniqueActorsList(List<FilmInfo> infos);

        List<string> GetUniqueActoressesList(List<FilmInfo> infos);

        List<FilmInfo> SearchByTitleBegining(string matchKey, List<FilmInfo> infos);

        int CountFilmsByAwardStatus(bool awardStatus, List<FilmInfo> infos);
         */


        void ExportUniqueActorsList(List<string> list, string fullOutputFileName);
        void ExportUniqueActoressesList(List<string> list, string fullOutputFileName);
        void ExportSearchResults(List<FilmInfo> films, string fullOutputFileName);

    }
}
