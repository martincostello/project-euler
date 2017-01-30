#!/bin/sh
dotnet restore --verbosity minimal || exit 1
dotnet build src/ProjectEuler/ProjectEuler.csproj || exit 1
dotnet test tests/ProjectEuler.Tests/ProjectEuler.Tests.csproj || exit 1
