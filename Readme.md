dotnet publish -c Release -r win-x64 --self-contained true


npx -p @angular/cli ng new my-project
npm run build
npm run build -- --configuration production