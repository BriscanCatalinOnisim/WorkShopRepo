# My first line
Sample text here
We are going to use entity framework
Modified Read me with EF core

## How to deploy to heroku 
Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a app-helloworld-catalin web
```

Release the container
```
heroku container:release -a app-helloworld-catalin web
```