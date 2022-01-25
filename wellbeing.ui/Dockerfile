FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BUILD_CONFIG
WORKDIR /app

# copy csproj and restore as distinct layers
#COPY wellbeing.ui.sln .
COPY wellbeing.ui/wellbeing.ui.csproj wellbeing.ui/
COPY wellbeing.lib/wellbeing.lib.csproj wellbeing.lib/
#COPY wellbeing.db/wellbeing.db.mdproj wellbeing.db/
RUN dotnet restore wellbeing.ui/

# copy everything else and build app
COPY wellbeing.ui ./wellbeing.ui
COPY wellbeing.lib ./wellbeing.lib

WORKDIR /app/wellbeing.ui
RUN dotnet publish -c $BUILD_CONFIG -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
ENV TZ=Europe/London
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
#RUN apt-get update -qq
#RUN apt-get install -y libgdiplus
COPY --from=build /app/wellbeing.ui/out ./
ENTRYPOINT ["dotnet", "wellbeing.ui.dll"]
