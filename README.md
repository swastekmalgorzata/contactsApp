# contactsApp  
• opis poszczególnych klas i metod:
  //Klasa TokenServices jest odpowiedzialna za generowanie JWT
  //AuthController odpowiada za logowanie, rejestrację użytkownika oraz generowanie tokenu
  //Contacts zawiera w sobie CRUD dla kontaktu
  
• wykorzystane biblioteki/pakiety,
  //Microsoft.AspNetCore.Authentication.JwtBearer
  //Microsoft.AspNetCore.Identity.EntityFrameworkCore
  //Microsoft.EntityFrameworkCore.Design
  //Microsoft.EntityFrameworkCore.SqlServer
  //Microsoft.EntityFrameworkCore.Tools
  //Microsoft.VisualStudio.Web.CodeGeneration.Design
  
• sposób kompilacji aplikacji:
  należy zmienić parametr serwera w pliku appsettingjson na swój własny
  aplikację wystarczy odpalić z poziomu VisualStudio,
  zalecam zaczęcie od rejestracji użytkownika i zalogowania, 
  wtedy zostanie wygenerowany token który wykorzystuję do autoryzacji aby mieć dostęp 
  do dodawania pozycji, edcyji i usuwania,
  
