<div align="center">
  <img src="https://media.giphy.com/media/dWesBcTLavkZuG35MI/giphy.gif" width="600" height="300"/>
</div>

---

### :man_technologist: About Me :

I am a Full Stack Developer <img src="https://media.giphy.com/media/WUlplcMpOCEmTGBtBW/giphy.gif" width="30"> from Ecuador.

- :telescope: I’m working as a Software Engineer and contributing to frontend and backend for building web applications.

- :seedling: Exploring Technical Content Writing.

- :zap: In my free time, I solve problems on Flimboo my developer group and read tech articles.

- :mailbox:How to reach me: [![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-blue?style=flat&logo=Linkedin&logoColor=white)]([your-linkedin-url](https://ec.linkedin.com/in/sebasti%C3%A1n-pinos-m%C3%A9ndez-b9933b1b7))

---

### 📱 Project Instructions :


- ### MySql DataBase: 
                  To have the database active, mysql server community must be installed, and to be able to access and import it, mysql workbench is needed. 
                  Once installed and checking that everything is correct, the connection url to the database is needed, taking into account the port, user, password
                  and schema name. 
                  We will need it for the backend. Example: "server=localhost; database=granhotel; user=root; password=1234".
                  The sql dump is in /DataBase, this files have all the data and structure to import in MysqlWorkbench or run into a SQL Query.
                  
- ### Backend Net Core: 
                    For net core to work, we must first copy the previous connection string and put it in the "WebApiDataBase" section of the appsettings.json file, 
                    this file is located at :"/GranHotelExercise/Backend Gran Hotel/appsettings.json", then it is needed open the terminal and write the dotnet 
                    run command, this initializes the project and shows us the url of localhost and its port we will save this for later. Example: "http://localhost:5126"
                    
- ### Frontend Angular: 
                    For Angular to work, you need to first paste the previous url in the environment.ts file in the apiURL section, the file is located 
                    in "GranHotelExercise/Frontend Gran Hotel/FrontendGranHotel/src/environment.ts", then in the terminal you must write the command ng serve -o 
                    for its operation and it directs us to the web application to be able to use it.
                    
- ### Important Notes: status "A" means available and "N" means not available, when a reservation goes to status A it is not taken into, it is like a logical elimination 

- ### If the client does not exist at check-in, it is created automatically, if it has an ID already created, it is obtained with the name of the check-in database. To check out you only need to press the button since the departure date is the current one
             
