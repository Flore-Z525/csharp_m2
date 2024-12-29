# HarryPotterIndex
### ZHANG Yu (Nanterre R&D 43010766)
43010766@parisnanterre.fr

(projet pour le cours "Programmation objet 1")

***HarryPotterIndex*** est une application console simple pour gérer et rechercher des informations sur les personnages dans l'univers Harry Potter.   
On peut utiliser diverses commandes pour ajouter de nouveaux personnages, rechercher des personnages, charger et sauvegarder des données de personnages.   
L'application fusionne également automatiquement les informations des personnages en double lors du chargement des données et assure l'intégrité en même temps.

***
## Introduction et prétraitement des données
Inspirée par le projet du *Pokedex* vu en cours, j'envisage de créer un projet sur une collection de personnages dans la série d'***Harry Potter***. 

J'ai trouvé d'abord un fichier json sur ce site : https://github.com/Laboratoria/LIM011-data-lovers/blob/master/src/data/potter/potter.json

Puis, j'obtiens le fichier [hp.json](HarryPotterIndex/Data/hp.json) en enlevant des données redondantes avec le script [extraction.py](extraction.py). 
<br>Pour tous les 25 personnages, je garde les attributs suivants : 
-  `name` : nom de caractère,
- `species` : espèce de caractère, ex. *human / werewolf...*
- `gender` : *female / male*
- `house` : *Gryffindor / Slytherin / Hufflepuff / Ravenclaw / None*
- `yearOfBirth` : année de naissance. 

Ensuite, pour faciliter plus tard le démarrage de la commande `load` (concernant une lecture d'un fichier csv), j'obtiens le fichier csv [hp.csv](HarryPotterIndex/Data/hp.csv) en transformant le fichier json avec le script [json_to_csv.py](json_to_csv.py). 

***
## Commandes utilisables
### add
**ajouter un personnage dans l'index**  
(réalisée par [AddCommand.cs](HarryPotterIndex/Commands/AddCommand.cs))  

`add <name> <species> <gender> [house] [birthYear]`  
- `<name>` (obligatoire) : nom de personnage
- `<species>` (obligatoire) : espèce de caractère, ex. *human / werewolf...*
- `<gender>` (obligatoire) : *female / male*
- `[house]` (optionnel) : *Gryffindor / Slytherin / Hufflepuff / Ravenclaw / None*
- `[yearOfBirth]` (optionnel) : année de naissance.   

exemple : <br>
`add HarryPotter human male (Gryffindor) (1980)`

### search
**chercher un ou des personnage(s) selon leur(s) \<name\>(nom) ou \<house\>(maison)**  
(réalisée par [SearchCommand.cs](HarryPotterIndex/Commands/SearchCommand.cs))  

`search name <name>`  
`search house <house>`
- `name <name>` ou `house <house>` (1 au choix obligatoire) : nom / maison du personnage à chercher

exemples : <br>
`search name HarryPotter`  
`search house Gryffindor`

### load
**charger les données des personnages depuis un fichier csv, et fusionner automatiquement les infos des personnages en double**  
(réalisée par [LoadCommand.cs](HarryPotterIndex/Commands/LoadCommand.cs)) 

`load <filepath>`
- `<filepath>` (obligatoire) : un fichier csv contenant les données de personnages

exemple :  
`load Data/hp.csv`

### save
**sauvegarder les données dans un fichier txt / csv**  
(réalisée par [SaveCommand.cs](HarryPotterIndex/Commands/SaveCommand.cs)) 

`save <filepath>`
- `<filepath>` (obligatoire) : chemin du fichier à sauvegarder

exemples :  
`save Data/hp_test.txt`  
`save Data/hp_test.csv`

### read_json
**charger les données des personnages depuis un fichier json, et fusionner automatiquement les infos des personnages en double**  
(réalisée par [ReadJsonCommand.cs](HarryPotterIndex/Commands/ReadJsonCommand.cs)) 

`read_json <filepath>`
- `<filepath>` (obligatoire) : un fichier json contenant les données de personnages

exemple :  
`read_json Data/hp.json`

### write_json
**sauvegarder les données dans un fichier json**  
(réalisée par [WriteJsonCommand.cs](HarryPotterIndex/Commands/WriteJsonCommand.cs)) 

`write_json <filepath>`
- `<filepath>` (obligatoire) : chemin du fichier à sauvegarder

exemple :  
`write_json Data/hp_test.json`  

### exit
**quitter l'application**  
(réalisée par [ExitCommand.cs](HarryPotterIndex/Commands/ExitCommand.cs)) 

`exit`
- cette commande ne demande pas d'argument

### help
**lister les commandes disponibles**  
(réalisée par [HelpCommand.cs](HarryPotterIndex/Commands/HelpCommand.cs)) 

`help`
- cette commande ne demande pas d'argument


## Propriété Age

Dans la classe `Character`, la propriété `Age` est une propriété en lecture qui calcule et retourne automatiquement l'âge du personnage. Et elle sera affichée dans la sortie standard ou sauvegardée dans les fichiers de sortie. 

- Si la `BirthYear` du personnage peut être analysée en un entier valide, la propriété `Age` calcule automatiquement `l'année actuelle - la "BirthYear"`, pour obtenir l'âge du personnage. 
- Sinon, la propriété `Age` retourne 0. 

#### Exemples

Pour l'année 2024 :

- Si la `BirthYear` d'un personnage est 1980, la valeur de la propriété `Age` sera 44 (2024 - 1980). 
- Si la `BirthYear` d'un personnage est une valeur non valide (ex. une chaîne vide), la valeur de la propriété `Age` sera 0.

#### Pratique

Dans ce projet, la propriété `Age` est utilisée pour afficher les infos d'âge des personnages. 

ex.
```
$ search name HarryPotter
Name: HarryPotter
Species: human
Gender: male
House: Gryffindor
Birth Year: 1980
Age: 44
