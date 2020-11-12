# FileInputAndInterfaces
Lecture and Exercise focused on loading csv, parse the data and create methods working with the data as well as output the results.


Acknowledgement: This is a public dataset. downloaded from https://perso.telecom-paristech.fr/eagan/class/igr204/datasets and is prepared by Petra Isenberg, Pierre Dragicevic and Yvonne Jansen for learning purposes. I am using them because they are simple datasets.    

Dataset 1: film.csv  Dataset has movie data for 1600 films. Data has following attributes and types:
- Year: Int  
- Length: Int 
- Title: Text 
- Subject: String 
- Actor: String (Comma separated list of actors) 
- Actress: String (Comma separated list of actoresses) 
- Director: String 
- Popularity: Int (A number from 1 to 100) 
- Awards: Bool (Did film get an award) 
- *Image: String (name of image)  

Lecture Task:   
We develop a console job that imports the file in memory.   
We store all rows of the file into a list of objects.  
We build methods to archive following descriptive analytics:  	
- CountFilms: A method that returns total number of films in the list 	
- ListOfUniqueActors: A method that returns a unique list of All the Actors 	
- ListOfUniqueActoresses: A method that returns a unique list of actoresses 	
- SearchTitlesStarttingWithCharacters: A method that returns list of Films that start with given characters 	
- CountOfFilmsOnThebasisWhetherAwardWonOrNot: A method that takes a value for either award won or not and then returns a count We create functionality to output the above descriptive in a csv file 	 	 

Exercise Task:  
Create a new Interface named IExerciseTasks Amend the class Processor so that it also inherits from IExerciseTasks 
Update Processor class and IExerciseTasks interface to define and implement following methods: 	
- GetActorsWithAwardStatus: A method that returns a unique list of Actors who either won/did not win an award (depending on the input) 	
- SearchTitles: A method that allows searching all the films with a string that can occur any where in the title (i.e. not only the starting text) 	
- CountOfFilmsForEachSubject: A method that returns a list of subjects and total films for each subject 
Update Interface IDescriptivesWriter and develop methods to export above results in file.  	  	 	 	 	  
