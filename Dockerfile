FROM microsoft/dotnet:onbuild

RUN dotnet ef database update

EXPOSE 5000
