# The Best warehouse solution in the world

We have build this system form the ground up. <br />It can do all the things you want and more to it 


# Getting started

**Please** Follow the instruction stade

## Requirements

 - GIT (https://git-scm.com/)
 - Docker or Docker Desktop (https://www.docker.com/)
 - SQL Server Management Studio (SSMS) (https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)

## Get the system 

First open cmd also call console, Command Prompt or Terminal.
Now write `git clone https://github.com/H1-SDE/Plukliste.git && cd Plukliste`
## Get Database up and running

1. Open a new ternimal and run the following command.
2. Remembere to change `S3cur3P@ssW0rd!` To your own password.
3. `docker run --name lager_db -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=S3cur3P@ssW0rd!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest`
4. To check you was successful run `docker container ls` in your terminal.
5. You can also check it in your `Docker Desktop` by go to the Containers tap and see if the container by the name `lager_db` is green.

![How it shoud look if the command was successful in Docker Desktop](https://i.ibb.co/mv3bP5k/Udklip.png) 

### Store some data in your database
1. Open your SSMS.
2. Make sure the following fields is correct. Like show below
![SSMS with the correct values](https://i.ibb.co/cy9m37T/Udklip.png)
3. Your can now click on **connect**.
4. If the connection was successful, it shoud look like this.
![SSMS look like this. If the connection was successful](https://i.ibb.co/PwwQMcN/Udklip.png)

5. Now click on the +.
![SSMS click on plus symbole](https://i.ibb.co/090GdY5/Udklip.png)

6. Now right-click on `Databases`
![SSMS right-click on Databases](https://i.ibb.co/vs0SvYk/Udklip.png)

7.  Now click on `New Database...`
![click on New Database...](https://i.ibb.co/qy4sZwb/Udklip.png)

8. In the field `Database name:` write Lager.
![SSMS insert Lager in the field Database name](https://i.ibb.co/C2jtTGM/Udklip.png)

9. Click now on OK.
![SSMS Click on OK](https://i.ibb.co/S57Ng6S/Udklip.png)

10. It shoud look like this.
![SSMS Under Databases there shoud be a database icon named Lager](https://i.ibb.co/sKXvm7Q/Udklip.png)

11. Now find the file named `SqlRun` in the folder we have our project in.
![The file](https://i.ibb.co/N2TfVbq/Udklip.png)

12. Back in `SSMS` in the top of the application click:
	 1. `Files`
	 2. `Open`
	 3. `File...`
![Click on File, Open, File...](https://i.ibb.co/GpR9q6z/Udklip.png)

13. Now finde the file named `SqlRun` from step `11` and click open.
![Project folder with the file named SqlRun and click on open](https://i.ibb.co/GnytvrN/Udklip.png)

14. Now it shoud look like this in your `SSMS`.
![Your SSMS view. If the operation was successful](https://i.ibb.co/GCyQgv0/Udklip.png)

15. You can now click on `Execute`
> If the text in the field next to Execute is master. Click on it and select Lager and then click on `Execute`.

![Field with the text Lager and next to it is a button named Execute](https://i.ibb.co/Jdk6X7h/Udklip.png)

16. If all was successful. You will see this window with the text in it. Like showed below.
![Window with text](https://i.ibb.co/sQKkJ8V/Udklip.png) 

17. **Congratulations** you have now successfully maked the database and can now go to `Get website yp and running` for get our system ui to work.

## Get website up and running

> All the files and folders are presented as a tree in the file explorer. 
> You can switch from one to another by clicking a file in the tree.

1. Go into the right folder, if you are not in it with this command `cd Plukliste/Lager`. <br />If it not working try this  `cd  Lager` 
2. Now run following command `docker build -t website -f ./Lager/Dockerfile .`
3. If you have no error check the image was build with the following command or in the `docker desktop` like shown below.

> 	**Command:** `docker image ls` 	If the command show the below you
> have secess full create the image.
![Output from command: docker image ls ](https://i.ibb.co/QKsg3NX/Udklip.png)
Docker Desktop: 
![In Docker Desktop](https://i.ibb.co/x8B7KyM/Udklip.png)
4. Now back to your terminal run the following command: `docker run -p 0.0.0.0:32774:80/tcp -p 0.0.0.0:32775:443/tcp --name lagerWebsite website`
5. You are now done and ready to use our system.

## Delete a file

You can delete the current file by clicking the **Remove** button in the file explorer. The file will be moved into the **Trash** folder and automatically deleted after 7 days of inactivity.
