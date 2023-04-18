# contactsApp  
• opis poszczególnych klas i metod:
  <br>
  +Klasa TokenServices jest odpowiedzialna za generowanie JWT
  <br>*AuthController odpowiada za logowanie, rejestrację użytkownika oraz generowanie tokenu
  <br>*Contacts zawiera w sobie CRUD dla kontaktu
  
• wykorzystane biblioteki/pakiety,
  <br>*Microsoft.AspNetCore.Authentication.JwtBearer
  <br>*Microsoft.AspNetCore.Identity.EntityFrameworkCore
  <br>*Microsoft.EntityFrameworkCore.Design
  <br>*Microsoft.EntityFrameworkCore.SqlServer
  <br>*Microsoft.EntityFrameworkCore.Tools
  <br>*Microsoft.VisualStudio.Web.CodeGeneration.Design
  
• sposób kompilacji aplikacji:
  <br>*należy zmienić parametr serwera w pliku appsettingjson na swój własny
  <br>*aplikację wystarczy odpalić z poziomu VisualStudio,
  <br>*zalecam zaczęcie od rejestracji użytkownika i zalogowania, 
  <br>wtedy zostanie wygenerowany token który wykorzystuję do autoryzacji aby mieć dostęp 
  <br>do dodawania pozycji, edcyji i usuwania,
  
