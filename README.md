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