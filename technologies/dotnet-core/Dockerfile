FROM microsoft/dotnet:1-runtime
WORKDIR /app
COPY dist .
EXPOSE 8090/tcp
ENTRYPOINT ["dotnet", "dotnet-core.dll"]