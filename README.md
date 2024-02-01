# OidcDemo
Demo of Oidc on .Net 6 (Core)

# Setup
have Node.js installed

go to client-app

run the command "npm install"

on Linux : "build-linux"

on Windows : "build-windows"

start the .Net solution after the build

## solve NET::ERR_CERT_INVALID error (https issue)

dotnet dev-certs https --clean

dotnet dev-certs https --trust

dotnet dev-certs https --check

## Principe
- the frontend make a test if authenticated ahd redirects to the login endpoint if not  in OidcDemo\src\OicdDemo\client-app\src\App.jsx

- the login endpoint performs a Challenge : OidcDemo\src\OicdDemo\Controllers\AuthController.css

- then the user is redirected to login page in the browser to enter his password

- the browser is redirected to https://localhost:5114 because it is the ReturnUrl in OidcDemo\src\OicdDemo\appsettings.Development.json

- in the configuration of the OIDC in Azure portal we have set the return url to https://localhost:5114/signin-oidc with a Web Plateform in Authentication menu



