# TestAngular
- angular project used to test login features

# set up cors for angular
- create a file proxy.conf.js at the root of your angular app with the following :
```
    const PROXY_CONFIG = [
     {
     context: ["/api"],
     target: "https://localhost:7115",
     secure: false,
     logLevel: "error",
     changeOrigin: true,
    }
   ];
   module.exports = PROXY_CONFIG;
```
2 - in angular.json in projects -> yourprojectname -> architect -> serve ->configurations -> development, add "proxyConfig": "proxy.conf.js"
```
 "serve": {
          "builder": "@angular-devkit/build-angular:dev-server",
          "configurations": {
            "production": {
              "browserTarget": "client:build:production"
            },
            "development": {
              "browserTarget": "client:build:development",
              "proxyConfig": "proxy.conf.js"
            }
          },
```
3 - in your Angular WebReqService, set 
```
myUrl = 'http://localhost:4200';
```