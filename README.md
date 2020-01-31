# mobak-dockerize-grapql-api

- This application shows you how to build sample Asp.net Core Web API with GraphQL and how to dockerize it.

 # Getting Started

## 1. Download or clone this repository with

```
git clone https://github.com/oktydag/mobak-dockerize-grapql-api.git

```

## 2. Installation

[![NuGet](https://img.shields.io/nuget/v/GraphQL)](https://www.nuget.org/packages/GraphQL)

You can install the latest version via [NuGet](https://www.nuget.org/packages/GraphQL/).

```
> dotnet add package GraphQL
> dotnet add package GraphQL -v 3.0.0-preview-1352
```

## 3.  Sample Usage of GraphQL 

```
Request URL :	 http://localhost:8000/graphql
```

**Sample Request :**
```json
{ 
 "query":
  "query{
     albume(id:2){
       name
       songs{
       	id
       	description
       }
     }
   }"
}
```


**Sample Response :**
```json
{
    "data": {
        "albume": {
            "name": "Anti",
            "songs": [
                {
                    "id": 4,
                    "description": "Hey boy, I really wanna see if you"
                },
                {
                    "id": 5,
                    "description": "Work, work, work, work, work, work"
                },
                {
                    "id": 5,
                    "description": "What are you willing to do"
                }
            ]
        }
    }
}
```


## 4. Dockerize Asp.net Core Web API

- ** Create a Dockerfile** in your project directory, for this project, I created like this; 

```dockerfile
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app
 
COPY *.csproj ./
RUN dotnet restore
 
COPY . ./
RUN dotnet publish -c Release -o out
 
FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
 
WORKDIR /app
 
COPY --from=build /app/out .

ENTRYPOINT ["dotnet","Moba.Services.dll"]
```


- Set the cmd to your Dockerfile directory, and **Build your docker image**

```dockerfile
 docker build -t moba-graphql .
```

-  **Run a new container ** from moba-graphql image as detach and port is 8000 ( whatever you want ) that gets from 80.

```dockerfile
docker container run -d -p 8000:80 --name sample-graphql-api  moba-graphql
```

- Just request http://localhost:8000/api/values to test and see 

```dockerfile
[
    "value1",
    "value2"
]
```
means that dockerize operation is success. Now, you can request your graphql api. 

