### Création d'un ws 

## Controller  
Dans la partie Controller, nous avons la définition des webservices.
Définition des web services dans le fichier `BooksController.cs`


## Services   
Dans la partie service, nous avons l'accès aux données et le code métier.  
Définition de la connexion à la base et des services CRUD dans `BookService.cs`  


## Models  
Dans la partie Models, nous avons la définition des objets, et des objets de BDD   
Définition de l'objet de base de données Book dans `Book.cs`  
# Models\Database  
Définition de l'interface bdd dans le fichier `BookStoreDatabaseSettings.cs`


## appsettings.json 
Définition de la base de données dans le fichier `appsettings.json`

"BookstoreDatabaseSettings": {
    "BooksCollectionName": "Books",
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "BookstoreDb"
  }

## Startup.cs 
Ajout des singletons 

services.Configure<BookstoreDatabaseSettings>(
Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value
);
services.AddSingleton<BookService>();



