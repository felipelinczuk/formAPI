# formAPI

### Requirements

* DotNet
* DotNet EF
* Docker
* Docker-compose

---

### Commands to run

* Creating networking between containers:

        docker network create formAppNetwork

* Preparing project to publish:

        dotnet restore --no-cache

        dotnet publish -c Release

* Building image on a new container and running app:
        
        docker-compose build --no-cache

        docker-compose up -d

---

#### API Server Host

http://localhost:5001

---

#### API Swagger

http://localhost:5001/swagger/index.html

---

#### APP Host

http://localhost:5002