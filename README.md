dotnet new sln
dotnet new classlib -o Mjos.Learn.Core
dotnet new classlib -o Mjos.Learn.Infrastructure
dotnet new classlib -o Mjos.Learn.Infrastructure.EfCore
dotnet sln add .\Mjos.Learn.Core\
dotnet sln add .\Mjos.Learn.Infrastructure\
dotnet sln add .\Mjos.Learn.Infrastructure.EfCore\
