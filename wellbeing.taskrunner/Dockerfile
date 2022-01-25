FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIG
WORKDIR /app

# copy csproj and restore as distinct layers
#COPY wellbeing.taskrunner.sln .
COPY wellbeing.taskrunner/wellbeing.taskrunner.csproj wellbeing.taskrunner/
COPY wellbeing.lib/wellbeing.lib.csproj wellbeing.lib/
#COPY wellbeing.db/wellbeing.db.mdproj wellbeing.db/
RUN dotnet restore wellbeing.taskrunner/

# copy everything else and build app
COPY wellbeing.taskrunner ./wellbeing.taskrunner
COPY wellbeing.lib ./wellbeing.lib

WORKDIR /app/wellbeing.taskrunner
RUN dotnet publish -c $BUILD_CONFIG -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
ENV TZ=Europe/London
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
COPY --from=build /app/wellbeing.taskrunner/out ./
ENTRYPOINT ["dotnet", "wellbeing.taskrunner.dll"]
