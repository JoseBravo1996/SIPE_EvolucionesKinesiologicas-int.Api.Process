#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM  mcr.microsoft.com/dotnet/aspnet:7.0

RUN wget -O aspnetcore.tar.gz https://download.visualstudio.microsoft.com/download/pr/0857e86d-4206-4c14-b814-e5e3424f8396/6e1113fce778ef9ff69eb2ffefd6de76/aspnetcore-runtime-7.0.0-rc.1.22427.2-linux-musl-x64.tar.gz \
    && aspnetcore_sha512='7273e40bc301923052e2176e8321462790e3b654688f473dc7cac613ad27f181190dabbba79929f983424c9b5b5085b8d4be9cc9f0f1d0197f58ef3bb9aa8638' \
    && echo "$aspnetcore_sha512  aspnetcore.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -zxf aspnetcore.tar.gz -C /usr/share/dotnet \
    && rm aspnetcore.tar.gz \
    && ln -sf /usr/share/dotnet/dotnet /usr/bin/dotnet


RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /app
ARG source
ENV ASPNETCORE_URLS http://*:7035
ENV ASPNETCORE_ENVIRONMENT=Docker
EXPOSE 7035
COPY ${source:-/build} .
RUN ls
RUN dotnet --list-runtimes
ENTRYPOINT ["dotnet", "SIPE_EvolucionesKinesiologicas-int.Api.Process.dll"]