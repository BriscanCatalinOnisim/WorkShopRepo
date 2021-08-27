# Hello World
This is a hello world project.

Heroku deplyed app: https://app-helloworld-catalin.herokuapp.com/

## How to run / deploy
### Locally (via Docker)

1.Build container

```
docker build -t app-helloworld-catalin
```

2. Create and run docker container
```
docker run -d -p 8081:80 --name app-helloworld-catalin-container app-helloworld-catalin
```

## How to deploy to heroku 
1.Login to heroku
```
heroku login
heroku container:login
```

2.Push container
```
heroku container:push -a app-helloworld-catalin web
```

3.Release the container
```
heroku container:release -a app-helloworld-catalin web
```